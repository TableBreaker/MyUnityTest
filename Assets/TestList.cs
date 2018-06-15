using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestList : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var list = new List<int> { 1, 2, 3 };
        Debug.Log(list.FindAll(t => t == 4).Count);
        print("`111");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
