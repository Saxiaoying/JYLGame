using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmChange : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Change(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Change(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Change(3);
        }
    }

    void Change(int id)
    {
        GameObject armBefore = GameObject.FindWithTag("Arm");
        armBefore.SetActive(false);

        GameObject armNow = this.transform.Find("Arm"+id).gameObject;
        armNow.SetActive(true);

    }
}
