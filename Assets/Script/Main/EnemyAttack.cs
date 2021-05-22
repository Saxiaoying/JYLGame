using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyAttack : MonoBehaviour
{
    // 伤害值
    public int damage;
    public float range;

    // 玩家
    public GameObject player;
    
    private void Start()
    {
        //每三秒攻击一次
        InvokeRepeating("Attack", 0, 3);
    }

    private void Attack()
    {
        float dx = player.transform.position.x - this.transform.position.x;
        float dz = player.transform.position.z - this.transform.position.z;

        if (System.Math.Abs(dx) < range && System.Math.Abs(dz) < range)
        {
            // 血量减少
            player.GetComponent<PlayerAttribute>().blood -= damage;
        }
    }
}

