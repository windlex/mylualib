using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCard : MonoBehaviour {
	Vector3 big = new Vector3(1.2f,1.2f,1.2f);
	Vector3 normal = new Vector3(1f,1f,1f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Enter()
	{
		transform.localScale = big;
	}
	public void Exit()
	{
		transform.localScale = normal;
	}
	public void Drag()
	{
		transform.SetParent(GameObject.Find("TempCards").transform);
		transform.localPosition = new Vector3(1,1,1);
		// transform.position = Input.mousePosition;
		CardBattle.instance.reset(Input.mousePosition);
		CardBattle.instance.Arrows.SetActive(true);
	}
	public void Up()
	{
		transform.SetParent(GameObject.Find("Cards").transform);
		CardBattle.instance.Arrows.SetActive(false);
	}
}
