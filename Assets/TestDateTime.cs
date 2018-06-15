using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestDateTime : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            var tick = DateTime.Now.Ticks;
            long ticks = 1;
            for (var i = 0; i < 10000000; i++)
            {
                ticks = DateTime.Now.Ticks;
            }
            Debug.Log((DateTime.Now.Ticks - tick) / TimeSpan.TicksPerMillisecond);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            var tick = DateTime.Now.Ticks;
            long ticks = 1;
            for (var i = 0; i < 10000000; i++)
            {
                ticks += (long)(Time.deltaTime * TimeSpan.TicksPerSecond);
            }
            Debug.Log((DateTime.Now.Ticks - tick) / TimeSpan.TicksPerMillisecond);
        }
    }
}
