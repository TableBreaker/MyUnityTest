using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimeScale : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0.01f;
    }

    private void Update()
    {
//         Debug.Log(Time.deltaTime);
//         Debug.Log("Update");
    }

    private void FixedUpdate()
    {
        Debug.Log(Time.fixedDeltaTime);
        Debug.Log("FixedUpdate");
    }
}
