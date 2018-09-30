using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCorountine2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(TestCoroutine());
        }
	}

    private IEnumerator TestCoroutine()
    {
        var i = 0;
        while (i < 10)
        {
            Debug.Log(i);
            i++;
            yield return new WaitForSeconds(3f);
        }
    }
}
