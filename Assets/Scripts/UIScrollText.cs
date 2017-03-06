using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScrollText : MonoBehaviour {
    public Text text;
    public Scrollbar scrollbar;
	// Use this for initialization
	void Start () {
        text = transform.Find("view/content/Text").GetComponent<Text>();
        //SetText("");
        scrollbar = transform.Find("Scrollbar").GetComponent<Scrollbar>();
	}
	
	// Update is called once per frame
	void Update () {	
	}

    public void SetText(string text)
    {
        this.text.text = text;
    }

    public void onUpdate(System.Object param)
    {
        Debug.Log(param);
        scrollbar.value = ((float)param)/100;
    }
    public void onUpdateTween(float value)
    {
        Debug.Log(value);
        scrollbar.value = value;
    }
    public void AppendText(string text)
    {
        this.text.text += text;
        iTweenHashtable table = new iTweenHashtable();
        Debug.Log(scrollbar.value * 100);
        table.EaseType(iTween.EaseType.easeInOutQuint).From(scrollbar.value).To(0f).Time(0.3);
        table.OnUpdate("onUpdateTween");
        iTween.ValueTo(gameObject, table);
        
       // iTween.ValueTo(gameObject, iTween.Hash("from", 1, "to", 0, "onupdate", "onUpdateTween", "time", 3));
    }
}
