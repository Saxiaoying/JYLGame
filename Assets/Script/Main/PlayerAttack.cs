using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    // ��ҹ����˺�����
    private int damage;
    // �������ֵ����
    private int consume;

    public GameObject msg;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //�������
        animator = GetComponent<Animator>();
        animator.SetBool("dead", false);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject arm = GameObject.FindWithTag("Arm");
        damage = arm.GetComponent<ArmAttribute>().damage;
        consume = arm.GetComponent<ArmAttribute>().consume;
        if (Input.GetKeyDown(KeyCode.K))
        {
            Attack();
        }
        else
        {
            animator.SetBool("attack", false);
        }

        if (this.GetComponent<PlayerAttribute>().blood <= 10)
        {
            animator.SetBool("dead", true);
        }
    }

    private void Attack()
    {
        if (this.GetComponent<PlayerAttribute>().energy >= consume)
        {
            animator.SetBool("attack", true); 
            this.GetComponent<PlayerAttribute>().energy -= consume;
        }
        else
        {
            msg.SetActive(true);
            //msg.gameObject.SendMessage("ShowInsufficientCoins", SendMessageOptions.DontRequireReceiver);  //������active���������
            msg.GetComponentInChildren<Text>().text = "�����������������ȥ����һ��������~";
            // print("�������ֵ����");
            ExecuteEvents.Execute<ICustomMsgTarget>(msg, null, (x, y) => x.Msg1("�����������"));
        }
    }
}
