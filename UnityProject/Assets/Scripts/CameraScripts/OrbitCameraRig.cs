using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCameraRig : MonoBehaviour
{   

    public Transform thingToTarget;

    private float pitch = 0;
    private float yaw = 0;
    private float disToTarget = 10;
    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;
    public float scrollSensitivity = 1;

    private Camera cam;


    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        
    }

    void LateUpdate()
    {
        // Update Rotation-----------------
        float lookRight = Input.GetAxisRaw("Mouse X"); //yaw (Y)
        float lookUp = Input.GetAxisRaw("Mouse Y"); //pitch (X)

        yaw += lookRight * mouseSensitivityY;
        pitch -= lookUp * mouseSensitivityX;

        pitch = Mathf.Clamp(pitch, -89, 89);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);

        // Update Zoom------------------------
        Vector2 scrollAmt = Input.mouseScrollDelta;
        disToTarget += scrollAmt.y * scrollSensitivity;
        
        disToTarget = Mathf.Clamp(disToTarget, 5, 50);

        float z = animMath.Ease(cam.transform.localPosition.z, -disToTarget, .01f, Time.deltaTime);
        
        cam.transform.localPosition = new Vector3(0, 0, z);

        // Update Position--------------------
        if(thingToTarget == null) return;
        //transform.position = thingToTarget.position;

        transform.position = animMath.Ease(transform.position, thingToTarget.position, .001f, Time.deltaTime);
        
    }
}
