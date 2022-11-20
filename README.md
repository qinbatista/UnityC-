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
* `Event.myEvent += ReceivedEvent;` means store a bunch of methods and call all of them once trigered

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
        myEvent("s_myEvent");
        myEvent?.Invoke("s_myEvent");
        unityEvent("s_unityEvent");
        unityEvent?.Invoke("s_unityEvent");
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
# C# version 2.0
## Generics
* simplify codes, if different classes have the same methods, use Generic to call these methods with the same codes.
* give anytime type of parameters

```CSharp
using UnityEngine;
public class Generics : MonoBehaviour
{
    void Start()
    {
        ClassA a = new ClassA();
        ClassB b = new ClassB();
        //different class but have same functions can be called with same codes
        Debug.Log(GenericDisplay(a));
        Debug.Log(GenericDisplay(b));

        //functions accept different types of parameters
        Debug.Log(a.G_Display("G_display 5"));
        Debug.Log(b.G_Display(5));

        //functions accept different types of parameters and use same functions from the parameters
        Debug.Log(a.G_Return_String_Display(a));
        Debug.Log(b.G_Return_String_Display(b));
    }
    public int GenericDisplay<T>(T _class) where T : Class
    {
        return _class.Display();
    }
}
public abstract class Class
{
    public abstract int Display();
    public abstract T G_Display<T>(T _class);
    public abstract string StringValue();
    public abstract string G_Return_String_Display<T>(T _class) where T : Class;
}
public class ClassA : Class
{
    public override int Display()
    {
        Debug.Log("[Display]A");
        return 1;
    }
    public override T G_Display<T>(T _class)
    {
        Debug.Log("[G_Display] " + _class);
        return _class;
    }
    public override string StringValue()
    {
        return "StringValue A";
    }
    public override string G_Return_String_Display<T>(T _class)
    {
        Debug.Log("[G_Display] " + _class);
        return _class.StringValue();
    }
}
public class ClassB : Class
{
    public override int Display()
    {
        Debug.Log("[Display]B");
        return 2;
    }
    public override T G_Display<T>(T _class)
    {
        Debug.Log("[G_Display] " + _class);
        return _class;
    }

    public override string StringValue()
    {
        return "StringValue B";
    }
    public override string G_Return_String_Display<T>(T _class)
    {
        Debug.Log("[G_Display] " + _class);
        return _class.StringValue();
    }
}

```