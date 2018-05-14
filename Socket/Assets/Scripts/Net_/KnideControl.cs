using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnideControl : MonoBehaviour
{
    

    void Start()
    {
    }

    void Update()
    {

   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != PlayerControl.instance.gameObject.GetComponent<CapsuleCollider>())
        {
            if (other.name == PlayerControl.instance.MyName)
            {
                PlayerControl.instance.IsAttack = false;
            }
        }
        else if (other.tag == "Player")
        {
            PlayerControl.instance.IsAttack = true;
            // print(11111111);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerControl.instance.IsAttack = true;
    }

}
