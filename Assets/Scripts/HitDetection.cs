using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


public class HitDetection: MonoBehaviour
{
    [SerializeField] private LayerMask phantomLayer;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private UnityEvent OnDeath;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (phantomLayer != (phantomLayer | 1 << other.gameObject.layer)) return;
        if (other.IsTouchingLayers(playerLayer))
        {
			OnDeath?.Invoke();
            Destroy(transform.gameObject);
        }
    }
}

