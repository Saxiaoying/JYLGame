using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestRay : MonoBehaviour
{
    public GameObject target;
    private Material tm;
    private GraphicRaycaster rc;
    private PointerEventData pt;
    private EventSystem es;

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            tm = target.GetComponent<Renderer>().material;
        }
        rc = GetComponent<GraphicRaycaster>();
        es = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        pt = new PointerEventData(es);
        pt.position = Input.mousePosition;

        List<RaycastResult> re = new List<RaycastResult>();
        rc.Raycast(pt, re);

        foreach (RaycastResult i in re) 
        {
            if (i.gameObject.GetComponent<Image>().color != null)
            {
                tm.color = i.gameObject.GetComponent<Image>().color;
            }
        }
    }
}
