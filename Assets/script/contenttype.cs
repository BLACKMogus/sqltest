using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class contenttype : MonoBehaviour {

   public Dropdown parrent;
    public InputField myself;
	// Use this for initialization
	void Start () {
        //myself = this.GetComponent<InputField>();
        //parrent = this.parrent.GetComponent<Dropdown>();
    }
	
	// Update is called once per frame
	void Update () {    
        switch(parrent.value+1)
        {
            case 1: myself.contentType = InputField.ContentType.IntegerNumber;break;
            case 2: myself.contentType = InputField.ContentType.Standard ;break;
            case 3: myself.contentType = InputField.ContentType.Standard; break;
            case 4: myself.contentType = InputField.ContentType.IntegerNumber ; break;
            case 5: myself.contentType = InputField.ContentType.IntegerNumber ; break;
            case 6: myself.contentType = InputField.ContentType.DecimalNumber; break;
            case 7: myself.contentType = InputField.ContentType.Standard; break;
            case 8: myself.contentType = InputField.ContentType.Standard; break;
            case 9: myself.contentType = InputField.ContentType.Standard; break;
            default:break;
        }
    
     
	}
}
