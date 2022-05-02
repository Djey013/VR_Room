using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Ball : BaseActionnable
{
    //public XRSimpleInteractable interactable;
    public bool isUsingBall = false;
    private GameObject interactorGo;
    
    private void OnEnable()
    {
        interactable.selectEntered.AddListener(HoldingBall);
        interactable.selectExited.AddListener(StopHoldingBall);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(HoldingBall);
        interactable.selectExited.RemoveListener(StopHoldingBall);
    }
    
    private void HoldingBall(SelectEnterEventArgs args)
    {
        interactorGo = args.interactorObject.transform.gameObject;
        isUsingBall = true;

    }
    
    private void StopHoldingBall(SelectExitEventArgs args)
    {
        isUsingBall = false;
        interactorGo = null;
        
    }

    private void Update()
    {
        if (isUsingBall == true)
        {
            gameObject.transform.position = interactorGo.transform.position;
        }
    }
}
