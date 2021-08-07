using System;
using UnityEngine;

public class ActorVision : MonoBehaviour
{
    [Serializable]
    public struct Detection
    {
        public Vector3 Origin;
        public Vector3 Where;
        public bool IsTarget;
        
        public float Distance => Vector3.Distance(Where, Origin);
        
    }

    public Detection ForwardDetection;
    public Detection RightDetection;
    public Detection BackwardDetection;
    public Detection LeftDetection;
    
    public Detection ForwardLeftDetection;
    public Detection ForwardRightDetection;
    public Detection BackwardRightDetection;
    public Detection BackwardLeftDetection;
    private Vector3 fwd;
    private Vector3 origin;
    private Vector3 bwd;
    private Vector3 right;
    private Vector3 left;
    private Vector3 fwdLeft;
    private Vector3 fwdRight;
    private Vector3 bwdLeft;
    private Vector3 bwdRight;

    public void Start()
    {
        var tf = transform;
        origin = tf.position;
        fwd = tf.forward;
        bwd = -fwd;
        right = tf.right;
        left = -right;

        fwdLeft = fwd + left;
        fwdRight = fwd + right;
        bwdLeft = bwd + left;
        bwdRight = bwd + right; 
    }
    
    void Update()
    {
        origin = transform.position;
        
        ForwardDetection = Physics.Raycast(origin, fwd, out var hfwd) ? Detect(hfwd) : ForwardDetection;
        RightDetection = Physics.Raycast(origin, right, out var hright) ? Detect(hright) : RightDetection;
        BackwardDetection = Physics.Raycast(origin, bwd, out var hbwd) ? Detect(hbwd) : BackwardDetection;
        LeftDetection = Physics.Raycast(origin, left, out var hleft) ? Detect(hleft) : LeftDetection;
        
        ForwardRightDetection = Physics.Raycast(origin, fwdRight, out var hfr) ? Detect(hfr) : ForwardRightDetection;
        BackwardRightDetection = Physics.Raycast(origin, bwdRight, out var hbr) ? Detect(hbr) : BackwardRightDetection;
        BackwardLeftDetection = Physics.Raycast(origin, bwdLeft, out var hbl) ? Detect(hbl) : BackwardLeftDetection;
        ForwardLeftDetection = Physics.Raycast(origin, fwdLeft, out var hfl) ? Detect(hfl) : ForwardLeftDetection;

    }
    
    
    Detection Detect(RaycastHit hit)
    {
        return new Detection
        {
            Origin = transform.position,
            Where = hit.point,
            IsTarget = hit.collider.CompareTag("Goal")
        };
    }

    public void OnDrawGizmos()
    {
        Color originalColor = Gizmos.color;
        
        DrawVisionLine(origin,LeftDetection ,left);
        DrawVisionLine(origin,RightDetection,right);
        DrawVisionLine(origin,ForwardDetection,fwd);
        DrawVisionLine(origin,BackwardDetection,bwd);
        DrawVisionLine(origin,ForwardRightDetection ,fwdRight);
        DrawVisionLine(origin,BackwardRightDetection,bwdRight);
        DrawVisionLine(origin,BackwardLeftDetection,bwdLeft);
        DrawVisionLine(origin,ForwardLeftDetection,fwdLeft);

        Gizmos.color = originalColor;
    }

    private void DrawVisionLine(Vector3 origin, Detection detection, Vector3 alternate)
    {
        if (detection.Where.magnitude > 0f)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(origin, detection.Where);
            Gizmos.DrawSphere(detection.Where, 0.1f);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(origin, origin + alternate);
        }
    }
}
