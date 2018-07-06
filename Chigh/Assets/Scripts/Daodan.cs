using UnityEngine;

using System.Collections;

public class Daodan : MonoBehaviour
{
    public GameObject man;

    public GameObject missile;

    public float manSpeed = 6f;

    public float missileSpeed = 4f;

    public float missileRotateSpeed = 2f;

    bool whehterShooted = false;

    float distance;

    float collisionDistance;

    // Use this for initialization

    void Start()
    {

        if (man != null && missile != null)

        {

            float manWidth = man.GetComponent<Mesh>().bounds.size.x * man.transform.localScale.x;

            float missileLength = missile.GetComponent<Mesh>().bounds.size.z * missile.transform.localScale.z;

            print("manWidth:" + manWidth.ToString() + ",missileLength:" + missileLength.ToString());

            collisionDistance = manWidth / 2 + missileLength / 2;

        }

    }

    // Update is called once per frame

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))

        {

            man.transform.Translate(Vector3.left * Time.deltaTime * manSpeed);

        }

        if (Input.GetKey(KeyCode.RightArrow))

        {

            man.transform.Translate(-Vector3.left * Time.deltaTime * manSpeed);

        }

        if (Input.GetKey(KeyCode.UpArrow))

        {

            man.transform.Translate(Vector3.forward * Time.deltaTime * manSpeed);

        }

        if (Input.GetKey(KeyCode.DownArrow))

        {

            man.transform.Translate(-Vector3.forward * Time.deltaTime * manSpeed);

        }

        if (Input.GetKeyDown(KeyCode.S)) //按下S 发射导弹

        {

            whehterShooted = true;

        }

        if (whehterShooted && missile != null)

        {

            distance = Vector3.Distance(man.transform.position, missile.transform.position);

            ////导弹朝向人  法一

            //missile.transform.LookAt(man.transform);

            //导弹朝向人  法二

            Quaternion missileRotation =
                Quaternion.LookRotation(man.transform.position - missile.transform.position, Vector3.up);

            //missile.transform.rotation = Quaternion.Slerp(missile.transform.rotation, missileRotation, Time.deltaTime * missileRotateSpeed);

            missile.transform.rotation = missileRotation;
        }
    }
}