using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    //与相机高度有关的
    public Scrollbar scrollbar;
    

    //摄像机Transform
    private Transform camTransform;
    //摄像机高度
    private float camHeight;
    //摄像机旋转角度
    private Vector3 camRot;
    //摄像机位置
    private Vector3 camPosition;


    //玩家位置
    private Vector3 plyPosition;
    //玩家移动速度
    private float speed = 3.0f;
    private float jumpSpeed = 8F;
    private float gravity = 10f;

    //玩家角度
    private Vector3 playereEulerAngles;

    //private NavMeshAgent navMeshAgent;
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        //获取摄像机
        camTransform = Camera.main.transform;

        //依据滑条获取摄像机高度
        camHeight = scrollbar.GetComponent<Scrollbar>().value * 10;

        // 获取玩家的位置
        plyPosition = this.transform.position;

        // 获取玩家的角度
        playereEulerAngles = this.transform.eulerAngles;

        //设置摄像机的位置
        camPosition = plyPosition;
        camPosition.y += camHeight;
        camPosition.z -= 2 * camHeight; //////////////////////
        camTransform.position = camPosition;

        //设置摄像机的旋转方向与主角一致
        //camTransform.rotation = this.transform.rotation;
        //camRot = camTransform.eulerAngles;

        //获取自身AI组件
        navMeshAgent = GetComponent<NavMeshAgent>();
        //动画组件
        animator = GetComponent<Animator>();

        //锁定鼠标
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

        if (Input.GetMouseButton(1)) //右键
        {
            mouseControll = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //屏幕坐标转射线
            RaycastHit hit;                                                     //射线投射碰撞
            bool isHit = Physics.Raycast(ray, out hit);             //射线投射(射线，结构体信息) ；返回bool 值 是否检测到碰撞
            if (isHit)
            {
                print("坐标：" + hit.point);               //射线与物体碰撞点
                navMeshAgent.SetDestination(hit.point); //AI组件，设置目的地/终点
                animator.SetInteger("walkDirection", 1); //向前
                animator.SetBool("walk", true);    //让人物跑起来
            }
        }

        if (navMeshAgent.remainingDistance < 0.5f) //当前位置 与终点 的  剩余距离<0.5f
        {
            animator.SetBool("walk", false); //让人物站立
            mouseControll = false;
        }


        //定义3个值控制移动
        float xm = 0, ym = 0, zm = 0;
        //ym -= gravity * Time.deltaTime;

        //前后左右移动
        if (Input.GetKey(KeyCode.W))
        {
            mouseControll = false;
            zm += speed * Time.deltaTime;
            animator.SetInteger("walkDirection", 1); //向前
            animator.SetBool("walk", true);    //让人物跑起来

            playereEulerAngles.y = 0;
            this.transform.eulerAngles = playereEulerAngles;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            mouseControll = false;
            zm += speed * Time.deltaTime;
            animator.SetInteger("walkDirection", 2); //向后
                                                        //animator.SetInteger("walkDirection", 1); //向前
            animator.SetBool("walk", true);    //让人物跑起来

            playereEulerAngles.y = 180;
            this.transform.eulerAngles = playereEulerAngles;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            mouseControll = false;
            zm += speed * Time.deltaTime;
            animator.SetInteger("walkDirection", 3); //向左
                                                        //animator.SetInteger("walkDirection", 1); //向前
            animator.SetBool("walk", true);    //让人物跑起来

            playereEulerAngles.y = 270;
            this.transform.eulerAngles = playereEulerAngles;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            mouseControll = false;
            zm += speed * Time.deltaTime;
            animator.SetInteger("walkDirection", 4); //向右
                                                        //animator.SetInteger("walkDirection", 1); //向前
            animator.SetBool("walk", true);    //让人物跑起来

            playereEulerAngles.y = 90;
            this.transform.eulerAngles = playereEulerAngles;
        }
        else
        {
            if(!mouseControll)
            {
                animator.SetBool("walk", false); //让人物站立
            }
        }

            //使用角色控制器提供的Move函数进行移动
        if (!mouseControll && Input.GetKey(KeyCode.F))
        {
            // 加速
            this.GetComponent<CharacterController>().Move(this.transform.TransformDirection(new Vector3(2 * xm, 2 * ym, 2 * zm)));
        }
        else if (!mouseControll)
        {
            this.GetComponent<CharacterController>().Move(this.transform.TransformDirection(new Vector3(xm, ym, zm)));
        }
   

        //获取鼠标移动距离
        float rh = Input.GetAxis("Mouse X");
        float rv = Input.GetAxis("Mouse Y");

        ////旋转摄像机
        camRot.x -= rv;
        camRot.y += rh;
        camTransform.eulerAngles = camRot;

        /* //使角色的面向方向与摄像机一致
         Vector3 camrot = camTransform.eulerAngles;
         camrot.x = 0; camrot.z = 0;
         this.transform.eulerAngles = camrot; */

        //使摄像机位置与角色一致
        Vector3 pos = this.transform.position;
        pos.y += camHeight;
        //pos.x -= camHeight;
        pos.z -= 2 * camHeight;
        camTransform.position = pos;
    }


    void Jump()
    {
        CharacterController controller = GetComponent<CharacterController>();
        //是否触碰地面
        //if (controller.isGrounded)
        //{
        float ym = 0;
        if (Input.GetKey(KeyCode.J))
        {
            ym += jumpSpeed * Time.deltaTime;
            animator.SetBool("Jump", true); //跳跃
        }
        else
        {
            animator.SetBool("Jump", false); //跳跃
        }
        controller.Move(this.transform.TransformDirection(new Vector3(0, ym, 0)));

        ym -= gravity * Time.deltaTime;
        controller.Move(this.transform.TransformDirection(new Vector3(0, ym, 0)));
        //}
    }


   
}