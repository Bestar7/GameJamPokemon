using System.Collections;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private float batteryLeft;
    [SerializeField] private float WaintingTimePerCharge;
    [SerializeField] private float pourcentFlashLight;
	public bool isFlashLightOn;
	[SerializeField] private FlashLightEvent OnChangeFlashLight;
    [SerializeField] private BatteryEvent OnBatteryEvent;

	public void Start()
    {
		batteryLeft = PlayerPrefs.GetFloat("batteryLeft", 3);
		pourcentFlashLight = PlayerPrefs.GetFloat("pourcentFlashLight", 100);
		Debug.Log("first start");
		// on met 100% de batterie uniquement si le joueur commence avec des batteries et sans energie présente
		if (pourcentFlashLight == 0 && batteryLeft >= 1) 
		{
			batteryLeft--;
			pourcentFlashLight = 100;
		}
        StartCoroutine(DecreaseFlashLight(WaintingTimePerCharge));
    }

	private void Update()
	{	
		// Plus la capacité de trouver une solution plus propre, trop fatigué, issou
		//PlayerPrefs.SetFloat("batteryLeft", batteryLeft);
		//PlayerPrefs.SetFloat("pourcentFlashLight", pourcentFlashLight);
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

    private IEnumerator DecreaseFlashLight(float wainting)
    {
        
        while (true)
        {
            if (isFlashLightOn && batteryLeft >= 0)
            {
                
                pourcentFlashLight--;
                OnChangeFlashLight?.Invoke(pourcentFlashLight);
                OnBatteryEvent?.Invoke(batteryLeft);
                
                if (pourcentFlashLight <= 0 && batteryLeft > 0)
                    ReloadFlashLight();
                if (pourcentFlashLight <= 0 && batteryLeft <= 0)
                    isFlashLightOn = false;
            }
            yield return new WaitForSeconds(wainting);
        }
    }

	private void ReloadFlashLight()
    {
        batteryLeft--;
        pourcentFlashLight = 100;
    }
}

