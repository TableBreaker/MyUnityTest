using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPolymorphism : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        A para1 = new A();
        para1.Log();

        B para2 = new B();
        para2.Log();

        A para3 = new B();
        para3.Log();
	}


    private class A
    {
        public virtual void Log()
        {
            Debug.Log("AAA");
        }
    }

    private class B : A
    {
        public override void Log()
        {
            Debug.Log("BBB");
        }
    }
}
