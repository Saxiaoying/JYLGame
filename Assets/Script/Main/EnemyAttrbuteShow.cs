using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttrbuteShow : MonoBehaviour
{
    private Ray myRay;
    private RaycastHit myHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int MyTarget = 1 << 3;  // 只检测第三层
        // int _MyTarget = ~(1 << 3); //除了第三层都检测
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(myRay, out myHit, 200f, MyTarget))
        {
            Debug.DrawLine(myRay.origin, myHit.point, Color.red);
            print(myHit.transform.name);
            this.transform.Find("TextEnemyRange").GetComponent<Text>().text = "范围:" + myHit.transform.GetComponent<EnemyAttack>().range;
            this.transform.Find("TextEnemyDamage").GetComponent<Text>().text = "伤害:" + myHit.transform.GetComponent<EnemyAttack>().damage;
        }

    }
}
