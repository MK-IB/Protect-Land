using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayScriptTest : MonoBehaviour
{
    int count = 0;
    void Update()
    {
      Invoke("ChangeRed", 2);
        
    }
    void ChangeRed()
    {
        GetComponent<Renderer>().material.color = Color.red;
        count ++;
        Debug.Log("Count = "+count);
        //Invoke("ChangeWhite", 2);
    }
    void ChangeWhite()
    {
        transform.GetComponent<Renderer>().material.color = Color.white;
    }
}
