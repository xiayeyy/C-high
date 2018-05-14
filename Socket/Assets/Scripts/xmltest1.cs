using System;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Address
{
    /// <summary>  
    /// 地址数据  
    /// </summary>  
    public class AddressData
    {
        /// <summary>  
        ///当前城市ID  
        /// </summary>  
        public static string _nowProvinceId;

        /// <summary>  
        /// 所有省名字  
        /// </summary>  
        public static List<string> allProvinceName = new List<string>();

        /// <summary>  
        /// 所有城市id  
        /// </summary>  
        public List<string> allCityId = new List<string>();

        ///<summary>  
        ///所有城市名字  
        ///</summary>  
        public List<string> allCityName = new List<string>();

        public static string localUrl = Application.streamingAssetsPath + "/XMLFile1.xml";

        /// <summary>  
        /// 加载xml文档  
        /// </summary>  
        /// <returns></returns>  
        public static XmlDocument ReadAndLoadXml()
        {
            XmlDocument doc = new XmlDocument();
            Debug.Log("加载xml文档");
            doc.Load(localUrl);
            return doc;
        }

        /// <summary>  
        /// 从本地加载xml并获取所有省的名字  
        /// </summary>  
        /// <param name="url"></param>  
        /// <returns></returns>  
        public static List<string> GetAllProvinceName()
        {
            List<string> _allProvinceName = new List<string>();

            XmlDocument xmlDoc = ReadAndLoadXml();

            //所有province节点  
            XmlNode provinces = xmlDoc.SelectSingleNode("provinces");

            foreach (XmlNode province in provinces)
            {
                XmlElement _province = (XmlElement)province;

                //所有provinceName添加到列表  
                allProvinceName.Add(_province.GetAttribute("name"));
            }
            Debug.Log("所有省数目" + allProvinceName.Count);
            _allProvinceName = allProvinceName;
            return _allProvinceName;
        }

        /// <summary>  
        /// 根据当前省ID返回当前省的所有城市名  
        /// </summary>  
        /// <param name="nowProvinceId"></param>  
        /// <returns></returns>  
        public static List<string> GetAllCityNameByNowProvinceId(string nowProvinceId)
        {
            List<string> nowAllCityName = new List<string>();
            XmlDocument xmlDoc = ReadAndLoadXml();
            //所有province节点  
            XmlNode provinces = xmlDoc.SelectSingleNode("provinces");
            foreach (XmlNode province in provinces)
            {
                XmlElement _province = (XmlElement)province;

                //当前城市id  
                if (nowProvinceId == _province.GetAttribute("id"))
                {
                    foreach (XmlElement city in _province.ChildNodes)
                    {
                        XmlElement _city = (XmlElement)city;
                        //当前城市的所有cityName添加到列表  
                        nowAllCityName.Add(_city.GetAttribute("name"));
                    }
                }
            }
            return nowAllCityName;
        }

        /// <summary>  
        /// 根据省的ID返回省的名字  
        /// </summary>  
        /// <param name="provinceId"></param>  
        /// <returns></returns>  
        public static string GetProvinceName(string provinceId)
        {
            string _provinceName = "";
            XmlDocument xmlDoc = ReadAndLoadXml();
            //所有province节点  
            XmlNode provinces = xmlDoc.SelectSingleNode("provinces");

            foreach (XmlNode province in provinces)
            {
                XmlElement _province = (XmlElement)province;
                if (provinceId == _province.GetAttribute("id"))
                {
                    //获取实际省名  
                    _provinceName = _province.GetAttribute("name");
                }
            }
            return _provinceName;
        }

        /// <summary>  
        /// 根据城市ID返会城市名字  
        /// </summary>  
        /// <param name="cityId"></param>  
        /// <returns></returns>  
        public static string GetCityName(string cityId)
        {
            string cityName = "";
            XmlDocument xmlDoc = ReadAndLoadXml();
            //根节点  
            XmlNode provinces = xmlDoc.SelectSingleNode("provinces");

            foreach (XmlNode province in provinces)
            {
                XmlElement _province = (XmlElement)province;
                if (_nowProvinceId == _province.GetAttribute("id"))
                {
                    foreach (XmlElement city in _province.ChildNodes)
                    {
                        XmlElement _city = (XmlElement)city;

                        if (cityId == _city.GetAttribute("id"))
                        {
                            //获取实际城市名  
                            cityName = _city.GetAttribute("name");
                        }
                    }
                }
            }
            return cityName;
        }
    }

}