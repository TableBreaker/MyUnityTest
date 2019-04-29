using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class TestUnityECS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var move = gameObject.AddComponent<TestMoveProxy>();
        move.Value = new TestMove
        {
            speed = new float3(1f, float2.zero),
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
