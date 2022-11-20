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
