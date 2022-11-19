# C# version 1.0
## Class
* Allocate memory for this class, the class contains different data structures, and it can be inherited or inherent.
* Give class to another parameter equal **reference**

>### Singleton

```

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
* 