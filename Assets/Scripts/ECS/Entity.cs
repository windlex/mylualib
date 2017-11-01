using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

enum CONFIG
{
	ERROR_UUID = 0,
}

public class Entity
{
	public int uuid = (int)CONFIG.ERROR_UUID;

	//--------------------------------------------
	protected List<Feature> m_FeatureList;
	public T AddFeature<T>() where T : Feature, new()
	{
		T t = new T();	// todo: 使用对象池优化
		m_FeatureList.Add(t);
		return t;
	}
	public T GetFeature<T>() where T : Feature
	{
		foreach (Feature f in m_FeatureList)
		{
			if (f.GetType() == typeof(T))
				return f as T;
		}
		return null;
	}
}