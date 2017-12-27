using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class searchmove : MonoBehaviour {

    public Transform board;
    public Transform searchbar;
    public Transform insertboard;
	void Start () {
        board.transform.position = new Vector2(Screen.width/2, Screen.height*1.5f);
        insertboard.transform.position= new Vector2(Screen.width / 2, Screen.height * -1.5f);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ButtonMoveSearch()
    {
        board.DOMoveY(Screen.height/2, 2);
        searchbar.DOMoveY(Screen.height*-1/2, 2);
    }
    public void ButtonBackSearch()
    {
        board.DOMoveY(Screen.height*1.5f, 2);
        searchbar.DOMoveY(Screen.height / 2, 2);
    }

    public void ButtonInsert()
    {
        searchbar.DOMoveY(Screen.height *1.5f, 2);
        insertboard.DOMoveY(Screen.height / 2, 2);
    }
    public void ButtonInsertBack()
    {
        searchbar.DOMoveY(Screen.height/2, 2);
        insertboard.DOMoveY(Screen.height*-1.5f, 2);
    }
}
