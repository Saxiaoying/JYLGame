using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageItemUse : MonoBehaviour
{
    public GameObject pkgContent;
    public GameObject msg;

    private GameObject player;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        button = this.transform.Find("ImagePkgItemBottom").Find("ButtonUse").GetComponent<Button>();
        if (this.transform.parent.name.Contains("Shop"))
        {
            button.GetComponentInChildren<Text>().text = "购买";
            button.GetComponent<Button>().onClick.AddListener(Buy);
        }
        else if (this.transform.parent.name.Contains("Pkg"))
        {
            button.GetComponentInChildren<Text>().text = "使用";
            button.GetComponent<Button>().onClick.AddListener(Use);
        }
    }

    // Update is called once per frame
    void Use()
    {
        int point = this.GetComponent<PackageItemAttribute>().point;
        string tag = this.tag;

        if (tag == "Energy")
        {
            EnergyAdd(point);
        }
        else if (tag == "Life")
        {
            BloodAdd(point);
        }
        else
        {
            CoinAdd(point);
        }

        this.GetComponent<PackageItemAttribute>().num --;
        if (this.GetComponent<PackageItemAttribute>().num == 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Buy()
    {
        int money = this.GetComponent<PackageItemAttribute>().money;
        string tag = this.tag;

        if (money > player.GetComponent<PlayerAttribute>().coins)
        {

            msg.SetActive(true);
            //msg.gameObject.SendMessage("ShowInsufficientCoins", SendMessageOptions.DontRequireReceiver);  //必须在active的情况下用
            msg.GetComponentInChildren<Text>().text = "你的金币不够用了！";
        }
        else
        {
            player.GetComponent<PlayerAttribute>().coins -= money;
            
            Transform tmp = pkgContent.transform.Find(this.name);
            if (tmp == null)
            {
                GameObject pkgItem = GameObject.Instantiate(this.gameObject);
                pkgItem.name = this.gameObject.name;
                pkgItem.GetComponent<Transform>().SetParent(pkgContent.transform);
            }
            else
            {
                GameObject pkgItem = tmp.gameObject;
                pkgItem.GetComponent<PackageItemAttribute>().num += 1;
            }
        }
    }
    

    void EnergyAdd(int x)
    {
        player.GetComponent<PlayerAttribute>().energy += x;
    }

    void BloodAdd(int x)
    {
        player.GetComponent<PlayerAttribute>().blood += x;
    }

    void CoinAdd(int x)
    {
        player.GetComponent<PlayerAttribute>().coins += x;
    }
}
