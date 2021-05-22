using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenOrClosePkgOrShop : MonoBehaviour
{
    public GameObject PkgOrShop;

    // Start is called before the first frame update
    void Start()
    {
        PkgOrShop.SetActive(false);
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    
    void OnClick()
    {
        if (PkgOrShop.activeSelf)
        {
            PkgOrShop.SetActive(false);
        }
        else
        {
            PkgOrShop.SetActive(true);
        }
    }
}
