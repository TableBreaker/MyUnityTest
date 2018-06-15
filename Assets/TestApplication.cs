using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestApplication : MonoBehaviour
{
    private void OnApplicationFocus(bool focus)
    {
        Debug.Log(focus);
    }

    private void OnApplicationQuit()
    {
        Debug.Log("quit");
    }
}
