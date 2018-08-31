using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTransformPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(transform.TransformPoint(Vector3.forward));
	}
}
