using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : MonoBehaviour
{
    public int energy;
    public int blood;
    public int coins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void EnergyAdd(int x)
    {
        energy += x;
    }

    void BloodAdd(int x)
    {
        blood += x;
    }
}
