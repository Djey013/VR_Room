using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet_switch : MonoBehaviour
{
    public GameObject[] wallArray = new GameObject[4];
    public Color[] Colors;
    public int indexCouleurSuivante =0;

    public void WallColorChange()
    {
        indexCouleurSuivante++; //indexcouleursuivante passe à la couleur suivante

        if (indexCouleurSuivante >= Colors.Length)
        {
            indexCouleurSuivante = 0;
        }

        for (int i = 0; i < wallArray.Length; i++)
        {
            wallArray[i].GetComponent<Renderer>().material.SetColor("_BaseColor", Colors[indexCouleurSuivante]);
        }
    }



}
