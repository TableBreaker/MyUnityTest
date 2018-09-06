using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVectorAngle : MonoBehaviour
{
    public Vector3 TestVec;

    private void Update()
    {
        Debug.Log(Vector3.SignedAngle(Vector3.right, TestVec, Vector3.forward));
    }
}
