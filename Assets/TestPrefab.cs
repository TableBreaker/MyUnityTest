using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var prefab = Resources.Load<GameObject>("TestPrefab");
        Instantiate(prefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
