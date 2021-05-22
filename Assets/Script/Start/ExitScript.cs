using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick()
    {
        UnityEditor.EditorApplication.isPlaying = false;  //退出运行状态，导出exe的时候要注释，因为不能使用UnityEditor
        Application.Quit();
    }
}