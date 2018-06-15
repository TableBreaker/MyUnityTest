using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDictionarySync : MonoBehaviour {

    class Test
    {
        public int val = 20;
    }

	// Use this for initialization
	void Start () {
        var dic = new Dictionary<int, int>
        {
            {1, 1},
            {2, 3},
            {3, 5},
        };

        var set = new HashSet<Test>
        {
            new Test(),
            new Test()
        };


        //--------------- RIGHT
        var keys = new List<int>(dic.Keys);
        foreach (var key in keys)
        {
            dic[key] -= 1;
        }

        // ----------- WRONG!
        //foreach (var key in dic.Keys)
        //{
        //    dic[key] -= 1;
        //}

        // ------------------RIGHT
        foreach (var t in set)
        {
            t.val -= 10;
        }

        foreach (var t in set)
        {
            Debug.Log(t.val);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
