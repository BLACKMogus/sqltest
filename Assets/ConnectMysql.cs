using System;
using System.Data;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;

public class ConnectMysql : MonoBehaviour {
    string constr = "server=120.78.152.25;Database=blackmogus;User Id=root;password=victory03131";
    MySqlConnection mycon;//连接数据库

    string title;
    string content;

   // public Text show;
    public  Dropdown selectclass;
    public InputField selectcontent;
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

    void StartSearch()
    {
        string A = "select";
        string B = "from book inner join catalog on book.id=catalog.id";
        string C;
      if (selectclass.captionText.text=="ALL")
        {
           C = "*";
        }
      else
        {
           C = selectclass.captionText.text;
        }

      //  string selstr = A + C+B;

        string selstr = "select * from catalog inner join book on book.bname=catalog.bname";
        MySqlCommand myselect = new MySqlCommand(selstr, mycon);//向数据库输入语句
   
        DataSet ds = new DataSet();

        //  MySqlDataReader reader = myselect.ExecuteReader();
        //string output="";
        //while (reader.Read())
        //{
        //    for(int i=0;i<reader.FieldCount;i++)
        //    {
        //        show.text = reader[i].ToString();
        //        output = output+reader[i].ToString();
        //        //Debug.Log(reader[i].ToString());
        //        //text = text +output;
        //    }
        //    show.text = output;
        //    //string name = reader.GetString(reader.GetOrdinal("subject"));
        //    //Debug.Log(name);
        //}
        //reader.Close();

        try
        {
            
            MySqlDataAdapter da = new MySqlDataAdapter(selstr, mycon);
            da.Fill(ds);
            Debug.Log(ds.Tables[0].Columns.Count);
           string outputt = "";

            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                string output = "";
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    
                    output =  output+ds.Tables[0].Columns[i] + ":" + ds.Tables[0].Rows[j][i] + "\n";
                    outputt = output;

                }
                GameObject newsearch = (GameObject)Instantiate(show);

                newsearch.transform.parent = textparent.transform;
                newsearch.GetComponentInChildren<Text> ().text = outputt;
                newsearch.GetComponentInChildren<Text>().fontSize = Screen.height/40;
            }

            // output = output + ds.Tables[0].Columns[0] + ":" + ds.Tables[0].Rows[0][0] + "\n";
            //  output = output + "\n\n";
           
            // show.text = output;

        }

        catch (Exception ee)
        {
            throw new Exception("SQL: " + selstr + "\n" + ee.Message.ToString());
        }
    }
}
