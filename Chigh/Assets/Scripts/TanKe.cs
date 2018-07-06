using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanKe : MonoBehaviour {

    public GameObject[] Target;
    public GameObject Target0;

    public GameObject Pao;
    public GameObject GG;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    //Target = GameObject.FindGameObjectsWithTag("XX");
        //if (Vector3.Distance(Caps, transform.position))

        //   foreach (var v in Target)
        //{
        //    Fire(v);

	    //}
	    //Fire(Target0);
	    transform.LookAt(Target0.transform .position );
	    transform.rotation .z =

    }

    public void Fire(GameObject tardet)
    {
        transform.forward = tardet.transform.forward ;
    }
}
