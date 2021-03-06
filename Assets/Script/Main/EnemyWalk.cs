using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyWalk : MonoBehaviour
{
    // 移动速度和终点
    public float speed;
    public GameObject endPoint;

    // 玩家
    public GameObject player;

    // 起点和终点坐标
    private Vector3 startPosition;
    private Vector3 endPosition;

    // flagMoveToEnd为true时移动到终点，否则移回起点
    private bool flagMoveToEnd;
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



    void Start()
    {
        paused = false;
        flagMove = true;
        startPosition = this.transform.position;
        endPosition = endPoint.transform.position;
    }

    void Update()
    {
        if (!paused)
        {
            Walk();
        }
    }


    private void Walk()
    {
        if (flagMove)
        {
            if (flagMoveToEnd)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, endPosition, speed);
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, startPosition, speed);
            }


            if (this.transform.position.x == startPosition.x && this.transform.position.z == startPosition.z)
            {
                flagMoveToEnd = true;
            }
            if (this.transform.position.x == endPosition.x && this.transform.position.z == endPosition.z)
            {
                flagMoveToEnd = false;
            }
        }
        


        

        // 距离玩家很近，变成follow模式
        float dx = this.transform.position.x - player.transform.position.x;
        float dz = this.transform.position.z - player.transform.position.z;
        if (System.Math.Abs(dx) < 5 && System.Math.Abs(dz) < 5)
        {
            flagMove = false;
        }
        else
        {
            flagMove = true;
        }
        //this.gameObject.transform.Translate(new Vector3(AD * speed, 0, WS * speed)); 
    }


    

        
         
}