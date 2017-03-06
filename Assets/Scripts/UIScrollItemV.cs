using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIScrollItemV : MonoBehaviour
{
    public delegate void cbOnClick();

    private GameObject goContent;
    private GameObject goBtnPrefab;

	// Use this for initialization
	void Start () {
        goContent = transform.Find("view/content").gameObject;
        goBtnPrefab = transform.Find("view/btn_Prefab").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Clear()
    {
        for (int i = goContent.transform.childCount - 1; i >= 0; i-- )
        {
            Destroy(goContent.transform.GetChild(i).gameObject);
        }
    }

    public void AddButton(string strBtn, UnityEngine.Events.UnityAction onClick)
    {
        GameObject goBtn = Instantiate(goBtnPrefab, goContent.transform) as GameObject;
        goBtn.SetActive(true);
        goBtn.GetComponentInChildren<Text>().text = strBtn;
        goBtn.GetComponent<Button>().onClick.AddListener(onClick);
    }
}
