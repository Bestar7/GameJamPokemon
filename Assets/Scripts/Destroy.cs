using UnityEngine;
using UnityEngine.Events;

public class Destroy : MonoBehaviour
{
    [SerializeField] private UnityEvent OnDeath;

    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {

        OnDeath?.Invoke();
        Destroy(collision.gameObject);
    }
}
