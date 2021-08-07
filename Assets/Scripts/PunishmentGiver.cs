using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunishmentGiver : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Actor"))
        {
            var mlmover = other.collider.GetComponent<MLMover>();
            
            mlmover.SetReward(-100f);
            mlmover.EndEpisode();
            
        }
    }
}
