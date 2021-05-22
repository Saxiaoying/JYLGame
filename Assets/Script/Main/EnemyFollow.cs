using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    // �ƶ��ٶ�
    public float speed;

    // ���
    public GameObject player;

    // ����ģʽ��true��ʾһֱ���棬 false��ʾ��Χ����
    public bool followMode;

    // flagMoveΪtrueʱ�ƶ�������ֹͣ
    private bool flagMove;

    // ����������ͣ�ƶ�
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