using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : BaseActionnable
{
    public GameObject light;
    public GameObject lightObject;
    
    protected override void ActionInstant()
    {
        base.ActionInstant();
        if (light.activeInHierarchy)
        {
            light.SetActive(false);
            lightObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                

        }
        else
        {
            light.SetActive(true);
            lightObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
    }
}
