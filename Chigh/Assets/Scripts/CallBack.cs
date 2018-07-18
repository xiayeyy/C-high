using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CallBack : MonoBehaviour

{
    // 定义具有返回值bool的委托 ，参数采用泛型改写
    public delegate bool ComparisonEventHandler<T>(T cryID);

    public int cryid = 0;
    public GameObject[] objs;
    // Use this for initialization
    void Start()
    {
        // 给委托类型的变量赋值
        ComparisonEventHandler<int> _Comparison = Comparison01;
        bool iscry = _Comparison(cryid);
        //给此委托变量再绑定一个返回bool的方法
        ComparisonEventHandler<bool> _Comparisons = Comparison02;
        _Comparisons(iscry);
    }
    /// <summary>
    /// 方法01
    /// </summary>
    /// <param name="cryid"></param>
    /// <returns></returns>
    public bool Comparison01(int cryid)
    {
        //...操作一些东西
        int num = 1;
        if (num == cryid)
        {
            objs[0].SetActive(false);
            objs[1].SetActive(false);
            Debug.Log(string.Format("返回为true，恭喜找到baby哭的原因."));
            return true;
        }
        else
        {
            Debug.Log(string.Format("返回为false，未找到baby哭的原因"));
            return false;
        }
    }

    /// <summary>
    /// 方法02
    /// </summary>
    /// <param name="cryid"></param>
    /// <returns></returns>
    public bool Comparison02(bool iscry)
    {
        //...操作一些东西
        if (iscry)
        {
            Debug.Log(string.Format("baby心情 不错，增加亲密度+60."));
            return true;
        }
        else
        {
            Debug.Log(string.Format("baby心情 很差，降低亲密度-20."));
            return false;
        }
    }
}