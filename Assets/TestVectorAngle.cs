using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVectorAngle : MonoBehaviour
{
    public Vector3 TestVec;

    private void Update()
    {
        Debug.Log(DirToHitDir(TestVec));
    }

    private int DirToHitDir(Vector3 dir)
    {
        var angle = Vector3.SignedAngle(dir, Vector3.right, -Vector3.forward);
        Debug.Log(angle);
        angle = angle > 0f ? angle : angle + 360f;
        return ((int)(angle + 22.5f) / 45) % 8;
    }
}
