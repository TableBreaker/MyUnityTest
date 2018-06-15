using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGetComponent : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        // conclusion: return the TestDerivedClass
        Debug.Log(GetComponent<TestBaseClass>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
