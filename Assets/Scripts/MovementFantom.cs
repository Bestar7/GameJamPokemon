using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class MovementFantom: MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        if(target)
            Move();
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


}