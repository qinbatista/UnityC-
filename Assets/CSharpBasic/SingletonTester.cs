using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTester : Singleton<SingletonTester>
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SingletonTester.Instance);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
