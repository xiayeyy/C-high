using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;


public class DataXML : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        DeleteXml();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeleteXml()
    {
        string filepath = Application.dataPath + "/Resources/item.xml";
        //Debug.Log(filepath);
        if (File.Exists(filepath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList nodeList = xmlDoc.FirstChild.ChildNodes;

            foreach (XmlElement xe in nodeList)
            {
                Debug.Log(xe.Attributes[0].Value);
                Debug.Log(xe.InnerText);


            }
            xmlDoc.Save(filepath);
            Debug.Log("deleteXml OK!");
        }
        else Debug.LogError(" NO File");


    }
}
