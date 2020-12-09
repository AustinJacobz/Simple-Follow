using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Simple_Follow))]
public class Simple_FollowEditor : Editor
{
    public override void OnInspectorGUI() //Makes a UI element.
    {
        DrawDefaultInspector();

        Simple_Follow myTarget = (Simple_Follow)target; //Gets target
        if(GUILayout.Button("Get Offset"))
        {
            myTarget.offset = myTarget.transform.position - myTarget.target.position; //Gets offset for you.
        }
    }
}
