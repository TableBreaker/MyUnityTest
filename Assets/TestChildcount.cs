using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChildcount : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        go = new GameObject("parent");
        var ch1 = new GameObject("child");
        ch1.transform.parent = go.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            var ch1 = go.transform.Find("child");
            Destroy(ch1.gameObject);
            Debug.Log(go.transform.childCount);
        }
	}

    private GameObject go;
}
