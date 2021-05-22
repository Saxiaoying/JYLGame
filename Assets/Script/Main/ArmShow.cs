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
        armRange.text = "·¶Î§:" + curArm.GetComponent<ArmAttribute>().range;
        armDamage.text = "É±ÉËÁ¦:" + curArm.GetComponent<ArmAttribute>().damage;
        armConsume.text = "ÏûºÄÖµ:" + curArm.GetComponent<ArmAttribute>().consume;
    }
}
