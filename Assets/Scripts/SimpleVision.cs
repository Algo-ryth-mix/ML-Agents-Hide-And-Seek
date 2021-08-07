using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActorVision))]
public class SimpleVision : MonoBehaviour
{
    private ActorVision m_complexVision;

    // Start is called before the first frame update
    void Start()
    {
        m_complexVision = GetComponent<ActorVision>();
    }

    public List<float> GetVision()
    {
        return new List<float>
        {
            m_complexVision.ForwardDetection.Distance * (m_complexVision.ForwardDetection.IsTarget? 1:-1),
            m_complexVision.RightDetection.Distance * (m_complexVision.RightDetection.IsTarget? 1:-1),
            m_complexVision.BackwardDetection.Distance * (m_complexVision.BackwardDetection.IsTarget? 1:-1),
            m_complexVision.LeftDetection.Distance * (m_complexVision.LeftDetection.IsTarget? 1:-1),
            m_complexVision.ForwardRightDetection.Distance * (m_complexVision.ForwardRightDetection.IsTarget? 1:-1),
            m_complexVision.BackwardRightDetection.Distance * (m_complexVision.BackwardRightDetection.IsTarget? 1:-1),
            m_complexVision.BackwardLeftDetection.Distance * (m_complexVision.BackwardLeftDetection.IsTarget? 1:-1),
            m_complexVision.ForwardLeftDetection.Distance * (m_complexVision.ForwardLeftDetection.IsTarget? 1:-1),
        };
    }
}