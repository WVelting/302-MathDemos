using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuadraticDemo : MonoBehaviour
{

    public Transform StartPoint;
    public Transform EndPoint;
    public Transform ControlPoint;
    
    [Range(2,100)]
    public int curveRes = 10;

    public AnimationCurve temoralEasing;


    private bool isPlaying = false;

    public float TweenLength = 3;
    private float TweenCurrent = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isPlaying)TweenCurrent += Time.deltaTime;

        float p = TweenCurrent/TweenLength;
        p = Mathf.Clamp(p, 0, 1);

        p = temoralEasing.Evaluate(p);

        Vector3 pos = FindPointOnCurve(p);

        transform.position = pos;
        if(TweenCurrent >= TweenLength) isPlaying = false;

        
    }

    public void PlayTween(bool fromBeginning = false){
        isPlaying = true;
        if(fromBeginning) TweenCurrent = 0;
    }

    void OnDrawGizmos(){
        Gizmos.DrawCube(ControlPoint.position, Vector3.one);


        for(int i = 0; i < curveRes; i++){
            Vector3 a = FindPointOnCurve(i/(float)curveRes);
            Vector3 b = FindPointOnCurve((i+1)/(float)curveRes);
            Gizmos.DrawLine(a,b);
        }

        
    }

    Vector3 FindPointOnCurve(float percent){

        Vector3 a = animMath.Lerp(StartPoint.position, ControlPoint.position, percent);
        Vector3 b = animMath.Lerp(ControlPoint.position, EndPoint.position, percent);

        return animMath.Lerp(a, b, percent);
        

    }
}

[CustomEditor(typeof(QuadraticDemo))]
public class QuadraticDemoEditor : Editor{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Play Tween"))(target as QuadraticDemo).PlayTween(true);
    }
}
