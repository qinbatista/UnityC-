# C# version 1.0
## Class
* Allocate memory for this class, the class contains different data structures, and it can be inherited or inherent.
* Give class to another parameter equal **reference**

>### Singleton

``` CSharp

using UnityEngine;
public abstract class Singleton<T> : Singleton where T : Singleton<T>
{
    static T _instance;
    public static T Instance { get => _instance; set => _instance = value; }
    public virtual void Awake()
    {
        if (_instance != null) { Destroy(gameObject); } else { _instance = (T)this; }
    }
    public virtual void OnDestroy()
    {
        // Debug.Log("OnDestroy T="+typeof(T));
        _instance = null;
    }
}
public abstract class Singleton : MonoBehaviour
{

}
```
## Structs
* allocate memory for these Structs, give structs to another parameter equal **give value**
* used for giving a bunch of values, it can simplify codes, and avoid using ``void Function(int value1, int value2, int value3, ....)`` instead using ``Function(int Value)`` Value is 

``` CSharp
struct Value
{
	int value1; 
	int value2;
	int value3;
}
```

## Interface
* It is a contract between different classes
* every method must have methods from the interface
* It is useful when using the same methods name from different functions ``GetComponent<Interface>().DoSomething();``, which makes our code clear.
* Example: human class has the function `GetHeight()`, Tree class has the function ``GetHeight()``. With the interface ``HeightInterface ``, you can call both methods by ``GetComponent<HeightInterface>().GetHeight()``. Instead of `human.GetHeight()`, `tree.GetHeight()`.

## Event

* Let other functions know this function is called.
* Unity event is `Action<T>` you don't have to specify the event name

### create event

```CSharp
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
        myEvent("unityEvent");
        unityEvent("unityEvent");
    }
}

```
### use event
```CSharp
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

```