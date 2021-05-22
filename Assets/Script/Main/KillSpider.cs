using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSpider : MonoBehaviour
{
    // 蜘蛛的命
    public int life;

    public GameObject player;

    // 玩家攻击范围
    private float range;
    // 玩家攻击伤害点数
    private int damage;
    // 玩家体力值消耗
    private int consume;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject arm = GameObject.FindWithTag("Arm");
        range = arm.GetComponent<ArmAttribute>().range;
        damage = arm.GetComponent<ArmAttribute>().damage;
        consume = arm.GetComponent<ArmAttribute>().consume;
        if (Input.GetKeyDown(KeyCode.K))
        {
            Kill();
        }
    }
    private void Kill()
    {
        float dx = player.transform.position.x - this.transform.position.x;
        float dz = player.transform.position.z - this.transform.position.z;
        
        if (player.GetComponent<PlayerAttribute>().energy >= consume)
        {
            if (System.Math.Abs(dx) < range && System.Math.Abs(dz) < range)
            {
                life -= damage;
                // player.GetComponent<PlayerAttribute>().energy -= consume;
                if (life <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        
    }
}


    