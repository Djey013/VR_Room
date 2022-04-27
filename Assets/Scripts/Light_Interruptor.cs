using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Light_Interruptor : MonoBehaviour
{
    public GameObject directionalLight;
    public int i = 1;
    public Material lightOff;
    public Material lightOn;
    public GameObject lampe;

    public XRSimpleInteractable selected;

    private void OnEnable()
    {
        selected.selectEntered.AddListener(SwitchLight);
    }

    private void OnDisable()
    {
        selected.selectEntered.RemoveListener(SwitchLight);
    }

    public void SwitchLight(SelectEnterEventArgs args)
    {
        print("enter switchlight");
        if (i == 1) //1 = allumé     0 = eteint
        {
            LightOFF();
            print("light offed");
            i = 0;
        }
        else
        {
            LightON();
            print("light oned");
            i = 1;
        }
    }

    public void LightON()
    {
        directionalLight.GetComponent<Light>().enabled = true;
        lampe.GetComponent<Renderer>().material = lightOn;
    }
    
    public void LightOFF()
    {
        directionalLight.GetComponent<Light>().enabled = false;
        lampe.GetComponent<Renderer>().material = lightOff;

    }
}
