using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpider : MonoBehaviour
{
    public GameObject spider;

    // ��ʼ������ʱ��
    public float beginTime;
    // �ظ�������ʱ��
    public float repeatTime;

    private void Start()
    {
        //ÿ�������һֻ֩��
        InvokeRepeating("Create", beginTime, repeatTime);
    }

    private void Create()
    {
        GameObject spiderCopy = GameObject.Instantiate(spider);
        //spiderCopy.AddComponent<Rigidbody>();
        spiderCopy.transform.position = new Vector3(0, 20, 0);
    }
}