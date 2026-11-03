using UnityEngine;
using HelloInvestigation;

public class HelloWorld : MonoBehaviour
{
    private void Start()
    {
        Greeting greeting = new Greeting();
        greeting.Name = "Ari";
        Debug.Log(greeting.BuildMessage());
    }
}