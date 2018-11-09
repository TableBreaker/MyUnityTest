using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDeltaAngle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // [-180, 180]
        Debug.Log(Mathf.DeltaAngle(Camera.main.transform.eulerAngles.y, transform.eulerAngles.y));
	}
}
