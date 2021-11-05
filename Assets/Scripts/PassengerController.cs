using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PassengerController : MonoBehaviour
{
    
    private bool isEntered;
    // Start is called before the first frame update

    public void Start()
    {
        
    }

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
        if (Input.GetKeyDown("up") && isEntered)
        {

            Debug.Log("Je dans la porte mon gars !");
        }
    }


    private void Next()
    {

    }

    private void Previous()
    {

    }
}
