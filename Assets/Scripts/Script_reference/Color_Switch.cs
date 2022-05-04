using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Color_Switch : MonoBehaviour
{
    [SerializeField] XRGrabInteractable interactable;
    public bool isHightLighted = false;

    public Color colorBase;
    public GameObject hightLightedGameObject;
    
    
    private void OnEnable()
    {
        interactable.hoverEntered.AddListener(Highlighted);
        interactable.hoverExited.AddListener(NotPointed);
    }

    private void OnDisable()
    {
        interactable.hoverEntered.RemoveListener(Highlighted);
        interactable.hoverExited.RemoveListener(NotPointed);
    }

    private void Start()
    {
        colorBase = hightLightedGameObject.GetComponent<Renderer>().material.GetColor("_BaseColor");
        
    }

    public void NotPointed(HoverExitEventArgs args)
    {
        
        hightLightedGameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", colorBase);
        
        //selector = null;
        isHightLighted = false;
        
    }
    
    public void Highlighted(HoverEnterEventArgs args)
    {
        
        hightLightedGameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.yellow);
        
        isHightLighted = true;
        
    }
    
    
}
