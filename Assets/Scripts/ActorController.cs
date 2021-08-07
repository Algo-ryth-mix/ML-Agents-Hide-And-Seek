using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ActorController : MonoBehaviour
{
    [Range(500,1000)]
    [SerializeField] private float m_forceModifier = 500;
    
    private Rigidbody m_rigidbody;
    
    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    
    public void Move(Vector2 direction)
    {
        if(direction.magnitude > 1)
            direction.Normalize();
        
        var forward = new Vector3(direction.x, 0, direction.y);
        
        //transform.forward = forward;
        transform.position += (forward / Speed.Instance.SpeedDivisor);
    }
}
