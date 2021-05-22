using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ICustomMsgTarget : IEventSystemHandler
{
    void Msg1();
    void Msg1(string s);

    void Msg2();
}
