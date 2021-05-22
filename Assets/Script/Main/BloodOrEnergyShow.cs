using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodOrEnergyShow : MonoBehaviour
{
    public GameObject player;
    public bool isBlood;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Slider>().maxValue = GetValue();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Slider>().value = GetValue();
    }

    private int GetValue()
    {
        if (isBlood)
        {
            return player.GetComponent<PlayerAttribute>().blood;
        }
        else
        {
            return player.GetComponent<PlayerAttribute>().energy;
        }
    }
}
