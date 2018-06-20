using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private bool test=false ;
	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(XiaTest());
	}
	
	// Update is called once per frame
	void Update () {
	    if (test)
	    {
	        Debug.Log(333333333);
	    }
	}

    IEnumerator XiaTest()
    {
        Debug.Log(1111111111111);
        yield return test = true ;
        Debug.Log(222222222222);
    }

}
