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
    private int num = 0;

    public Color originC;
    public Color newC;


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

	    if (Input.GetKeyDown (KeyCode.P))
	    {
	        try
	        {
	            num += Convert.ToInt32(tx1.text);
	            Debug.Log(num);
	        }
	        catch(Exception e)
	        {
	            Debug.Log(e);
	            Debug.Log(tx1.text);
	        }
	    }

	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        //myTest();

	    }


	    ColorChange(originC, newC);
        //if (!th1.ReBool())
        //{
        //    //tx1.text  += ".";

        //}
        //   //else
        //    //tx1.text += "\n"+"  加载完成！！.";
    }

    IEnumerator XiaTest()
    {
      //  yield return test = true ;
        yield return new WaitForSeconds(2);
    }

    [InvokeOnKeyPressAttribute(KeyCode = KeyCode.P)]
    public void ArrTest()
    {
        tx1.text = "!!!!!!";
        Debug.Log("!!!!!!!!!!");
    }

    void myTest()
    {
       // EditorUtility.DisplayDialog("1","2","3");
      //  EditorUtility.OpenFilePanel("1", "2", "3");
    }

    void ColorChange(Color originC ,Color newC )
    {
        this .gameObject .GetComponent <Renderer > ().material.color = Color.Lerp(originC,newC, Time.time);
    }

    
}

