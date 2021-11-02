using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowFuel : MonoBehaviour
{
    public TextMeshProUGUI textUI;

    // Start is called before the first frame update
    void Start()
    {
        textUI.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowFuelOnScreen(float mass)
    {
        float newFuel = (int)Scale(1, 2, 0, 100, mass);
        textUI.text = newFuel.ToString();
    }

    public float Scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }
}
