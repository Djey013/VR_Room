using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Clamp_Closet_Door : MonoBehaviour
{
    
   private float yValue = 0f;
   private Quaternion quat;
    
    private void Update()
    {
        
        yValue = Mathf.Clamp(transform.eulerAngles.y, -90f, 0f);
        quat = Quaternion.Euler(0f,yValue,0f);
        transform.rotation = quat;
    }
    
}
