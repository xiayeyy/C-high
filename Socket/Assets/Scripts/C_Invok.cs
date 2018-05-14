using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Invok : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("incoc", 3, 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void incoc()
    {
        Debug.Log("DDDDD");
    }
}
