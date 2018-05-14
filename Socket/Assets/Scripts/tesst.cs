using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tesst : K<tesst>
{
    public Transform LoginPageTran;
    private NEW n1;
	// Use this for initialization
	void Start () {
        //this.loginController = this.LoadPage<LoginPageController>(this.LoginPageTran);
        n1= this.LoadPage<NEW >(this.LoginPageTran);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
