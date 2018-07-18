using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TanKe : MonoBehaviour
{

    public Text tx1;
    public GameObject[] Target;
    public GameObject Target0;

    public GameObject Pao;
    public GameObject GG;

	void Start ()
	{   

    }
	
	// Update is called once per frame
	void Update ()
	{
	    Debug.DrawLine(Pao.transform.position, Target0 .transform.position, Color.yellow);

        Angle();

       
    }

    public void Fire(GameObject tardet)
    {
        Pao. transform.forward = tardet.transform.forward ;
    }

   
    void Angle()
    {
        Vector3 vector3 = Pao.transform.localPosition - Target0.transform.localPosition;

        Pao.transform.localRotation =Quaternion.LookRotation(vector3);

        tx1 .text = Pao.transform.rotation + "        ";

    }
}
