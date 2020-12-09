using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(FollowTarget))]
public class Simple_FollowEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        FollowTarget myTarget = (FollowTarget)target;
        if(GUILayout.Button("Get Offset"))
        {
            Vector3 newOffset = myTarget.transform.position - myTarget.target.position;
            myTarget.offset = newOffset;
        }
    }
}
