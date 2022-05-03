using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Porte : BaseActionnable
{
    [SerializeField] private XRGrabInteractable grab;
    public bool isHandling = false;
    public GameObject door;

    private void OnEnable()
    {
        grab.selectEntered.AddListener(FollowHandle);
        grab.selectExited.AddListener(ReleaseHandle);
    }
    
    private void OnDisable()
    {
        grab.selectEntered.RemoveListener(FollowHandle);
        grab.selectExited.RemoveListener(ReleaseHandle);
    }

    public void FollowHandle(SelectEnterEventArgs args)
    {
        transform.position = door.transform.position;
        isHandling = true;

    }
    
    public void ReleaseHandle(SelectExitEventArgs args)
    {
        
        isHandling = false;

    }

   
    
    
    
    
}
