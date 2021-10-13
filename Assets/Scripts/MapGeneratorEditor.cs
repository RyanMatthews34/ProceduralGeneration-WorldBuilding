using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*
 * This class is used add functionality to our editor for the map generator.
 * currently allowing us to auto generate terrain when variables have been adjusted.
 */
[CustomEditor (typeof (MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target;

        if (DrawDefaultInspector())
        {
            if (mapGen.autoUpdate)
            {
                mapGen.GenerateMap();
            }
        }         

        if(GUILayout.Button ("Generate"))
        {
            mapGen.GenerateMap ();
        }
    }
}