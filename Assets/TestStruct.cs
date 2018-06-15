using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStruct : MonoBehaviour {

    struct test
    {
        public int a;
    }

    class test2
    {
        public int a;
    }

    test _test;
    test2 _test2;

	// Use this for initialization
	void Start () {
        _test.a = 1;
        Debug.Log(_test.a);
        _test2.a = 2;
        Debug.Log(_test2.a);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
