using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestEnum : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Debug.Log(Enum.IsDefined(typeof(ETest), 0));
        Debug.Log((ETest)5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool testBool;
}

public enum ETest
{
    A = 11,
    B = 1,
    C = 3,
}