using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
public class ThreadTester : MonoBehaviour
{
    // Start is called before the first frame update
    Thread thread;
    void Start()
    {
        thread = new Thread(() =>
        {
            while (true)
            {
                this.TryGetComponent(out MeshRenderer meshRenderer);
                Debug.Log("Running on a new thread");
            }
        });
        thread.Start();


        Parallel.Invoke(() =>
        {
            // Task 1
            Debug.Log("Task 1 running on a new thread");
        }, () =>
        {
            // Task 2
            Debug.Log("Task 2 running on a new thread");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
