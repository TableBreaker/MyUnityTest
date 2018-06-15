using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Linq;
using System;

public class TestPlugins : MonoBehaviour
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void myFunc(int i);

    [DllImport("serverproxy", EntryPoint = "main")]
    public static extern int main();

    [DllImport("serverproxy", EntryPoint = "init")]
    public static extern bool init();

    [DllImport("serverproxy", EntryPoint = "setfunction")]
    public static extern bool setfunction(myFunc func);

    [DllImport("serverproxy", EntryPoint = "dofunc")]
    public static extern bool dofunc();

    public int[] a = { 3, 5, 6, 2, 1, 7, 3, 7, 8 };

    private void Start()
    {
        init();
        setfunction(null);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(main());
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            dofunc();
        }
    }

    private void OnApplicationQuit()
    {
    }

    private void MyFunction(int counter)
    {
        Debug.Log(counter * counter);
    }
}
