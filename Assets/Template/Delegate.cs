using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegate : MonoBehaviour
{
    Func<int, int, string> sum_delegate = delegate (int a, int b) { return (a+b).ToString(); };
    Func<int, int, string> sum_lambda = (int a, int b)=>{ return (a+b).ToString(); };
    Func<int, int, string> sum_Function => Function;
    Func<int, int, string> sum_StaticFunction = StaticFunction;
    void Start()
    {
        Debug.Log("[Delegate]sum_delegate:"+sum_delegate(1, 2));
        Debug.Log("[Delegate]sum_lambda:"+sum_lambda(1, 2));
        Debug.Log("[Delegate]sum_Function:"+sum_Function(1, 2));
        Debug.Log("[Delegate]StaticFunction:"+StaticFunction(1, 2));
    }
    string Function(int a, int b)
    {
        return (a+b).ToString();
    }
    static string StaticFunction(int a, int b)
    {
        return (a+b).ToString();
    }
}
