using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonteCarlo : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        var totalCount = 1000000000;
        var count = 0;
	    for(var i = 0; i < totalCount; i++)
        {
            var x = Random.Range(0f, 1f);
            var y = Random.Range(0f, 1f);
            if (x * x + y * y <= 1f) count++;
        }

        var pi = count / (float)totalCount * 4;
        Debug.Log(pi);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
