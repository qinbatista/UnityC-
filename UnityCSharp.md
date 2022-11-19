# CSharp version 1.0
## Class
* Allocate memory for this class, the class contains different data structures, and it can be inherited or inherent.
* Give class to another parameter equal **reference**

### Tips
```C# 

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
