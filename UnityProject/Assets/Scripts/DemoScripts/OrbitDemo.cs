using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitDemo : MonoBehaviour
{
    public Transform orbitCenter;

    private LineRenderer path;
    public float speed = 1;
    public int res = 32;

    public float radius = 10;

    void Start()
    {

        path = GetComponent<LineRenderer>();
        UpdateOrbitPath();
    }

    void Update()
    {
        if (!orbitCenter) return;
        float x = radius * Mathf.Cos(Time.time * speed);
        float z = radius * Mathf.Sin(Time.time * speed);

        transform.position = new Vector3(x, 0, z) + orbitCenter.position;

        if (orbitCenter.hasChanged) UpdateOrbitPath();
    }
    void UpdateOrbitPath()
    {
        if (!orbitCenter) return;



        Vector3[] pts = new Vector3[res];

        for (int i = 0; i < pts.Length; i++)
        {
            float x = radius * Mathf.Cos(i * 2 * Mathf.PI / res);
            float z = radius * Mathf.Sin(i * 2 * Mathf.PI / res);

            Vector3 pt = new Vector3(x, 0, z) + orbitCenter.position;
            pts[i] = pt;
        }

        path.positionCount = res;
        path.SetPositions(pts);


    }


}
