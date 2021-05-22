using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributeShow : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        int blood = player.GetComponent<PlayerAttribute>().blood;
        int energy = player.GetComponent<PlayerAttribute>().energy;
        int coins = player.GetComponent<PlayerAttribute>().coins;
        this.GetComponent<Text>().text = "生命值:" + blood + "  体力值:" + energy + "  金币数:" + coins;
    }
}
