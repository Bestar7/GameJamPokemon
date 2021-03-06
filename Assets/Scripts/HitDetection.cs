using UnityEngine;
using UnityEngine.Events;


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
            AudioSource.PlayClipAtPoint(transform.GetComponent<AudioSource>().clip,transform.position);
			OnDeath?.Invoke();
            Destroy(transform.gameObject);
        }
    }
}

