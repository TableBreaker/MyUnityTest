using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class TestPostProcessing : MonoBehaviour
{
    private void Start()
    {
        var shader = Shader.Find("Hidden/TestPostProcessing");
        _processingMat = new Material(shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        
        Graphics.Blit(source, destination, _processingMat);
    }

    private Material _processingMat;
}
