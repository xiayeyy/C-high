using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Kongfu : MonoBehaviour
{
    public Text tx1;
    // Use this for initialization
    void Start()
    {
        List<L_WuLin> wulinList = new List<L_WuLin>()
        {

            new L_WuLin() {ID = 002, Name = "王扬", Age = 8, Kongfu = "棍棒", Leave = 5},
            new L_WuLin() {ID = 003, Name = "大明", Age = 25, Kongfu = "机枪", Leave = 10},
            new L_WuLin() {ID = 004, Name = "老罗", Age = 81, Kongfu = "念力", Leave = 13},
            new L_WuLin() {ID = 005, Name = "瓜瓜", Age = 2, Kongfu = "睡觉", Leave = 50},
            new L_WuLin() {ID = 006, Name = "大陆", Age = 20, Kongfu = "剑法", Leave = 2},
            new L_WuLin() {ID = 001, Name = "小陆", Age = 18, Kongfu = "剑法", Leave = 1}
        };

        List<L_KongFu> wugongList = new List<L_KongFu>()
        {
            new L_KongFu() {ID = 1, Name = "剑法", Power = 100},
            new L_KongFu() {ID = 2, Name = "棍棒", Power = 50},
            new L_KongFu() {ID = 3, Name = "机枪", Power = 480},
            new L_KongFu() {ID = 4, Name = "念力", Power = 10},
            new L_KongFu() {ID = 5, Name = "睡觉", Power = -5}


        };

        //进行LINQ 查询

        var linq = from m in wulinList where m.Age > 20 && m.ID > 0 select m;

        // var linq2 = from n in kongfu where n.ID  ==5 select n.Name ;


        //扩展方法的写法
        // var res = wulinList.Where(Test);
        var res1 = wulinList.Where(m => m.Kongfu == "剑法" ? true : false); //lambda 表达式写法
        var s = wulinList.Where(m => m.ID > 5).OrderBy(m => m.Leave).ThenBy(m => m.ID);

        //联合查询
        var res2 = from m in wulinList
                   from n in wugongList
                   where m.Kongfu == n.Name && n.Power > 300
                   select new { master = m, gongfu = n };   //临时
                                                            // select m;

        // join on 集合联合
        var res3 = from m in wulinList
                   join n in wugongList on m.Kongfu equals n.Name
                   select new { kongfuList = n, wulinList = m };

        //into group  分组查询
        var res4 = from m in wugongList
                   join n in wulinList on m.Name equals n.Kongfu into mgroup
                   orderby mgroup.Count()
                   select new { kongfuList = m, humancount = mgroup.Count() };

        // group by 分组查询
        var res5 = from m in wulinList
                   group name by m.Kongfu
            into mgroup
                   select new { count = mgroup.Count(), key = mgroup.Key };

        // 量词操作符 any all 判断是否符合条件
        bool b1 = wulinList.Any(m => m.Kongfu == "睡觉");
        bool b2 = wulinList.All(m => m.Kongfu == "睡觉");

        int i = 123;
        foreach (var m in res5)
        {
            tx1.text += m + "\n" + b1 + b2 + i.ToString("00000");
        }
    }

    bool Test(L_WuLin ww)
    {
        if (ww.Kongfu == "剑法") return true;
        return false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
