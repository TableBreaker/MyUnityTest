using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCopyTo : MonoBehaviour
{
    private void Start()
    {
        var hash = new HashSet<TestCopytoClass>();

        for (var i = 0; i < 5; i++)
        {
            hash.Add(new TestCopytoClass { IntV = i });
        }

        hash.CopyTo(array);

        foreach(var v in array)
        {
            if (v == null) continue;
            Debug.Log(v.IntV);
        }

        hash = new HashSet<TestCopytoClass>();
        for (var i = 0; i < 4; i++)
        {
            hash.Add(new TestCopytoClass { IntV = i + 1 });
        }
        hash.CopyTo(array);

        foreach (var v in array)
        {
            if (v == null) continue;
            Debug.Log(v.IntV);
        }
    }


    public class TestCopytoClass
    {
        public int IntV = 1;
    }

    private TestCopytoClass[] array = new TestCopytoClass[100];
}
