using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    //������߶��йص�
    public Scrollbar scrollbar;
    

    //�����Transform
    private Transform camTransform;
    //������߶�
    private float camHeight;
    //�������ת�Ƕ�
    private Vector3 camRot;
    //�����λ��
    private Vector3 camPosition;


    //���λ��
    private Vector3 plyPosition;
    //����ƶ��ٶ�
    private float speed = 3.0f;
    private float jumpSpeed = 8F;
    private float gravity = 10f;

    //��ҽǶ�
    private Vector3 playereEulerAngles;

    //private NavMeshAgent navMeshAgent;
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        //��ȡ�����
        camTransform = Camera.main.transform;

        //���ݻ�����ȡ������߶�
        camHeight = scrollbar.GetComponent<Scrollbar>().value * 10;

        // ��ȡ��ҵ�λ��
        plyPosition = this.transform.position;

        // ��ȡ��ҵĽǶ�
        playereEulerAngles = this.transform.eulerAngles;

        //�����������λ��
        camPosition = plyPosition;
        camPosition.y += camHeight;
        camPosition.z -= 2 * camHeight; //////////////////////
        camTransform.position = camPosition;

        //�������������ת����������һ��
        //camTransform.rotation = this.transform.rotation;
        //camRot = camTransform.eulerAngles;

        //��ȡ����AI���
        navMeshAgent = GetComponent<NavMeshAgent>();
        //�������
        animator = GetComponent<Animator>();

        //�������
        //Screen.lockCursor = true;
    }
    void Update()
    {
        Move();
        Jump();
    }
    private bool mouseControll;

    void Move()
    {

        camHeight = scrollbar.GetComponent<Scrollbar>().value * 30;

        if (Input.GetMouseButton(1)) //�Ҽ�
        {
            mouseControll = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //��Ļ����ת����
            RaycastHit hit;                                                     //����Ͷ����ײ
            bool isHit = Physics.Raycast(ray, out hit);             //����Ͷ��(���ߣ��ṹ����Ϣ) ������bool ֵ �Ƿ��⵽��ײ
            if (isHit)
            {
                print("���꣺" + hit.point);               //������������ײ��
                navMeshAgent.SetDestination(hit.point); //AI���������Ŀ�ĵ�/�յ�
                animator.SetInteger("walkDirection", 1); //��ǰ
                animator.SetBool("walk", true);    //������������
            }
        }

        if (navMeshAgent.remainingDistance < 0.5f) //��ǰλ�� ���յ� ��  ʣ�����<0.5f
        {
            animator.SetBool("walk", false); //������վ��
            mouseControll = false;
        }


        //����3��ֵ�����ƶ�
        float xm = 0, ym = 0, zm = 0;
        //ym -= gravity * Time.deltaTime;

        //ǰ�������ƶ�
        if (Input.GetKey(KeyCode.W))
        {
            mouseControll = false;
            zm += speed * Time.deltaTime;
            animator.SetInteger("walkDirection", 1); //��ǰ
            animator.SetBool("walk", true);    //������������

            playereEulerAngles.y = 0;
            this.transform.eulerAngles = playereEulerAngles;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            mouseControll = false;
            zm += speed * Time.deltaTime;
            animator.SetInteger("walkDirection", 2); //���
                                                        //animator.SetInteger("walkDirection", 1); //��ǰ
            animator.SetBool("walk", true);    //������������

            playereEulerAngles.y = 180;
            this.transform.eulerAngles = playereEulerAngles;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            mouseControll = false;
            zm += speed * Time.deltaTime;
            animator.SetInteger("walkDirection", 3); //����
                                                        //animator.SetInteger("walkDirection", 1); //��ǰ
            animator.SetBool("walk", true);    //������������

            playereEulerAngles.y = 270;
            this.transform.eulerAngles = playereEulerAngles;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            mouseControll = false;
            zm += speed * Time.deltaTime;
            animator.SetInteger("walkDirection", 4); //����
                                                        //animator.SetInteger("walkDirection", 1); //��ǰ
            animator.SetBool("walk", true);    //������������

            playereEulerAngles.y = 90;
            this.transform.eulerAngles = playereEulerAngles;
        }
        else
        {
            if(!mouseControll)
            {
                animator.SetBool("walk", false); //������վ��
            }
        }

            //ʹ�ý�ɫ�������ṩ��Move���������ƶ�
        if (!mouseControll && Input.GetKey(KeyCode.F))
        {
            // ����
            this.GetComponent<CharacterController>().Move(this.transform.TransformDirection(new Vector3(2 * xm, 2 * ym, 2 * zm)));
        }
        else if (!mouseControll)
        {
            this.GetComponent<CharacterController>().Move(this.transform.TransformDirection(new Vector3(xm, ym, zm)));
        }
   

        //��ȡ����ƶ�����
        float rh = Input.GetAxis("Mouse X");
        float rv = Input.GetAxis("Mouse Y");

        ////��ת�����
        camRot.x -= rv;
        camRot.y += rh;
        camTransform.eulerAngles = camRot;

        /* //ʹ��ɫ���������������һ��
         Vector3 camrot = camTransform.eulerAngles;
         camrot.x = 0; camrot.z = 0;
         this.transform.eulerAngles = camrot; */

        //ʹ�����λ�����ɫһ��
        Vector3 pos = this.transform.position;
        pos.y += camHeight;
        //pos.x -= camHeight;
        pos.z -= 2 * camHeight;
        camTransform.position = pos;
    }


    void Jump()
    {
        CharacterController controller = GetComponent<CharacterController>();
        //�Ƿ�������
        //if (controller.isGrounded)
        //{
        float ym = 0;
        if (Input.GetKey(KeyCode.J))
        {
            ym += jumpSpeed * Time.deltaTime;
            animator.SetBool("Jump", true); //��Ծ
        }
        else
        {
            animator.SetBool("Jump", false); //��Ծ
        }
        controller.Move(this.transform.TransformDirection(new Vector3(0, ym, 0)));

        ym -= gravity * Time.deltaTime;
        controller.Move(this.transform.TransformDirection(new Vector3(0, ym, 0)));
        //}
    }


   
}