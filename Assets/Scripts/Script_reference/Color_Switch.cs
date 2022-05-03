using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Color_Switch : MonoBehaviour
{
    [SerializeField] XRSimpleInteractable interactable;
    private GameObject selector;
    public bool isHightLighted = false;
    private Color hightLightColor = Color.black;
    
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
    
    
    public void NotPointed(HoverExitEventArgs args)
    {
        selector = args.interactableObject.transform.gameObject;
        selector.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.black);
        //selector = null;
        isHightLighted = false;
        
    }
    
    public void Highlighted(HoverEnterEventArgs args)
    {
        selector = args.interactableObject.transform.gameObject;
        selector.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.yellow);
        isHightLighted = true;
    }
    
    
}
