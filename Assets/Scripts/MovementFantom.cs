using UnityEngine;


public class MovementFantom: MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    [SerializeField] private LayerMask layerFlash;



    private bool _canMove = true;

    // Update is called once per frame
    void Update()
    {
        if(_canMove && target)
        {
            Move();
        }
    }

    private void Start()
    {
    }

    private void Move()
    {
        Vector3 dir;
        dir = target.position - transform.position;
        var newPos = transform.position;
        newPos += dir.normalized * Time.deltaTime * speed;
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (layerFlash != (layerFlash | 1 << other.gameObject.layer)) return;
        _canMove = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (layerFlash != (layerFlash | 1 << other.gameObject.layer)) return;
        _canMove = true;
    }

}