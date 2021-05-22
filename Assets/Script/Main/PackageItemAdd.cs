using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageItemAdd : MonoBehaviour
{
    public GameObject pkgContent;
    public GameObject chsContent;
    
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        int chsNum = chsContent.transform.childCount;
        for (int i = 0; i < chsNum; i++)
        {
            GameObject chsItem = chsContent.transform.GetChild(i).gameObject;
            
            Transform tmp = pkgContent.transform.Find(chsItem.name);
            if (tmp == null)
            {
                GameObject pkgItem = GameObject.Instantiate(chsItem);
                pkgItem.GetComponent<Transform>().SetParent(pkgContent.transform);
            }
            else
            {
                GameObject pkgItem = tmp.gameObject;
                pkgItem.GetComponent<PackageItemAttribute>().num += chsItem.GetComponent<PackageItemAttribute>().num;
            }
        }
        Destroy(this.transform.parent.parent.gameObject);
    }

   
}
