using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2DArray : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        var arr = new float[3, 2];
        Debug.Log(arr[2, 1]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
