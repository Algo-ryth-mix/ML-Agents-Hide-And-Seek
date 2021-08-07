using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(ActorController))]
public class MLMover : Agent
{

    private ActorController m_controller;

    [SerializeField] private Transform m_reward; 

    private Vector3 m_startPosition;
    private Quaternion m_startRotation;
    
    public override void OnEpisodeBegin()
    {
        transform.position = m_startPosition;
        transform.rotation = m_startRotation;
        m_reward.position = new Vector3(m_startPosition.x + Random.Range(-2f, 2f), m_reward.position.y,
            m_startPosition.z + Random.Range(-2f, 2f));
    }
    
    private void Awake()
    {
        m_controller = GetComponent<ActorController>();
        m_startPosition = transform.position;
        m_startRotation = transform.rotation;

    }

   // public override void CollectObservations(VectorSensor sensor)
   // {
        /*
        var center = m_vision.CenterDetection;
        var left = m_vision.LeftDetection;
        var right = m_vision.RightDetection;

        void CheckSensor(ActorVision.Detection detection)
        {
            sensor.AddObservation(detection.Distance);
            sensor.AddObservation(detection.IsTarget? 1.0f:0.0f);
        }
        
        CheckSensor(center);
        CheckSensor(left);
        CheckSensor(right);
        */
        
       // sensor.AddObservation(m_vision.GetVision());
   // }


    public override void OnActionReceived(ActionBuffers actions)
    {
        var movement = new Vector2(actions.ContinuousActions[0], actions.ContinuousActions[1]);
        m_controller.Move(movement);
    }
}
