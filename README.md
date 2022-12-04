# Before Reading
> ### All of the features are common and useful in C# Unity, It is personally summarized by Qin, full documentation please check: [C# Offical](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history)

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
* Simplify codes, if different classes have the same methods, use Generic to call these methods with the same codes.
* Give anytime type of parameters

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
## partial
* Separate codes into different files

``` CSharp
public partial class Employee
{
    public void DoWork()
    {
    }
}

public partial class Employee
{
    public void GoToLunch()
    {
    }
}
```

## delegate
* Give a function name with different functions
* Function could be lambda or function(delegate)

```CSharp
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
```

# C# version 3.0
## Property
* Safer, you only can access by the `get` or `set` of the property
* You can initial property when starting

```CSharp
using UnityEngine;
public class PropertyTest : MonoBehaviour
{
    public string CommonProperty { get; set; }
    public string InitialedProperty { get; set; } = "InitialedProperty";
    public string ReadOnlyProperty { get; } = "ReadOnlyProperty";
    void Start()
    {
        CommonProperty = "John";
        Debug.Log("[PropertyTest]CommonProperty:"+CommonProperty);
        Debug.Log("[PropertyTest]InitialedProperty:"+InitialedProperty);
        Debug.Log("[PropertyTest]ReadOnlyProperty:"+ReadOnlyProperty);
    }
}

```
## Lambda Expressions
* Shorter codes expression

```CSharp
using System;
using UnityEngine;
public class LambdaExpression : MonoBehaviour
{
    // Start is called before the first frame update
    int intLambda => 1+2;
    int intLambdaFunction ()=> function();
    Func<int> functionLambda ()=> function;
    void Start()
    {
        Debug.Log("[LambdaExpression]intLambda:"+intLambda);
        Debug.Log("[LambdaExpression]intLambdaFunction:"+intLambdaFunction());
        Debug.Log("[LambdaExpression]functionLambda:"+functionLambdaExe());
    }

    int function()=>5;
    int functionLambdaExe()
    {
        Debug.Log("[LambdaExpression]functionLambdaExe:"+functionLambda());
        return 0;
    }
}

```

# C# version 4.0
## Dynamic binding
* easier modify the string

```CSharp
Debug.Log("a"+"b");

```
## Named arguments
* specific which arguments have which value
* any order of arguments you want to give for functions

```CSharp
PrintOrderDetails(orderNum: 31, productName: "Red Mug", sellerName: "Gift Shop");
PrintOrderDetails(productName: "Red Mug", sellerName: "Gift Shop", orderNum: 31);
```
 
# C# version 5.0
## Asynchronous programming
* codes can run in threads
* task functions for faster execution

```CSharp
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
public class Asynchronous : MonoBehaviour
{
    public List<Texture> texture;
    float timeStart;
    float timeEnd;
    async void Start()
    {
        //do job one by one
        timeStart = Time.realtimeSinceStartup;
        for (int i = 0; i < 100; i++)
        {
            texture.Add(await AsyncFunctionAsync());
        }
        timeEnd = Time.realtimeSinceStartup;
        Debug.Log("[Asynchronous]Time one by one= " + (timeEnd - timeStart));

        //do job parallel
        timeStart =  Time.realtimeSinceStartup;
        List<Task<Texture>> tasks = new List<Task<Texture>>();
        for(int i =0;i<100;i++)
        {
            tasks.Add(AsyncFunctionAsync());
        }
        await Task.WhenAll(tasks);
        for(int i =0;i<100;i++)
        {
            texture.Add(tasks[i].Result);
        }
        timeEnd =  Time.realtimeSinceStartup;
        Debug.Log("[Asynchronous]Time parallel= "+(timeEnd-timeStart));

        // directly call AsyncFunctionAsync
        timeStart = Time.realtimeSinceStartup;
        for (int i = 0; i < 100; i++)
        {
            AsyncFunctionAsync();
        }
        timeEnd = Time.realtimeSinceStartup;
        Debug.Log("[Asynchronous]Time directly= " + (timeEnd - timeStart));
    }
    async Task<Texture> AsyncFunctionAsync()
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture("https://www.yourdomian.com/testpng.png");
        request.SendWebRequest();
        while (!request.isDone)
        {
            // Debug.Log("[Asynchronous]request.isDone:"+request.isDone);
            await Task.Yield();
        }
        if (UnityWebRequest.Result.ConnectionError == request.result)
        {
            // Debug.Log("[Asynchronous]request.error:"+request.error);
            return null;
        }
        else
        {
            Debug.Log("[Asynchronous]Done");
            return ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
}

```
# C# version 6.0
## Lambda operator
* shorter codes

```CSharp
public void Display()
{
	Debug.Log("Display");
}

public void Display()=>Debnug.Log("Display");

```
## Null propagator
* shorter codes
* indexer

```CSharp
List<int> myList = new List<int>();

Action?.Invoke();
```
# C# version 7.0
## Ref
* easier to write codes
```CSharp
public ref Function()
{
	ref a = 11;
	return a;
}
```
# C# version 8.0
## readonly
* faster access
* clear codes expression

```CSharp
private int counter;
public int Counter
{
    readonly get => counter;
    set => counter = value;
}
```
## Generic type constraint
* indicate which type of Generic

```CSharp
public class AGenericClass<T> where T : IComparable<T> { }
```
# Unity C#
## Job Example
### Define a Job
```CSharp
[BurstCompile]
public struct BGFrontJob : IJobParallelForTransform
{
    [ReadOnly] public Vector3 _playerPositionJob;
    public NativeArray<bool> _isActiveNativeArrayJob;
    public void Execute(int index, TransformAccess transform)
    {
        if (Mathf.Abs(_playerPositionJob.x - transform.position.x) > 10f) _isActiveNativeArrayJob[index] = false;
        else _isActiveNativeArrayJob[index] = true;
        if (Mathf.Abs(_playerPositionJob.x - transform.position.x) >= 30 && Mathf.Abs(_playerPositionJob.x - transform.position.x) < 35)
        {
            if (_playerPositionJob.x > transform.position.x)
            {
                transform.position = new Vector3(transform.position.x + 55, 0, 0);
                Debug.Log($"left move to right = {transform.position}");
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 55, 0, 0);
                Debug.Log($"right move to left = {transform.position}");
            }
        }
    }
}

```
### Use Jobs
```CSharp
void Update()
{
    _bgFrontJob = new BGFrontJob
    {
        _playerPositionJob = _player.position,
        _isActiveNativeArrayJob = _isActiveNativeArray,
    };
    _jobHandle = _bgFrontJob.Schedule(_transformAccessArray);
    _jobHandle.Complete();
    for (int i = 0; i < _frondGroundsCount; i++)
    {
        _frondGroundsList[i].SetActive(_isActiveNativeArray[i]);
    }
}
```