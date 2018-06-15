using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFindObjects : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var prefab = Resources.Load<TestFindObjects>("TestFindObjects");
            var inst = Instantiate(prefab);
            var objs = FindObjectsOfType<TestFindObjects>();
            Debug.Log(objs.Length);
        }
    }
}
