using System.Collections;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    private Item item { get; }
    [SerializeField] private LayerMask playerLayer;
    private bool isEntered;
    [SerializeField]private Object spawnedObject;
    [SerializeField]private Vector3 offset;
    [SerializeField] private Inventory target;
    private Object objectInstantie;
    private bool isUsed;

    public void OnTriggerStay2D(Collider2D collision)
    {
        isEntered = true;
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        isEntered = false;

    }

   public void Update()
    {
        if (Input.GetKeyDown("down") && isEntered && !isUsed)
        {
			AudioSource.PlayClipAtPoint(transform.GetComponent<AudioSource>().clip, transform.position);

            isUsed = true;

            objectInstantie = Instantiate(spawnedObject, transform.position, transform.rotation);
            target.AddBattery();

            StartCoroutine(WaitSecondsAndDestroy(objectInstantie));

        } 
    }

    public IEnumerator WaitSecondsAndDestroy(Object objet)
    {
        yield return new WaitForSeconds(3);
        Destroy(objet);


    }
}
