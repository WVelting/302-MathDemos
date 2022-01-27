using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCameraRig : MonoBehaviour
{

    public Transform target;

    public float desiredDistance = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 vToTarget = target.position - transform.position;
        // Update Position--------------------
        Vector3 targetPosition = -vToTarget;
        targetPosition.Normalize();
        targetPosition*=desiredDistance;

        targetPosition += target.position;

        transform.position = animMath.Ease(transform.position, targetPosition, .01f, Time.deltaTime);


        // Update Rotation--------------------


        transform.rotation = Quaternion.LookRotation(vToTarget, Vector3.up);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 5f);
    }
}
