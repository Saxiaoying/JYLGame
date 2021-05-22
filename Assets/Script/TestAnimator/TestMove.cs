using UnityEngine;
using UnityEngine.AI;

public class TestMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); //��ȡ����AI���
        animator = GetComponent<Animator>();     //�������
    }
    
    void Update()
    {
        if (Input.GetMouseButton(1)) //�Ҽ�
        {
            object ray = Camera.main.ScreenPointToRay(Input.mousePosition); //��Ļ����ת����
            RaycastHit hit;                                                     //����Ͷ����ײ
            bool isHit = Physics.Raycast((Ray)ray, out hit);             //����Ͷ��(���ߣ��ṹ����Ϣ) ������bool ֵ �Ƿ��⵽��ײ
            if (isHit)
            {
                print("���꣺" + hit.point);               //������������ײ��
                navMeshAgent.SetDestination(hit.point); //AI���������Ŀ�ĵ�/�յ�
                animator.SetBool("TestRun", true);    //������������
            }
        }
        if (navMeshAgent.remainingDistance < 0.5f) //��ǰλ�� ���յ� ��  ʣ�����<0.5f
        {
            animator.SetBool("TestRun", false); //������վ��
        }
    }
}