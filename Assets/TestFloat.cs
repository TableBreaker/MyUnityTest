using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFloat : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float v = 1f / 29f;
        float vm = v * 29f;
        float vl = v * 10000000000f;
        float vlm = vm * 10000000000;
        Debug.Log(vl * 29f + " " + vlm);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
