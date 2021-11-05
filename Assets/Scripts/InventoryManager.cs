using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonBehaviour<InventoryManager>
{
    [SerializeField] private FlashLightEvent OnFlash;
    [SerializeField] private BatteryEvent OnBattery;

  
    protected override void Awake()
    {
        base.Awake();
       
    }

    public void GainScore(int value)
    {
       
    }
}
