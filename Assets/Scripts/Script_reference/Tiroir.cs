using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Tiroir : BaseActionnable
{
    private Vector3 _basePosition;
    private Quaternion _baseRotation;
    private float prevInteractorPosZ;

    private void Start()        //enregistrer la position et rotation de l'objet au debut de la scene
    {
        _basePosition = transform.position;
        _baseRotation = transform.rotation;
    }


    protected override void ActionContinue(Vector3 interactor)
    {
        base.ActionContinue(interactor);        //action de base du script BaseActionnable
                                                //auquels on rajoute des elements dans cette fonction (d'où "l'override")

        if (prevInteractorPosZ == 0f)           //determiner la position precedente de l'interactor en commencant par 0 à la 1ere frame
        {
            prevInteractorPosZ = interactor.z;
        }

        float delta = Mathf.Clamp(interactor.z - prevInteractorPosZ, -0.01f, 0.01f);    //creation d'un delta pour definir la distance de
                                                                                                    //deplacement du tiroir    

        prevInteractorPosZ = interactor.z;
        
        transform.rotation = _baseRotation; //verrouiller la rotation à chaque frame
        
        transform.position = new Vector3(_basePosition.x, _basePosition.y,
            Mathf.Clamp(transform.position.z + delta, _basePosition.z-0.60f,_basePosition.z));

    }


}
