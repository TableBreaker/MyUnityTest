using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using System;

[Serializable]
public struct TestMove : IComponentData
{
    public float3 speed;
}

[DisallowMultipleComponent]
public class TestMoveProxy : ComponentDataProxy<TestMove> { }