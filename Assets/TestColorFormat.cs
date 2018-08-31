using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColorFormat : MonoBehaviour
{
    private void Start()
    {
        var color = new Color(0.1f, 0.1f, 0.1f);
        Debug.Log(ColorUtility.ToHtmlStringRGB(color));
    }
}
