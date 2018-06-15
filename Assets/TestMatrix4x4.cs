using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix4x4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Test();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Test()
    {
        var matrix = Matrix4x4.identity;
        matrix.SetTRS(translation, Quaternion.Euler(angle), Vector3.one);
        Debug.Log(transform.localToWorldMatrix * matrix);

        matrix = Matrix4x4.TRS(transform.TransformPoint(translation), transform.rotation * Quaternion.Euler(angle), Vector3.one);
        Debug.Log(matrix);
        
    }

    private Vector3 translation = Vector3.forward;
    private Vector3 angle = new Vector3(50, 100, 40);
}
