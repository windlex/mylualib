using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[System.Serializable]
public class Feature
{
	public Entity m_Owner;

	public T GetSibling<T>() where T : Feature
	{
		return m_Owner.GetFeature<T>();
	}	
}