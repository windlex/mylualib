using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TextImageMngr
{
}

[AddComponentMenu("UI/TextEx", 10)]
public class UITextEx : Text, IPointerClickHandler
{
	[SerializeField]
	public string m_OutputText;

	[Serializable]
	public class ImagePool
	{
		public Sprite spr;
		public RectTransform rt;
	}
	[SerializeField]
	public List<Image> m_ImagesPool = new List<Image>();
	protected List<int> m_ImagesVertexIdx = new List<int>();
	protected static Regex s_ImageRegex = new Regex(@"<quad name=(.+?) size=(\d*\.?\d+%?) width=(\d*\.?\d+%?) />", RegexOptions.Singleline);

	protected static List<HrefInfo> m_HrefInfos = new List<HrefInfo>();
	protected static StringBuilder s_TextBuilder = new StringBuilder();
	protected static Regex s_HrefRegex = new Regex(@"<a href=([^>\n\s]+)>(.*?)(</a>)", RegexOptions.Singleline);

	[Serializable]
	public class HrefClickEvent : UnityEvent<string> { }

	[SerializeField]
	private HrefClickEvent m_OnHrefClick = new HrefClickEvent();
	public HrefClickEvent onHrefClick
	{
		get { return m_OnHrefClick; }
		set { m_OnHrefClick = value; }
	}


	public override void SetVerticesDirty()
	{
		base.SetVerticesDirty();
		UpdateQuadImage();
	}

	public void UpdateQuadImage()
	{
		m_OutputText = GetOutputText(m_Text);
		Debug.Log("UpdateQuadImage" + m_OutputText);

		m_ImagesVertexIdx.Clear();
		m_ImagesPool.Clear();
		foreach (Match match in s_ImageRegex.Matches(m_OutputText))
		{
			var picIdx = match.Index + match.Length - 1;
			var endIdx = picIdx * 4 + 3;
			var spriteName = match.Groups[1].Value;
			var size = float.Parse(match.Groups[2].Value);
			Debug.Log("UpdateQuadImage.Match"+spriteName.ToString());

			m_ImagesVertexIdx.Add(endIdx);

			if (null != spriteName)
			{
				var resources = new DefaultControls.Resources();
				var go = DefaultControls.CreateImage(resources);
				go.layer = gameObject.layer;
				var rt = go.transform as RectTransform;
				if (rt)
				{
					rt.SetParent(rectTransform);
					rt.localPosition = Vector3.zero;
					rt.localRotation = Quaternion.identity;
					rt.localScale = Vector3.one;
				}
				m_ImagesPool.Add(go.GetComponent<Image>());
				var img = m_ImagesPool[m_ImagesVertexIdx.Count - 1];
				Debug.Log(m_ImagesPool[m_ImagesVertexIdx.Count - 1]);

				img.sprite = TextExImageMngr.GetInstance().GetSprite(spriteName);
				img.rectTransform.sizeDelta = new Vector2(size, size);
			}

		}
	}
	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		var orignText = m_Text;
		m_Text = m_OutputText;
		base.OnPopulateMesh(toFill);
		m_Text = orignText;

		UIVertex vert = new UIVertex();
		for (var i = 0; i < m_ImagesVertexIdx.Count; i++)
		{
			var endIdx = m_ImagesVertexIdx[i];
			var rt = m_ImagesPool[i].rectTransform;
			var size = rt.sizeDelta;
			if (endIdx < toFill.currentVertCount)
			{
				toFill.PopulateUIVertex(ref vert, endIdx);
				rt.anchoredPosition = new Vector2(vert.position.x + size.x / 2, vert.position.y + size.y / 2);

				toFill.PopulateUIVertex(ref vert, endIdx - 3);
				var pos = vert.position;
				for (int j = endIdx, m = endIdx - 3; j > m; j--)
				{
					toFill.PopulateUIVertex(ref vert, endIdx);
					vert.position = pos;
					toFill.SetUIVertex(vert, j);
				}
			}
		}

		if (m_ImagesVertexIdx.Count != 0)
		{
			m_ImagesVertexIdx.Clear();
		}

		foreach (var hrefInfo in m_HrefInfos)
		{
			hrefInfo.boxes.Clear();
			if (hrefInfo.startIndex >= toFill.currentVertCount)
			{
				continue;
			}

			toFill.PopulateUIVertex(ref vert, hrefInfo.startIndex);
			var pos = vert.position;
			var bounds = new Bounds(pos, Vector3.zero);
			for (int i = hrefInfo.startIndex, m = hrefInfo.endIndex; i < m; i++)
			{
				if (i >= toFill.currentVertCount)
					break;

				toFill.PopulateUIVertex(ref vert, i);
				pos = vert.position;
				if (pos.x < bounds.min.x)
				{
					hrefInfo.boxes.Add(new Rect(bounds.min, bounds.size));
					bounds = new Bounds(pos, Vector3.zero);
				}
				else
				{
					bounds.Encapsulate(pos);
				}
			}
			hrefInfo.boxes.Add(new Rect(bounds.min, bounds.size));
		}
	}
	protected virtual string GetOutputText(string outputText)
	{
		Debug.Log("GetOutputText" + text);
		s_TextBuilder.Length = 0;
		m_HrefInfos.Clear();
		var indexText = 0;
		foreach (Match match in s_HrefRegex.Matches(outputText))
		{
			s_TextBuilder.Append(outputText.Substring(indexText, match.Index - indexText));
			s_TextBuilder.Append("<color=blue>");  // 超链接颜色
			var group = match.Groups[1];
			var hrefInfo = new HrefInfo
			{
				startIndex = s_TextBuilder.Length * 4, // 超链接里的文本起始顶点索引
				endIndex = (s_TextBuilder.Length + match.Groups[2].Length - 1) * 4 + 3,
				name = group.Value
			};
			m_HrefInfos.Add(hrefInfo);
			s_TextBuilder.Append(match.Groups[2].Value);
			s_TextBuilder.Append("</color>");
			indexText = match.Index + match.Length;
		}
		s_TextBuilder.Append(outputText.Substring(indexText, outputText.Length - indexText));
		return s_TextBuilder.ToString();
	}
	
	public void OnPointerClick(PointerEventData eventData)
	{
		Vector2 p;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out p);

		foreach (var hrefInfo in m_HrefInfos)
		{
			var boxes = hrefInfo.boxes;
			for (var i = 0; i < boxes.Count; i++)
			{
				if (boxes[i].Contains(p))
				{
					m_OnHrefClick.Invoke(hrefInfo.name);
					return;
				}
			}
		}
	}
	
	protected class HrefInfo
	{
		public int startIndex;
		public int endIndex;
		public string name;
		public List<Rect> boxes = new List<Rect>();
	}
}
