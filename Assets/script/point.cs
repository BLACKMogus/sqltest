using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class point : MonoBehaviour {

    string myname;
    public InputField input;
    public Dropdown changeoption;
    ConnectMysql sql;
    //private static point instance;
    void Awake()
    {
        //instance = this;

    }
	void Start () {
        sql = GameObject.Find("Camera").GetComponent<ConnectMysql>();
    }

    //public static void setname(string name)
    //{
    //    instance.name = name;
    //}
    //public static string getname()
    //{
    //    return instance.name;
    //}
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0) )
        //{

      
        //    if (EventSystem.current.IsPointerOverGameObject())

        //        Debug.Log("当前触摸在UI上");

        //    else
        //        Debug.Log("当前没有触摸在UI上");
        //}
    }
    public void ButtonSelect()
    {
        // GameObject thiss = EventSystem.current.currentSelectedGameObject;
        //setname(thiss.transform.parent.name);
        //Debug.Log(getname());
    }
    public void ButtonDelete()
    {
        GameObject thiss = EventSystem.current.currentSelectedGameObject;
        sql.ButtonDelete(thiss.transform.parent.name);
    }
    public void ButtonUpdate()
    {
        GameObject thiss = EventSystem.current.currentSelectedGameObject;
        string optiontext = changeoption.options[changeoption.value].text;
        int optionvalue = changeoption.value;
        sql.ButtonChange(optiontext, optionvalue+1,input.text, thiss.transform.parent.name);//修改的属性，属性对应的value，修改的内容，id号码

     //   Debug.Log(optionvalue);
    }
}  

