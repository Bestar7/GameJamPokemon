using UnityEngine;
using UnityEngine.UI;

public class ImageValue : MonoBehaviour
{
    [SerializeField] Image i;
    [SerializeField] Sprite fullPower;
    [SerializeField] Sprite seventyPower;
    [SerializeField] Sprite halfPower;
    [SerializeField] Sprite lowPower;
    [SerializeField] Sprite noPower;
    // Start is called before the first frame update
    public void UpdateImage(float valueFlashLight)
    {
       
       if(valueFlashLight<=100 && valueFlashLight >=75)
            i.sprite = fullPower;
        if (valueFlashLight < 75 && valueFlashLight >= 50)
            i.sprite = seventyPower;
        if (valueFlashLight < 50 && valueFlashLight >= 25)
            i.sprite = halfPower;
        if (valueFlashLight < 25 && valueFlashLight >= 0)
            i.sprite = lowPower;
        if (valueFlashLight <= 0)
            i.sprite = noPower;
    }
}
