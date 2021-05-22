using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMsgTarget : MonoBehaviour, ICustomMsgTarget
{
    public void Msg1()
    {
        Debug.Log("Msg 1");
    }

    public void Msg1(string s)
    {
        Debug.Log("Msg 1:" + s);
        //throw new System.NotImplementedException();
    }

    public void Msg2()
    {
        Debug.Log("Msg 2");
        //throw new System.NotImplementedException();
    }
}
