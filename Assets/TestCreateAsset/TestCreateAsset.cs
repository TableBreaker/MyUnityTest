using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestCreateAsset : Editor
{
    // asset cannot save when material asset name is pure negative number ？？？
    [MenuItem("Test/TestCreateAsset")]
    private static void TestCreate()
    {
        AssetDatabase.CreateAsset(new Material(Shader.Find("Standard")), "Assets/TestCreateAsset/" + -10 + ".mat");
    }
}
