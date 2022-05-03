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
    private Rigidbody _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        //interactable.selectEntered.AddListener(HoldingBall);
        interactable.selectExited.AddListener(BallVelocity);
    }

    private void OnDisable()
    {
        //interactable.selectEntered.RemoveListener(HoldingBall);
        interactable.selectExited.RemoveListener(BallVelocity);
    }
    
    private void BallVelocity(SelectExitEventArgs args)
    {
        _rb.AddForce(0f,0f,500);

    }
    
    

   
}
