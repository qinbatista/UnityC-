using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAndEventCompare : MonoBehaviour
{
    public GameObject cube;
    // Start is called before the first frame update
    List<ForAndEventCompareObj> cubes = new List<ForAndEventCompareObj>();
    public static Action OnCalledEvent;
    public int count = 10000;
    float timeStart;
    float timeEnd;
    void Start()
    {

        for (int i = 0; i < count; i++)
        {
            GameObject newCube = Instantiate(cube, new Vector3(i, 0, 0), Quaternion.identity);
            newCube.name = "Cube" + i;
            cubes.Add(newCube.GetComponent<ForAndEventCompareObj>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeStart = Time.realtimeSinceStartup;


        //call by loop
        for (int i = 0; i < count; i++)
        {
            cubes[i].Called();
        }
        //call by event
        // OnCalledEvent?.Invoke();


        timeEnd = Time.realtimeSinceStartup;
        Debug.Log("[Loop]= " + (timeEnd - timeStart));
    }
}
