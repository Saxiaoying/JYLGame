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
        UnityEditor.EditorApplication.isPlaying = false;  //�˳�����״̬������exe��ʱ��Ҫע�ͣ���Ϊ����ʹ��UnityEditor
        Application.Quit();
    }
}