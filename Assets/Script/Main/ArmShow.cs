using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmShow : MonoBehaviour
{
    public Text armRange;
    public Text armDamage;
    public Text armConsume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject curArm = GameObject.FindGameObjectWithTag("Arm");
        armRange.text = "��Χ:" + curArm.GetComponent<ArmAttribute>().range;
        armDamage.text = "ɱ����:" + curArm.GetComponent<ArmAttribute>().damage;
        armConsume.text = "����ֵ:" + curArm.GetComponent<ArmAttribute>().consume;
    }
}
