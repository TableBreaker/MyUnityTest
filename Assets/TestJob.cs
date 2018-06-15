using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJob : ThreadJob
{
    protected override void ThreadFunction()
    {
        var val = 1L;
        for (var i = 0L; i < 10000000000; i++)
        {
            val += val % (i + 1);
        }
    }

    protected override void OnFinished()
    {
        Debug.Log(Time.time);
    }
}
