using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class wwwJiaZai : MonoBehaviour
{
    public RawImage l_rawImage;
    public Image im1;
    string imgUrl;
    void Start()
    {
        // 代码获取我们的RawImage
        l_rawImage =

            GameObject.Find("RawImage").GetComponent<RawImage>();
        // 网址赋值
        imgUrl = "http://g.hiphotos.baidu.com/image/h%3D360/sign" +
                 "=07ad353ef403738dc14a0a24831ab073/08f790529822720eb2" + "5fa86479cb0a46f31fab9f.jpg";
        // 开启下载图片的协程。
        StartCoroutine(LoadImage());

    }

    // 实现加载协程的方法
    IEnumerator LoadImage()
    {

        // 根据连接下载
        WWW www = new WWW(imgUrl);
        // 等待WWW代码执行完毕之后后面的代码才会执行。
        yield return www;
        // 将下载的textrue在RawImage上展示
        l_rawImage.texture = www.texture;

    }
}
