using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CubicCurveDemo : MonoBehaviour
{
    public Transform StartPoint;
    public Transform ControlStart;
    public Transform EndPoint;
    public Transform ControlEnd;
    private bool isPlaying;
    private float TweenCurrent;
    private float TweenLength = 3;
    public AnimationCurve temoralEasing;


    [Range(2,100)]
    public int curveRes = 10;
    void Start()
    {
        
    }

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
        Gizmos.DrawCube(ControlStart.position, Vector3.one);


        for(int i = 0; i < curveRes; i++){
            Vector3 a = FindPointOnCurve(i/(float)curveRes);
            Vector3 b = FindPointOnCurve((i+1)/(float)curveRes);
            Gizmos.DrawLine(a,b);
        }

        
    }

    Vector3 FindPointOnCurve(float percent){
        //A - find pt between: start control, end control
        Vector3 a = animMath.Lerp(ControlStart.position, ControlEnd.position, percent);

        //B - find pt between: start anchor, start control
        Vector3 b = animMath.Lerp(StartPoint.position, ControlStart.position, percent);

        //C - find pt between: end control, end anchor
        Vector3 c = animMath.Lerp(ControlEnd.position, EndPoint.position, percent);

        //D - find pt between A, B
        Vector3 d = animMath.Lerp(b, a, percent);

        //E - Find pt between A, C
        Vector3 e = animMath.Lerp(a, c, percent);

        //F - Find pt between D, E
        return animMath.Lerp(d, e, percent);

    }
}

[CustomEditor(typeof(CubicCurveDemo))]
public class CubicDemoEditor : Editor{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Play Tween"))(target as CubicCurveDemo).PlayTween(true);
    }
}

