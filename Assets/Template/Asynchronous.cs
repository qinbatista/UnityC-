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
