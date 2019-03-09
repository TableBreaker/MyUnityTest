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
	void Start ()
    {
        //_test.a = 1;
        //Debug.Log(_test.a);
        //_test2.a = 2;
        //Debug.Log(_test2.a);

        var a = test_1;
        a.x = 3f;
        Debug.Log(test_1.x);

        a = test_2;
        a.x = 4f;
        Debug.Log(test_2.x);

        var b = particle.main;
        b.startSizeMultiplier = 3.53f;
        Debug.Log(particle.main.startSizeMultiplier);

        var testP = new TestParticle();
        var cb = testP.TestMainModule;
        cb.TestSize = 4.23f;
        Debug.Log(testP.TestMainModule.TestSize);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private Vector3 test_1 { get; set; }
    private Vector3 test_2 { get; }

    public ParticleSystem particle;

    private class TestParticle
    {
        public TestModule TestMainModule { get; }
    }

    private struct TestModule
    {
        public float TestSize;
    }
}
