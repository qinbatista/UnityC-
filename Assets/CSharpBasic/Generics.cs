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
