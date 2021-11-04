using UnityEngine;
using Random = UnityEngine.Random;


public class HitDetection: MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Object spawnedObject;

    public void OnTriggerStay2D(Collider2D collision)
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerLayer != (playerLayer | 1 << other.gameObject.layer)) return;
        Destroy(other.gameObject);
    }

    /*
    private void Relocate()
    {
        var offset = new Vector3(Random.Range(-10f, 10f), Random.RandomRange(-5f,5f));

        Collider2D player = Physics2D.OverlapCircle(transform.position + offset, 4f, playerLayer);

        if (player)
        {
            Vector3 distance = player.attachedRigidbody.position;
            distance = distance - transform.position;
            var offset = 4f - (distance - Vector2.);

        }
            
    }
    */
}

