using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaiXuTest : MonoBehaviour {

    public Text tx1;
    int[] iArrary = new int[] { 1, 5, 3, 6, 10, 55, 9, 2, 87, 12, 34, 75, 33, 47 };

    void Start ()
    {
        //ZhijieCharu(iArrary);
        //JianDanXuanZhe(iArrary);
        //MaoPao(iArrary);
        XiEr(iArrary);
        foreach (var v in iArrary)
        {
            tx1 .text += v + ", ";
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ZhijieCharu(int[] num)
    {
        //从第二位开始，和前面所有的元素比较，比i大的就向后移动
        for (int i = 1; i < num.Length; i++)
        {
            int Ivalue = num[i];
            bool isInsert = false;
            for (int j = i - 1; j >=0; j--)
            {
                if (num[j] >Ivalue )
                {
                   num[j+1]=num[j];
                }
                else
                {
                    num[j + 1] = Ivalue;
                    isInsert = true;
                    break;
                }
            }

            if (!isInsert)
            {
                num[0] = Ivalue;
            }
        }
    }

    void JianDanXuanZhe(int[] num)
    {
        //首先在未排序序列中找到最小（大）元素，存放到排序序列的起始位置，然后，再从剩余未排序元素中继续寻找最小（大）元素，然后放到已排序序列的末尾。
        for (int i = 0; i < num.Length; i++)
        {
            int minnum = num[i];
            int minindex = i;
            for (int j = i + 1; j < num.Length; j++)
            {
                if (num[j] < minnum)
                {
                    minnum = num[j];
                    minindex = j;
                }
            }

            if (minindex != i)
            {
                int temp = num[i];
                num[i] = num[minindex];
                num[minindex] = temp;
            }
        }
    }

     void MaoPao(int[] num)
    {
        bool flag;
        for (int i = num.Length  - 1; i > 0; i--)
        {
            flag = true;
            for (int j = 0; j < i; j++)
            {
                if (num[j] > num[j + 1])
                {
                    int temp = num[j];
                    num [j]=num[j+1];
                    num[j+1]=temp;
                    flag = false;
                }
            }
            if (flag) break;
        }
    }

    void XiEr(int[] num)
    {
        int temp;
        for (int gap = num.Length / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < num.Length; i++)      // i+ = gap 改为了 i++
            {
                temp = num[i];
                for (int j = i - gap; j >= 0; j -= gap)
                {
                    if (num[j] > temp)
                    {
                        num[j + gap] = num[j];
                        if (j == 0)
                        {
                            num[j] = temp;
                            break;
                        }
                    }
                    else
                    {
                        num[j + gap] = temp;
                        break;
                    }
                }
            }
        }
    }
    

}
