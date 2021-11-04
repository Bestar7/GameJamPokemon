using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomManager : MonoBehaviour
{

    [SerializeField] private float interval;
    [SerializeField] private Object spawnedObject;
    [SerializeField] private int max;

    private int count = 0;
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
            yield return new WaitForSeconds(interval);
            Instantiate(spawnedObject, new Vector3(Random.Range(-5f, 5f), 76), transform.rotation);
            count++;
        }
    }

    private void Create()
    {
        StartCoroutine(CreateFantom());
    }
}

