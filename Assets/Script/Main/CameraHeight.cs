using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
public class CameraHeight : MonoBehaviour //, IScrollHandler
{
    // Êó±ê¹öÂÖ
    //public void OnScroll(PointerEventData eventData)
    //{
    //    float x = eventData.scrollDelta.x;
    //    float y = eventData.scrollDelta.y;
    //    print(x + "   " + y);
    //    Debug.Log("x:" + x + "   y:" + y);

    //    // throw new System.NotImplementedException();
    //}

    // Update is called once per frame
    void Update()
    {
        float dV = Input.GetAxis("Mouse ScrollWheel");
        float newV = this.GetComponent<Scrollbar>().value + dV;

        newV = Math.Max(0, newV);
        newV = Math.Min(1, newV);

        this.GetComponent<Scrollbar>().value = newV;
        float y = this.GetComponent<Scrollbar>().value * 30;
        Vector3 pos = Camera.main.transform.position;
        pos.y = y;
        Camera.main.transform.position = pos;

        //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
    }
}
