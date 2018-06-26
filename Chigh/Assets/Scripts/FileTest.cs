using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class FileTest : MonoBehaviour
{

    public Text tx1;

    void Start()
    {
        FileInfo fileInfo = new FileInfo(@"D:\O_O\C#high\c-high\Chigh\Assets\test.txt");
        tx1.text = fileInfo.Exists + "已经找到文件";  //判断该文件是否存在
        tx1.text += "\n" + fileInfo.Name;     //文件名+后缀
        tx1.text += "\n" + fileInfo.DirectoryName;     //文件名路径 不包括文件名

        //fileInfo.Delete();   //文件删除
        //fileInfo.MoveTo("666.txt");
        //DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\O_O\C#high\c-high\Chigh\test");

        //tx1.text += "\n"+ directoryInfo .Exists + "已经找到文件";  //判断该文件是否存在
        //directoryInfo.CreateSubdirectory("666"); //创建子目录
        //directoryInfo.MoveTo("666");

        //File.ReadAllText(@"D:\O_O\C#high\c-high\Chigh\Assets\test.txt");
        //tx1.text += "\n" + File.ReadAllText(@"D:\O_O\C#high\c-high\Chigh\Assets\test.txt"); //读取全部为一个字符串
        string[] str = File.ReadAllLines(@"D:\O_O\C#high\c-high\Chigh\Assets\test.txt"); //按照行来读取

        foreach (var a in str)
        {
            tx1.text += "\n" + a;
        }

        // File.WriteAllText(@"D:\O_O\C#high\c-high\Chigh\Assets\test1.txt", "萨达所大\r\n所大所大所");

        //  fileInfo.CopyTo(@"D:\pc\332666.txt", true);  //文件复制

        FileStream readStream = new FileStream(@"D:\pc\1111.png", FileMode.Open);   //FileStream比较适合2进制文件 比如图片
        FileStream writeStream = new FileStream(@"D:\pc\2222.png", FileMode.Create);

        byte[] data = new byte [1024];
        while (true )
        {
            int length = readStream.Read(data, 0, data.Length);
            if (length == 0)
            {
                tx1.text = "读取成功------------";
                break;
            }
            else
            {
                writeStream.Write(data, 0, data.Length);
            }
        }
    }


    void Update()
    {

    }
}
