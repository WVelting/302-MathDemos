using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;
    [Range(0,1)]
    public float percent = 0;


    
    void Start()
    {
        if(!pointA) return;
        transform.position = pointA.position;
    }


    void DoInterpolation()
    {
        if(!pointA || !pointB) return;
        Vector3 val = Vector3.Lerp(pointA.position, pointB.position, percent);

        //todo: set this object's position to the lerp result
        transform.position = val;

        //set the object's rotation
        Quaternion rot = Quaternion.Lerp(pointA.rotation, pointB.rotation, percent);
        transform.rotation = rot;


    }

    private void OnValidate()
    {
        DoInterpolation();

    }

}
