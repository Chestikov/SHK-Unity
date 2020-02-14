using UnityEngine;

public class SpeedBonus : MonoBehaviour
{
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _duration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.AddSpeedBonus(_speedMultiplier, _duration);
            Destroy(gameObject);
        }
    }
}
