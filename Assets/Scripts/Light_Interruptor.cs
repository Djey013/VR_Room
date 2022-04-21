using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Light_Interruptor : MonoBehaviour
{
    public GameObject directionalLight;
    private int i = 1;

    public XRSimpleInteractable _selected;

    private void OnEnable()
    {
        _selected.selectEntered.AddListener(SwitchLight);
    }

    private void OnDisable()
    {
        _selected.selectEntered.RemoveListener(SwitchLight);
    }

    public void SwitchLight(SelectEnterEventArgs args)
    {
        if (i == 1) //1 = allumé     0 = eteint
        {
            LightOFF();
            i = 0;
        }
        else
        {
            LightON();
            i = 1;
        }

    }

    public void LightON()
    {
        directionalLight.GetComponent<Light>().enabled = true;

    }



    public void LightOFF()
    {
        directionalLight.GetComponent<Light>().enabled = false;
        
    }

}
