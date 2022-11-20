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
