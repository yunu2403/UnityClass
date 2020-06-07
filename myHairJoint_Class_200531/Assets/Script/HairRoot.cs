using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HairRoot : MonoBehaviour
{
    
    private List<Rigidbody> rigidbodies = new List<Rigidbody>();
    private LineRenderer _lineRenderer;
    private List<HairSegment> _hairSegments = new List<HairSegment>();

    public float lineSegLength = 0.25f;
    public int seqCount = 25;
    public float lineWidth = 1f;

    private bool isInit = false;


    // Start is called before the first frame update
    public void MakeHair()
    {
        this._lineRenderer = this.GetComponent<LineRenderer>();
        this._lineRenderer.enabled = true;

        Vector3 startPos = transform.position;

        for(int i = 0; i < seqCount; i++)
        {
            _hairSegments.Add(new HairSegment(startPos));

            var obj = new GameObject("col");
            obj.transform.SetParent(transform);
            obj.transform.position = startPos;
            obj.layer = gameObject.layer;
            var col = obj.AddComponent<SphereCollider>();
            col.radius = lineWidth * 0.5f;

            var body = obj.AddComponent<Rigidbody>();
            body.useGravity = false;
            body.interpolation = RigidbodyInterpolation.Extrapolate;
            body.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rigidbodies.Add(body);
            startPos += transform.forward * lineSegLength;
        }

        isInit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInit == true)
            DrawHair();   
    }

    private void FixedUpdate()
    {
        if(isInit == true)
            Simulate();
    }


    private void Simulate()
    {

        Vector3 forceGrivity = Vector3.down * 9.8f;

        for (int i = 1; i < this._hairSegments.Count; i++)
        {
            HairSegment seg = _hairSegments[i];
            Vector3 velocity = seg.posNow - seg.posOld;
            seg.posOld = rigidbodies[i].position;
            rigidbodies[i].velocity = velocity;
            rigidbodies[i].velocity += forceGrivity;
            seg.posNow = rigidbodies[i].position;
            this._hairSegments[i] = seg;
        }
        for (int i = 0; i < 50; i++)
        {
            ApplyConstraint();
        }
    }

    private void ApplyConstraint()
    {

        var firstSegments = this._hairSegments[0];
        firstSegments.posNow = transform.position;
        this._hairSegments[0] = firstSegments;
        rigidbodies[0].position = firstSegments.posNow;

        for (int i = 0; i < this._hairSegments.Count - 1; i ++)
        {
            HairSegment firstSeq = this._hairSegments[i];
            HairSegment secondSeq = this._hairSegments[i + 1];

            float dist = (firstSeq.posNow - secondSeq.posNow).magnitude;
            float error = Mathf.Abs(dist - this.lineSegLength);

            Vector3 changeDir = Vector3.zero;

            if(dist  > lineSegLength)
                changeDir = (firstSeq.posNow - secondSeq.posNow).normalized;
            else if (dist < lineSegLength)
                changeDir = (secondSeq.posNow - firstSeq.posNow).normalized;

            Vector3 amount = changeDir * error;

            if (i != 0)
            {
                firstSeq.posNow -= amount * 0.5f;
                rigidbodies[i].position = firstSeq.posNow;
                secondSeq.posNow += amount * 0.5f;
                rigidbodies[i + 1].position = secondSeq.posNow;


                firstSeq.posNow = rigidbodies[i].position;
                rigidbodies[i + 1].position = rigidbodies[i + 1].position;
                _hairSegments[i] = firstSeq;
                _hairSegments[i + 1] = secondSeq;
            }
            else
            {
                secondSeq.posNow += amount;
                _hairSegments[i + 1] = secondSeq;
                rigidbodies[i + 1].position = secondSeq.posNow;
            }
        }

    }

    private void DrawHair()
    {
        _lineRenderer.startWidth = lineWidth;
        _lineRenderer.endWidth = lineWidth;

        Vector3[] positions = new Vector3[_hairSegments.Count];

        for (int i = 0; i < this._hairSegments.Count; i++)
        {
            positions[i] = rigidbodies[i].position;
        }

        _lineRenderer.positionCount = _hairSegments.Count;
        _lineRenderer.SetPositions(positions);
    }

    public struct HairSegment
    {
        public Vector3 posNow, posOld;

        public HairSegment(Vector3 pos)
        {
            posNow = pos;
            posOld = pos;
        }
    }
}
