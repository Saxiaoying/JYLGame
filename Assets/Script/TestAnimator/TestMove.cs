using UnityEngine;
using UnityEngine.AI;

public class TestMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); //获取自身AI组件
        animator = GetComponent<Animator>();     //动画组件
    }
    
    void Update()
    {
        if (Input.GetMouseButton(1)) //右键
        {
            object ray = Camera.main.ScreenPointToRay(Input.mousePosition); //屏幕坐标转射线
            RaycastHit hit;                                                     //射线投射碰撞
            bool isHit = Physics.Raycast((Ray)ray, out hit);             //射线投射(射线，结构体信息) ；返回bool 值 是否检测到碰撞
            if (isHit)
            {
                print("坐标：" + hit.point);               //射线与物体碰撞点
                navMeshAgent.SetDestination(hit.point); //AI组件，设置目的地/终点
                animator.SetBool("TestRun", true);    //让人物跑起来
            }
        }
        if (navMeshAgent.remainingDistance < 0.5f) //当前位置 与终点 的  剩余距离<0.5f
        {
            animator.SetBool("TestRun", false); //让人物站立
        }
    }
}