using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public GameObject chest;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float dx = player.transform.position.x - this.transform.position.x;
        float dz = player.transform.position.z - this.transform.position.z;

        if (System.Math.Abs(dx) > 1 || System.Math.Abs(dz) > 1)
        {
            chest.SetActive(false);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                chest.SetActive(true);
            }
        }

        if (chest == null)
        {
            Destroy(this.gameObject);
        }
    }
}
