using UnityEngine;
public class EventTester : MonoBehaviour
{
    void OnDisable()
    {
        Event.myEvent -= ReceivedEvent;
        Event.unityEvent -= ReceivedEvent;
    }
    void OnEnable()
    {
        Event.myEvent += ReceivedEvent;
        Event.unityEvent += ReceivedEvent;
    }
    void ReceivedEvent(string s)
    {
        Debug.Log("ReceivedEvent: " + s);
    }

}
