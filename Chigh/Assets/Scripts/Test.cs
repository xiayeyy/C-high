using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Test : MonoBehaviour
{
  //
    public Text tx1;
    public thread th1;
    private bool test=false ;
	// Use this for initialization
	void Start ()
	{
         //StartCoroutine(XiaTest());
	   
	   // tx1.text += th1.ThreadStart();
	}
	
	// Update is called once per frame
	void Update () {
	    if (test)
	    {
	        Debug.Log(333333333);
	    }

	    if (!th1.ReBool())
	    {
	        //tx1.text  += ".";

	    }
        //else
	        //tx1.text += "\n"+"  加载完成！！.";
    }

    IEnumerator XiaTest()
    {
       

  
      //  yield return test = true ;
        yield return new WaitForSeconds(2);
    
    }

}
