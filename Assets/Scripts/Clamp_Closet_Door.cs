using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Clamp_Closet_Door : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable grab;
    private GameObject interactorGo;
    private bool isUsingDoor = false;
    
   public float yValue = 90f;
   private Quaternion quat;

   private void OnEnable()
   {
       grab.selectEntered.AddListener(UsingDoor);
       grab.selectExited.AddListener(StopUsingDoor);
   }
   
   private void OnDisable()
   {
       grab.selectEntered.RemoveListener(UsingDoor);
       grab.selectExited.RemoveListener(StopUsingDoor);
   }

   private void UsingDoor(SelectEnterEventArgs args)
   {
       interactorGo = args.interactorObject.transform.gameObject;       //Stock l'objet qui utilise 
       isUsingDoor = true;      //true si on utilise la porte
   }

   private void StopUsingDoor(SelectExitEventArgs args)
   {
       isUsingDoor = false;     //False si on utilise plus la porte
       interactorGo = null;     //On dèstock l'objet qui utilise avec * = null *
   }

   private void Update()
   {
       
       if (isUsingDoor == true)  //si j'utilise la porte
       {
           //gameObject.transform.LookAt(new Vector3(interactorGo.transform.position.x,0f,interactorGo.transform.position.z)); //La porte regarde l'objet qui l'utilise
           gameObject.transform.LookAt(new Vector3(interactorGo.transform.position.x,0f,interactorGo.transform.position.z));
           
           //yValue = Mathf.Clamp(transform.eulerAngles.y, 0, 90);
           //quat = Quaternion.Euler(0f,yValue,0f);
           transform.rotation = Quaternion.Euler(0f,Mathf.Clamp(transform.eulerAngles.y,90,0),0f);
       }
   }
}
