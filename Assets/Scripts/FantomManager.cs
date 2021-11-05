using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    [SerializeField] private float interval;
    [SerializeField] private Object spawnedObject;
    [SerializeField] private int max;
    [SerializeField] private float distance;

    private int count = 0;
    private LinkedList<Vector3> spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        Create();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CreateFantom()
    {
        while (count < max)
        {
            Vector3 vect = new Vector3(Random.Range(-25, 100), Random.Range(50, -10));
            vect = distance * vect.normalized;
            yield return new WaitForSeconds(interval);
            Instantiate(spawnedObject, vect, transform.rotation);
            count++;
        }
    }

    private void Create()
    {
        StartCoroutine(CreateFantom());
    }
}

