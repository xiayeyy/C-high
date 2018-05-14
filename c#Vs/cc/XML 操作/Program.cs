using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_操作
{
    class Program
    {
        static void Main(string[] args)
        {
            P1();
            P2();
        }

        static public void P1()
        {
            List<Skill> skillList = new List<Skill>(); //创建技能集合

            XmlDocument xmlDoc = new XmlDocument();   //专门用来解析xml类
            xmlDoc.Load("XMLskill.txt");

            XmlNode xmlNode = xmlDoc.FirstChild; //获得根节点

            XmlNodeList nodeList = xmlNode.ChildNodes; //返回所有子节点，得到节点的集合

            foreach (XmlNode skill in nodeList)
            {
                Skill sk = new Skill();

                XmlNodeList skill_list = skill.ChildNodes;  //获得子节点下面的信息 
                foreach (XmlNode skillInfo in skill_list)
                {
                    if (skillInfo.Name == "id")  //获取节点的名字
                    {
                        int id = int.Parse(skillInfo.InnerText);  //获取节点内部的文本
                        sk.Id = id;
                    }
                    else if (skillInfo.Name == "name")  //获取节点的名字
                    {
                        sk.Name = skillInfo.InnerText;
                        sk.Language = skillInfo.Attributes[0].Value; //获得第一个属性的值
                    }
                    else if (skillInfo.Name == "damage")
                    {
                        sk.Damage = int.Parse(skillInfo.InnerText);
                    }

                }
                skillList.Add(sk);

            }

            foreach (Skill sk1 in skillList)
            {
                Console.WriteLine(sk1);

            }
            Console.ReadKey();
        }

        static public void P2()
        {
            List<SkillInfo> skillInfosList = new List<SkillInfo>();

            XmlDocument xmlDocument2 = new XmlDocument();

            xmlDocument2.Load("xml技能信息.txt");
            XmlNode xmlNode2 = xmlDocument2.FirstChild;
            XmlNodeList nodeList2 = xmlNode2.ChildNodes;
            foreach (XmlNode node in nodeList2)
            {
                XmlNodeList skillInfos_List0 = node.ChildNodes;
                foreach (XmlNode skill0 in skillInfos_List0)
                {
                    SkillInfo sk2 = new SkillInfo();

                    XmlNodeList skillInfos_List = skill0.ChildNodes;
                    foreach (XmlNode skill in skillInfos_List)
                    {
                       if (skill.Name == "Skill")
                        {

                            sk2.SkillID = int.Parse(skill.Attributes[0].Value);
                            sk2.SkillEngName = skill.Attributes[1].Value;
                            sk2.TriggerType = int.Parse(skill.Attributes[2].Value);
                            sk2.ImageFile = skill.Attributes[3].Value;
                            sk2.AvailableRace = int.Parse(skill.Attributes[4].Value);
                        }
                       // else if (skill.Name == "Name")
                        {
                            //sk2.Name = skill.InnerText;
                        }
                        skillInfosList.Add(sk2);


                    }

                   

                }

            }
            foreach (SkillInfo skillInfo in skillInfosList)
            {
                Console.WriteLine(skillInfo);
            }
            Console.ReadKey();
        }

        static public void P3()
        {
            XmlDocument x = new XmlDocument();
            x.Load("xml技能信息.txt");

            XmlNodeList xmlNodeList = x.SelectSingleNode("SkillList").ChildNodes;


        }
    }
}
