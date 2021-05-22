using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageGameOver : MonoBehaviour
{
    public GameObject msg;

    // Start is called before the first frame update
    void Start()
    {
        msg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (this.GetComponent<PlayerAttribute>().blood <= 0)
       {
            Time.timeScale = 0;
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
            }
            msg.SetActive(true);
       }
    }
   
}
