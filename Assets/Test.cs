using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    TestJob tjob = null;

    private IEnumerator Start()
    {
        Debug.Log(Time.time);
        tjob = new TestJob();
        tjob.Start();
        yield return StartCoroutine(tjob.WaitFor());
        tjob = null;
    }

    private void OnApplicationQuit()
    {
        if (tjob != null && !tjob.IsDone)
        {
            tjob.Abort();
        }
    }
}
