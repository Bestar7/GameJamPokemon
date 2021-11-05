using System.Collections;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private float batteryLeft;
    [SerializeField] private int speedDecreaseBySec;
    [SerializeField] private float pourcentFlashLight;
    public bool isFlashLightOn;
    [SerializeField] private FlashLightEvent OnChangeFlashLight;
    [SerializeField] private BatteryEvent OnBatteryEvent;

    public void Start()
    {
        Debug.Log("first start");
		// on met 100% de batterie uniquement si le joueur commence avec des batteries et sans energie présente
		if (pourcentFlashLight == 0 && batteryLeft >= 1) 
		{
			batteryLeft--;
			pourcentFlashLight = 100;
		}
        StartCoroutine(DecreaseFlashLight(speedDecreaseBySec));
    }

   

    public void AddBattery()
    {
        if(batteryLeft <= 3)
        {
            batteryLeft++;
        }
    }



    public bool CanStartFlashLight()
    {
        return (batteryLeft > 0 || pourcentFlashLight > 0);
    }

    public IEnumerator DecreaseFlashLight(int speed)
    {
        Debug.Log("Starting Coroutine");
        while (true)
        {
            Debug.Log("tourning Coroutine");
            if (isFlashLightOn && batteryLeft >= 0)
            {
                Debug.Log(pourcentFlashLight);
                pourcentFlashLight--;
                OnChangeFlashLight?.Invoke(pourcentFlashLight);
                OnBatteryEvent?.Invoke(batteryLeft);
                Debug.Log("Double Invoke");
                if (pourcentFlashLight <= 0 && batteryLeft > 0)
                {
                  
                    ReloadFlashLight();

                    Debug.Log("Reloaded Coroutine");


                }
                if (pourcentFlashLight <= 0 && batteryLeft <= 0)
                {
                    isFlashLightOn = false;
                }
            }
            yield return new WaitForSeconds(speed);

        }
    }

    public void ReloadFlashLight()
    {
        Debug.Log("Reloaded");
        batteryLeft--;
        pourcentFlashLight = 100;
    }


}

