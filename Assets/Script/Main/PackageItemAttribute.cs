using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageItemAttribute : MonoBehaviour
{
    public new string name;
    // 增加属性值
    public int point;
    public int num;
    public int money;

    private Text textName;
    private Text textNum;

    // Start is called before the first frame update
    void Start()
    {
        textName = this.transform.Find("ImagePkgItemTop").Find("TextName").GetComponent<Text>();
        textNum = this.transform.Find("ImagePkgItemTop").Find("TextNum").GetComponent<Text>();
        if (this.transform.parent.name.Contains("Shop"))
        {
            textName.text = name;
            textNum.text = "价格:" + money;
        }
    }

    void Update()
    {
        if (this.transform.parent.name.Contains("Pkg"))
        {
            textName.text = name;
            textNum.text = "数量:" + num;
        }
    }

}
