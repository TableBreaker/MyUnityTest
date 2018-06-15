using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRenderReplacement : MonoBehaviour
{
    public Shader TargetShader;

    private void Start()
    {
        if (TargetShader == null) return;

        Camera.main.SetReplacementShader(TargetShader, "RenderType");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Camera.main.ResetReplacementShader();
        }
    }
}
