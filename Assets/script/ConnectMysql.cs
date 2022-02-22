using System;
using System.Data;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ConnectMysql : MonoBehaviour {
    string constr = "server=120.78.152.25;Database=blackmogus;User Id=root;password=victory03131";
    MySqlConnection mycon;//连接数据库
    string title;
    string content;
    public  Dropdown selectoption;
    public InputField searchcontent;
    public GameObject show;
    public GameObject textparent;
    void Start () {
    mycon  = new MySqlConnection(constr); //建立连接  
    mycon.Open();
      
    }
	
	
	void Update () {
      //  Debug.Log(selectclass.captionText.text);
	}

    public void ButtonSearch()
    {
     
        StartSearch();
    }
    public void ButtonBack()
    {
        StartCoroutine("dele");
 
    }
    IEnumerator dele()
    {
       
        yield return new WaitForSeconds(1);
        for (int i = 0; ; i++)
        {

            GameObject[] cube = GameObject.FindGameObjectsWithTag("cube");
            GameObject.Destroy(cube[i]);

        }

    }

    void StartSearch()
    {
     

     
            string selstr ;
            string input = searchcontent.text;
            switch(selectoption.value)
        {
            case 0://选择all
                selstr = "select * from catalog inner join book on book.bname=catalog.bname order by id asc";
                search(selstr);
                break;
            case 1://选择id整形
                selstr = "select * from catalog inner join book on book.bname=catalog.bname where "
                          +selectoption.options[selectoption.value].text+"="+input;
                search(selstr);

                break;
            case 2://选择科目标准
                selstr = "select * from catalog inner join book on book.bname=catalog.bname where "+ selectoption.options[selectoption.value].text 
                               + " like '%"+input+"%' order by id asc";
                search(selstr);
                break;
            case 3://选择书名标准
                selstr = "select * from catalog inner join book on book.bname=catalog.bname where catalog." + selectoption.options[selectoption.value].text
                               + " like '%" + input + "%' order by id asc";
                search(selstr);
                break;
            case 4://选择页数整形
                selstr = "select * from catalog inner join book on book.bname=catalog.bname where "
                          + selectoption.options[selectoption.value].text + "=" + input;
                search(selstr);
                break;
            case 5://选择周期整形
                selstr = "select * from catalog inner join book on book.bname=catalog.bname where "
                          + selectoption.options[selectoption.value].text + "=" + input;
                search(selstr);
                break;
            case 6://选择因子浮点
                selstr = "select * from catalog inner join book on book.bname=catalog.bname where "
                          + selectoption.options[selectoption.value].text + "=" + input;
                search(selstr);
                break;
            case 7://选择备注标准
                selstr = "select * from catalog inner join book on book.bname=catalog.bname where " + selectoption.options[selectoption.value].text
                              + " like '%" + input + "%' order by id asc";
                search(selstr);
                break;
            case 8://选择网址标准
                selstr = "select * from catalog inner join book on book.bname=catalog.bname where " + selectoption.options[selectoption.value].text
                              + " like '%" + input + "%' order by id asc";
                search(selstr);
                break;
            case 9://选择简介标准
                selstr = "select * from catalog inner join book on book.bname=catalog.bname where " + selectoption.options[selectoption.value].text
                               + " like '%" + input + "%' order by id asc";
                search(selstr);
                break;
            default:break;
        }

         
    }
    void search(string sear)
    {
        MySqlCommand myselect = new MySqlCommand(sear, mycon);//向数据库输入语句
        DataSet ds = new DataSet();

        MySqlDataAdapter da = new MySqlDataAdapter(sear, mycon);
        da.Fill(ds);
     //   Debug.Log(ds.Tables[0].Columns.Count);
        string outputt = "";
        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
        {
            string output = "";
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                output = output + ds.Tables[0].Columns[i] + ":" + ds.Tables[0].Rows[j][i] + "\n";
                outputt = output;
            }
            GameObject newsearch = (GameObject)Instantiate(show);
            newsearch.transform.name = ds.Tables[0].Rows[j][0].ToString();

            newsearch.transform.parent = textparent.transform;
            newsearch.GetComponentInChildren<Text>().text = outputt;
            newsearch.GetComponentInChildren<Text>().fontSize = Screen.height / 30;
        }
    }
    public void ButtonDelete(string delename)
    {
        string selstr = "delete from catalog where id = "+delename;
        MySqlCommand myselect = new MySqlCommand(selstr, mycon);//向数据库输入语句
        DataSet ds = new DataSet();
        MySqlDataAdapter da = new MySqlDataAdapter(selstr, mycon);
        da.Fill(ds);
      
    }
    public void ButtonChange(string changename,int o,string changecontent,string id)
    {
        MySqlCommand myselect;
        DataSet ds = new DataSet();
        MySqlDataAdapter da;
        string selstr;
        switch (o)
        {
            case 1://改id
                selstr = "update catalog set " + changename + "=" +changecontent + " where id =" + id;
                myselect = new MySqlCommand(selstr, mycon);//向数据库输入语句
                da = new MySqlDataAdapter(selstr, mycon);
                da.Fill(ds);
                break;

            case 2://改bname
                selstr = "update catalog set " + changename + "=" + "'" + changecontent + "'" +" where id =" + id;
                Debug.Log(selstr);
                myselect = new MySqlCommand(selstr, mycon);
                da= new MySqlDataAdapter(selstr, mycon);
                da.Fill(ds);
                break;
            case 3://改subjcet
                selstr = "update catalog set " + changename + "=" + "'" + changecontent + "'" + " where id =" + id;
                myselect = new MySqlCommand(selstr, mycon);
                da = new MySqlDataAdapter(selstr, mycon);
                da.Fill(ds);break;
            case 4://改page
                selstr = "update catalog set " + changename + "=" + changecontent + " where id =" + id;
                myselect = new MySqlCommand(selstr, mycon);
                da = new MySqlDataAdapter(selstr, mycon);
                da.Fill(ds); break;
            case 5://改cycle=
                selstr = "update book,catalog set " + changename + "=" + changecontent +" where catalog.bname=book.bname and id ="+id;
                Debug.Log(selstr);
                myselect = new MySqlCommand(selstr, mycon);
                da = new MySqlDataAdapter(selstr, mycon);
                da.Fill(ds); break;
            case 6://改factor
                selstr = "update book,catalog set " + changename + "=" + changecontent + " where catalog.bname=book.bname and id =" + id;
                myselect = new MySqlCommand(selstr, mycon);
                da = new MySqlDataAdapter(selstr, mycon);
                da.Fill(ds); break;
            case 7://改remark
                selstr = "update book,catalog set " + changename + "=" + changecontent + " where catalog.bname=book.bname and id =" + id;
                myselect = new MySqlCommand(selstr, mycon);
                da = new MySqlDataAdapter(selstr, mycon);
                da.Fill(ds); break;
            case 8://改web
                selstr = "update book,catalog set " + changename + "=" + changecontent + " where catalog.bname=book.bname and id =" + id;
                myselect = new MySqlCommand(selstr, mycon);
                da = new MySqlDataAdapter(selstr, mycon);
                da.Fill(ds); break;
            case 9://introduction
                selstr = "update book,catalog set " + changename + "=" + changecontent + " where catalog.bname=book.bname and id =" + id;
                myselect = new MySqlCommand(selstr, mycon);
                da = new MySqlDataAdapter(selstr, mycon);
                da.Fill(ds); break;
            default:break;

        }
  
    }


    public void ButtonInsert()
    {
        string selstr = "insert into catalog values ('" + id.text + "','" + bname.text + "','" + subject.text + "','" + page.text + "')";
        MySqlCommand myselect = new MySqlCommand(selstr, mycon);//向数据库输入语句
        DataSet ds = new DataSet();
        MySqlDataAdapter da = new MySqlDataAdapter(selstr, mycon);
        da.Fill(ds);


    }
    public void ButtonInsert2()
    {

        DataSet ds = new DataSet();

        string selstr2 = "insert into book values ('" + bname.text + "','" + clycle.text + "','" + factor.text + "','" + web.text + "','" + remark.text + "','" + intro.text +
                       "')";

        MySqlCommand myselect2 = new MySqlCommand(selstr2, mycon);
        MySqlDataAdapter da = new MySqlDataAdapter(selstr2, mycon);
        da.Fill(ds);
    }
   
}
