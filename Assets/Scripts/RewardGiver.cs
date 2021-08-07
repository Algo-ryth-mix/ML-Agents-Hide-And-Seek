using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardGiver : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Actor"))
        {
            var mlmover = other.collider.GetComponent<MLMover>();
            
            mlmover.SetReward(100);
            mlmover.EndEpisode();
            
        }
    }
}
