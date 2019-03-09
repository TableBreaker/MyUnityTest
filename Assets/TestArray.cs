using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArray : MonoBehaviour
{
    private struct TestComponent
    {
        public int value;
    }

    private class TestClass
    {
        public int value;
    }

    // Use this for initialization
    void Start()
    {
        var arr = new TestComponent[199];
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i].value = i;
        }

        // error
        var arr2 = new TestClass[199];
        for (var i = 0; i < arr2.Length; i++)
        {
            arr2[i].value = i;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
