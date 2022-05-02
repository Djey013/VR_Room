using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BaseActionnable : MonoBehaviour
{
    public XRSimpleInteractable interactable;
    public bool actionInstantanee = true;       //action instantanee = fonctionne sur le coup (ex: interrupteur).
                                                //non instantanee = reste fonctionnel > bouton selected toujours pressé (ex : tiroir)
    public bool isSelected = false;
    public Vector3 interactorPosition;

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(StartSelect);
        interactable.selectExited.AddListener(StopSelect);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(StartSelect);
        interactable.selectExited.RemoveListener(StopSelect);
    }

    protected void StartSelect(SelectEnterEventArgs args)
    {
        if (!actionInstantanee)
        {
            isSelected = true;
            interactorPosition = args.interactorObject.transform.position;
        }
        else
        {
            ActionInstant();
        }
    }
    
    protected void StopSelect(SelectExitEventArgs args)
    {
        if (!actionInstantanee)
        {
            isSelected = false;
            interactorPosition = Vector3.zero;
        }
    }

    protected virtual void ActionInstant()
    {
        
    }

    protected virtual void ActionContinue(Vector3 interactorPosition)
    {
        
    }

    private void Update()
    {
        if (isSelected)
        {
            ActionContinue(interactorPosition);

        }
    }
}
