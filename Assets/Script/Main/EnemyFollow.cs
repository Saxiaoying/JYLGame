using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    // 移动速度
    public float speed;

    // 玩家
    public GameObject player;

    // 跟随模式，true表示一直跟随， false表示范围跟随
    public bool followMode;

    // flagMove为true时移动，否则停止
    private bool flagMove;

    // 用于物体暂停移动
    private bool paused;

    void OnPauseGame()
    {
        paused = true;
    }

    void OnResumeGame()
    {
        paused = false;
    }

    private void Start()
    {
        paused = false;
        flagMove = true;
    }

    void Update()
    {
        if (!paused)
        {
            Follow();
        }
    }


    private void Follow()
    {
        if (flagMove)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed);
        }

        if (!followMode)
        {
            float dx = this.transform.position.x - player.transform.position.x;
            float dz = this.transform.position.z - player.transform.position.z;
            if (System.Math.Abs(dx) < 5 && System.Math.Abs(dz) < 5)
            {
                flagMove = true;
            }
            else
            {
                flagMove = false;
            }
        }
       
    }
}