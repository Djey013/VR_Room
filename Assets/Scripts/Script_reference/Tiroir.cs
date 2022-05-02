using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Tiroir : BaseActionnable
{
    private Vector3 _basePosition;
    private Quaternion _baseRotation;
    public GameObject _controllerposition;

    private void Start()        //enregistrer la position et rotation de l'objet au debut de la scene
    {
        _basePosition = transform.position;
        _baseRotation = transform.rotation;
    }


    protected override void ActionContinue(Vector3 interactor)
    {
        base.ActionContinue(interactor);        //action de base du script BaseActionnable
                                                //auquels on rajoute des element dans cette fonction (d'où "l'override")
        
        float delta = 0f;
        transform.rotation = _baseRotation;     //verrouiller la rotation à chaque frame
        transform.position = new Vector3(_basePosition.x, _basePosition.y,
            Mathf.Clamp(transform.position.z + delta, -0.60f, -1.20f));
        
        _controllerposition.transform.position = transform.position;
    }
    
    
}
