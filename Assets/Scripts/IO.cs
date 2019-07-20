using System;
using UnityEngine;
using System.IO;

public class Utl
{
	public static void LoadSprite(string loadpath, out Sprite sprite)
    {
        double startTime = (double) Time.time;
        //创建文件流
        FileStream fileStream = new FileStream(loadpath, FileMode.Open, FileAccess.Read);
        fileStream.Seek(0, SeekOrigin.Begin);
        //创建文件长度的缓冲区
        byte[] bytes = new byte[fileStream.Length];
        //读取文件
        fileStream.Read(bytes, 0, (int) fileStream.Length);
        //释放文件读取liu
        fileStream.Close();
        fileStream.Dispose();
        fileStream = null;

        //创建Texture
        Texture2D texture2D = new Texture2D(1, 1);
        texture2D.LoadImage(bytes);

        sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height),
            new Vector2(0.5f, 0.5f));
        double time = (double) Time.time - startTime;
        Debug.Log("IO加载用时：" + time);
    }
}