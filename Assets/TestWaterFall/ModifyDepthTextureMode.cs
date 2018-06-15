using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ModifyDepthTextureMode : MonoBehaviour
{
    public DepthTextureMode Mode;

    private void Start()
    {
        GetComponent<Camera>().depthTextureMode = Mode;
    }

    void OnDrawGizmo()
    {
        if (SceneView.lastActiveSceneView.camera.depthTextureMode == DepthTextureMode.None)
        {
            SceneView.lastActiveSceneView.camera.depthTextureMode = DepthTextureMode.Depth;
        }
    }

}