using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TestGPUInstancing : MonoBehaviour
{
    private void Start()
    {
        var x = Random.Range(-15f, 15f);
        var y = Random.Range(-15f, 15f);
        var z = Random.Range(-15f, 15f);
        transform.position = new Vector3(x, y, z);
    }
}
