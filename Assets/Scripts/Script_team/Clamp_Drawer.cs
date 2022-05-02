using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp_Drawer : MonoBehaviour
{
    private float zValue = 0f;
    
    private void Update()
    {
        zValue = Mathf.Clamp(transform.position.z, 0.75f, 1.29f);
        transform.position = new Vector3(transform.position.x, transform.position.y, zValue);
    }
}
