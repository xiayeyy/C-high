using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets11;

public class NEW : MonoBehaviour
{
    public GameObject cube;

    [SerializeField]
     static  int abv;
    // Use this for initialization
    void Start () {
        khide();

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    [InvokeOnKeyPress(KeyCode = KeyCode.RightArrow  )]
    public void hide()
    {       print(110);
        cube.SetActive(false);
 
    }

    [InvokeOnKeyPress(KeyCode = KeyCode.LeftArrow )]
    public void show()
    {
         print(110);
            cube.SetActive(true );
    }

    public void khide()
    {
        gameObject.SetActive(false);
    }
  
}

