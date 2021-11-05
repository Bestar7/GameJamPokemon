﻿
using System;
using System.Collections;
using UnityEngine;

public class Inventary : MonoBehaviour
{
    [SerializeField] private int batteryLeft;
    [SerializeField] private int speedDecreaseBySec;
    [SerializeField] private float pourcentFlashLight;
    public bool isFlashLightOn;

      public void Start()
    {
        pourcentFlashLight = 100;
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
        while (true)
        {
            
            if (isFlashLightOn && batteryLeft >= 0)
            {
                pourcentFlashLight--;

                if (pourcentFlashLight <= 0 && batteryLeft > 0)
                {
                  
                    ReloadFlashLight();
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
        batteryLeft--;
        pourcentFlashLight = 100;
    }


}