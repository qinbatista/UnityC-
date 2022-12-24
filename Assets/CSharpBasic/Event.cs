using System;
using UnityEngine;
public class Event : MonoBehaviour
{
    //define my own event
    public delegate void MyAction(string s);
    public static event MyAction myEvent;
    //unity event
    public static event Action<string> unityEvent;
    void Start()
    {
        myEvent("s_myEvent");
        myEvent?.Invoke("s_myEvent");
        unityEvent("s_unityEvent");
        unityEvent?.Invoke("s_unityEvent");
    }
}
