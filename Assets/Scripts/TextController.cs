using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject obj;
    private bool isEntered;
   
    public void Start()
    {
        obj.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerLayer != (playerLayer | 1 << collision.gameObject.layer)) return;
        obj.SetActive(true);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        obj.SetActive(false);


    }
}
