using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TestProjectionMatrix : MonoBehaviour
{
    private void OnEnable ()
    {
        Debug.Log(transform.localToWorldMatrix);
        var worldPos = transform.localToWorldMatrix.MultiplyPoint(Vector3.zero);
        Debug.Log(worldPos);

        Debug.Log(Camera.main.worldToCameraMatrix);
        var viewPos = Camera.main.worldToCameraMatrix.MultiplyPoint(transform.position);
        Debug.Log(viewPos);

        Debug.Log(Camera.main.projectionMatrix);
        var clipPos = Camera.main.projectionMatrix.MultiplyPoint(viewPos);
        Debug.Log(clipPos);
	}
	
	// Update is called once per frame
	private void Update () {
		
	}
}
