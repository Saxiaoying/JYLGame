using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageShow : MonoBehaviour
{
    // 展示的类型
    public int type;

    public GameObject content;

    private List<GameObject> itemsAll;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    
    void OnClick()
    {
        itemsAll = new List<GameObject>();
        int num = content.transform.childCount;
        for (int i = 0; i < num; i ++)
        {
            itemsAll.Add(content.transform.GetChild(i).gameObject);
        }

        foreach (GameObject go in itemsAll)
        {
            go.SetActive(false);
        }
        if (type == 1)
        {
            ShowObjectWithTag("Life");

        }
        else if (type == 2)
        {
            ShowObjectWithTag("Energy");

        }
        else if (type == 3)
        {
            ShowObjectWithTag("Coin");
        }
        else
        {
            foreach (GameObject go in itemsAll)
            {
                go.SetActive(true);
            }
        }
    }

    void ShowObjectWithTag(string tag)
    {
        foreach(GameObject go in itemsAll)
        {
            if (go.tag.CompareTo(tag) == 0)
            {
                go.SetActive(true);
            }
        }
    }
}
