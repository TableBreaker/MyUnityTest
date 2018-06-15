using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestCoroutine : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
//         co = StartCoroutine(corou());
        Debug.Log(a);
        a += Update;
        Debug.Log(a);
        a -= Update;
        Debug.Log(a);

        float b, c, d;
        c = 0f;
        d = 0f;
        
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(co);
            Debug.Log(co);
        }
	}

    private IEnumerator corou()
    {
        Debug.Log("111");
        yield return new WaitForSeconds(5f);
        Debug.Log("222");
    }

    private Coroutine co;
    private Action a;
}
