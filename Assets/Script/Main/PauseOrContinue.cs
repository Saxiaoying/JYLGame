using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseOrContinue : MonoBehaviour
{
    private bool isPause;
    private Text text;


    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        text = this.transform.GetComponentInChildren<Text>();
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick()
    {
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        if (isPause)
        {
            // ¿ªÊ¼
            Time.timeScale = 1;
            isPause = false;
            text.text = "ÔÝÍ£";
            foreach (GameObject go in objects)
            {
                go.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            // ÔÝÍ£
            Time.timeScale = 0;
            isPause = true;
            text.text = "¼ÌÐø";

            
            foreach (GameObject go in objects) {
                go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
            } 
                
        }
    }
}
