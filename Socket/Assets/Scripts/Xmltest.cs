
#region 用到的函数
/* Application:访问应用程序运行时数据。
 * dataPath:包含游戏数据文件夹的路径(只读)。
 * File.Exists(string path):判断是文件路径是否存在
 * .CreateXmlDeclaration(string version,string encoding,string standalone):  创建声明某文档
 * .SelectNodes（选择某节点所有子节点元素）
 * .SelectSingleNode().ChildNode (选择某个节点).(子节点元素)
 * XmlDocument： xml文档
 * XmlNode ： xml节点
 * XmlElement：xml元素
 * .CreateElement(strin name) : 创建xml元素
 * .SetAttribute(string name，string value) ：写属性
 * ApendChild(XmlNode NewChild)：添加孩子
 * .InnerText{get;set;}  : （属性）string类型。 某元素.文本节点
 * AsseteDatabase.Refresh();   :   更新 资源数据库
 * .Save(path);   保存某文档；
 * .Load（path）;   得到（加载）某文档
 * XmlNodeList  ：节点列表
 * .Equals(string value)  某值等于value  等同于 == 
 */
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Data_XML : MonoBehaviour
{

    private string path;

    void Start()
    {
        path = Application.dataPath + "/1.XML/XMLData/ChatData.xml";
    }//end_Start

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            CreateXML();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            AddXML();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            UpDataXML();
        }

    }//end_Update
    /// <summary>
    /// 创建XML
    /// </summary>
    void CreateXML()
    {
        //如果不存在，那么创建
        if (!File.Exists(path))
        {
            //创建xml文档对象
            XmlDocument doc = new XmlDocument();
            //创建xml头
            XmlNode xmlHead = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            //将xml头添加到文档对象
            doc.AppendChild(xmlHead);
            //创建根节点
            XmlElement root = doc.CreateElement("object");
            //将根节点添加到xml当中
            doc.AppendChild(root);
            //创建子节点
            XmlElement element01 = doc.CreateElement("message");
            //给子节点设置属性
            element01.SetAttribute("id", "1001");
            //添加到根节点中
            root.AppendChild(element01);
            //创建子节点0101
            XmlElement element0101 = doc.CreateElement("content");
            //给子节点0101添加元素属性
            element0101.SetAttribute("name", "The1");
            //001添加文本节点
            element0101.InnerText = "嗨，少年，你醒了吗?";
            //将子节点添加到01节点当中
            element01.AppendChild(element0101);
            ////给子节点添加文本节点
            //element01.InnerText = "";
            //创建子节点0102....
            XmlElement element0102 = doc.CreateElement("mission");
            element0102.SetAttribute("name", "The2");
            element0102.InnerText = "我是谁，我在哪里？";
            element01.AppendChild(element0102);

            //保存成一个真正的文档
            doc.Save(path);
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }
        else
        {
            print("文件已存在");
        }

    }
    /// <summary>
    /// 添加
    /// </summary>
    void AddXML()
    {
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif

        if (!File.Exists(path))
        {
            return;
        }
        else
        {
            XmlDocument doc = new XmlDocument();
            //加载指定路径的xml文件
            doc.Load(path);
            //找到根节点
            XmlNode root = doc.SelectSingleNode("object");
            XmlElement e = doc.CreateElement("message01");
            e.SetAttribute("id", "1002");
            root.AppendChild(e);
            XmlElement e1 = doc.CreateElement("content01");
            e1.SetAttribute("name", "The3");
            e1.InnerText = "啊，头好疼";
            e.AppendChild(e1);
            XmlElement e2 = doc.CreateElement("content02");
            e2.SetAttribute("name", "The4");
            e2.InnerText = "想起来了，是他把我推下了悬崖";
            e.AppendChild(e2);
            doc.Save(path);
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif

        }
    }
    /// <summary>
    /// 更新
    /// </summary>
    void UpDataXML()
    {

        if (!File.Exists(path))
        {
            return;
        }
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        //得到object里所有的子节点
        //XmlNodeList xmlNodes = doc.SelectNodes("object");
        XmlNodeList xmlNode = doc.SelectSingleNode("object").ChildNodes;
        foreach (XmlElement xe in xmlNode)
        {

            if (xe.GetAttribute("id") == "1001")
            {
                xe.SetAttribute("id", "1010");
                foreach (XmlElement xe01 in xe.ChildNodes)
                {
                    if (xe01.GetAttribute("name").Equals("The2"))
                    {
                        xe01.InnerText = "没想到一觉醒来，以前的事情都忘了";
                    }
                }
            }
        }
        doc.Save(path);

    }
    /// <summary>
    /// 读取
    /// </summary>
    void ReadXML()
    {
        if (!File.Exists(path))
        {
            return;
        }
        //创建集合
        ArrayList al01 = new ArrayList();
        ArrayList al02 = new ArrayList();
        XmlDocument doc = new XmlDocument();
        //得到xml文件
        doc.Load(path);
        //得到根节点下所有的子节点
        XmlNodeList nodes = doc.SelectSingleNode("object").ChildNodes;
        //遍历所有的子节点
        foreach (XmlElement ex in nodes)
        {
            if (ex.GetAttribute("id").Equals("1001"))
            {
                foreach (XmlElement ex01 in ex.ChildNodes)
                {
                    if (ex01.Name == "contents")
                    {
                        al01.Add(ex01.GetAttribute("name") + ":" + ex01.InnerText);
                        print(al01[0]);
                    }
                    if (ex01.GetAttribute("name") == "The2")
                    {
                        al02.Add(ex01.GetAttribute("name") + ":" + ex01.InnerText);
                        print(al02[0]);
                    }
                }
            }
        }


    }
}
