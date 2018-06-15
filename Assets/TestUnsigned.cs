using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUnsigned : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        int x = 2;
        uint y = 4;
        int z = (int)(x - y);
        Debug.Log(z);

        var w = -10;
        Debug.Log((uint)w);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
