using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBattle : MonoSingleton<CardBattle> {
	public GameObject Arrows;
	public GameObject[] arrow;
	public Vector3 startPos;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < arrow.Length; i++)
		{
			var scale = (0.2f+i/18f*0.8f);
			arrow[i].transform.localScale = new Vector3(scale,scale,scale);
		}
		startPos = arrow[arrow.Length - 1].transform.position;
		reset(new Vector3(100,100,1));
		Arrows.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void reset(Vector3 endPos)
	{
		//#根据传入的起点和终点来计算两个控制点
		var ctrlAPos=new Vector3();
		var ctrlBPos=new Vector3();
		ctrlAPos.x=startPos.x+(startPos.x-endPos.x)*0.1f; //#这里我把参数做了微调，感觉这样更加符合杀戮尖塔的效果
		ctrlAPos.y=endPos.y-(endPos.y-startPos.y)*0.2f;
		ctrlBPos.y=endPos.y+(endPos.y-startPos.y)*0.3f;
		ctrlBPos.x=startPos.x-(startPos.x-endPos.x)*0.3f;
		//#根据贝塞尔曲线重新设置所有小箭头的位置
		for (int i = 0; i < arrow.Length; i++)
		{
			var t=i/19f;
			var pos=startPos*(1-t)*(1-t)*(1-t)+3*ctrlAPos*t*(1-t)*(1-t)+3*ctrlBPos*t*t*(1-t)+endPos*t*t*t;
			arrow[i].transform.position=pos;
		}
		//#虽然更改了箭头的位置，不过还需要重新计算箭头的方向   
		updateAngle();  // #重新计算所有箭头的方向
	}
	public void updateAngle()
	{
		var a = 90f;
		var zero = new Vector3(90f,0f,0f);
		arrow[0].transform.eulerAngles = new Vector3(0f, 0f, a);    //#第一个小箭头就让他固定朝上好了
		
		for (int i = 1; i < arrow.Length; i++)
		{
            var current=arrow[i];    //#当前的小箭头
            var last=arrow[i-1];     //#前一个小箭头
			var L = last.transform.position;
			var C = current.transform.position;
            var angle =Vector3.Angle(C - L, zero);            //#计算这个向量的角度，这个angle()返回值是弧度
            a += angle;               //#弧度转成角度
           
            current.transform.eulerAngles = new Vector3(0f, 0f, angle);   //#更新小箭头的方向
		}
	}
}
