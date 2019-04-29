using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Collections;

public class TestMoveSystem : JobComponentSystem
{
    [BurstCompile]
    private struct TestMoveJob : IJobProcessComponentData<Position, TestMove>
    {
        public float dt;

        public void Execute(ref Position position, [ReadOnly] ref TestMove move)
        {
            position.Value += move.speed * dt;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new TestMoveJob
        {
            dt = Time.deltaTime,
        };

        var handle = job.Schedule(this, inputDeps);
        return handle;
    }
} 