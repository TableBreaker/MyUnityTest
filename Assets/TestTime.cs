using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Time.time);
            Debug.Log(Time.realtimeSinceStartup);
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = 0.5f;
        }
	}
}
