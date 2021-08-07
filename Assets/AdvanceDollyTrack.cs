using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class AdvanceDollyTrack : MonoBehaviour
{
    [Range(0,2)]
    [SerializeField] private float m_speed = 1;
    
    private CinemachineVirtualCamera m_camera;
    private void Awake()
    {
        m_camera = GetComponent<CinemachineVirtualCamera>();
    }


    void Update()
    {
        m_camera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition += Time.deltaTime * m_speed;
    }
}
