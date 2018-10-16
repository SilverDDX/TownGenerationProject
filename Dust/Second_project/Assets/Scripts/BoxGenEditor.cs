using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Generation;

[CustomEditor(typeof (BoxGen))]
public class BoxGenEditor : Editor {

   

    public override void OnInspectorGUI()
    {
        //target Boxgen script for access
        BoxGen cube_creation = (BoxGen)target;
        DrawDefaultInspector();

        //space
        GUILayout.Space(10);

        //Create a box with name and position

        if (GUILayout.Button("Generate"))
        {
            cube_creation.genCube(cube_creation.name, cube_creation.initPos, cube_creation.width, cube_creation.height);

        }

        if (GUILayout.Button("Random Generation"))
        {

            cube_creation.randBoxGen();

        }

    }

}
