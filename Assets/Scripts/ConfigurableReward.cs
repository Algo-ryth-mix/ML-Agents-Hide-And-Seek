using UnityEngine;

public class ConfigurableReward : MonoBehaviour
{
  [SerializeField] private float m_rewardAmount = 100f;

  private void OnCollisionEnter(Collision other)
  {
    if (other.collider.CompareTag("Actor"))
    {
      var mlmover = other.collider.GetComponent<MLMover>();
      
      mlmover.SetReward(m_rewardAmount);
      mlmover.EndEpisode();
    }
  }
}
