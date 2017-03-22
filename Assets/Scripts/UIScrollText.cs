using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIScrollText : MonoBehaviour {
    public Scrollbar scrollbar;
	private GameObject goContent;
	private GameObject goTextPrefab;
	private GameObject goTextBGPrefab;

	void Awake () {
        scrollbar = transform.Find("Scrollbar").GetComponent<Scrollbar>();

		goContent = transform.Find("view/content").gameObject;
		goTextPrefab = transform.Find("view/LinkText").gameObject;
		goTextBGPrefab = transform.Find("view/LinkTextBG").gameObject;
	}
	
	// Update is called once per frame
	void Update () {	
	}

	public void Clear()
	{
		for (int i = goContent.transform.childCount - 1; i >= 0; i--)
		{
			Destroy(goContent.transform.GetChild(i).gameObject);
		}
	}

    public void onUpdate(System.Object param)
    {
        //Debug.Log(param);
        scrollbar.value = ((float)param)/100;
    }
    public void onUpdateTween(float value)
    {
        //Debug.Log(value);
        scrollbar.value = value;
    }
    public void AppendText(string text)
    {
		//GameObject goText = Instantiate(goTextPrefab, goContent.transform) as GameObject;
		//goText.SetActive(true);
		//var txt = goText.GetComponentInChildren<LinkImageText>();
		//txt.text = text;

		GameObject goTextBG = Instantiate(goTextBGPrefab, goContent.transform) as GameObject;
		goTextBG.SetActive(true);
		var txtBG = goTextBG.GetComponentInChildren<LinkImageText>();
		txtBG.text = text;
		LayoutElement f = goTextBG.GetComponent<LayoutElement>();
		f.preferredHeight = txtBG.preferredHeight + 16;
		txtBG.onHrefClick.AddListener(Logic.Instance.OnHrefEvent);
		//txtBG.gameObject.AddComponent<testHref>();

		iTweenHashtable table = new iTweenHashtable();
        table.EaseType(iTween.EaseType.easeInOutQuint).From(scrollbar.value).To(0f).Time(1.0);
        table.OnUpdate("onUpdateTween");
        iTween.ValueTo(gameObject, table);
        
       // iTween.ValueTo(gameObject, iTween.Hash("from", 1, "to", 0, "onupdate", "onUpdateTween", "time", 3));
    }
}
