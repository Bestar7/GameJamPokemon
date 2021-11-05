using TMPro;
using UnityEngine;

public class TextValue : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void UpdateText(float intValue)
    {
        text.text = intValue.ToString();
    }
}