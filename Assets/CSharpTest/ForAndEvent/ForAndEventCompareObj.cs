
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAndEventCompareObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Called()
    {
        for(int i =0;i<100;i++)
        {
            transform.position += Vector3.up;
        }
    }
    void OnEnable()
    {
        ForAndEventCompare.OnCalledEvent += Called;
    }
    void OnDisable()
    {
        ForAndEventCompare.OnCalledEvent -= Called;
    }
}
