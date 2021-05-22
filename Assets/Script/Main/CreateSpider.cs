using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpider : MonoBehaviour
{
    public GameObject spider;

    // 开始产生的时间
    public float beginTime;
    // 重复产生的时间
    public float repeatTime;

    private void Start()
    {
        //每三秒产生一只蜘蛛
        InvokeRepeating("Create", beginTime, repeatTime);
    }

    private void Create()
    {
        GameObject spiderCopy = GameObject.Instantiate(spider);
        //spiderCopy.AddComponent<Rigidbody>();
        spiderCopy.transform.position = new Vector3(0, 20, 0);
    }
}