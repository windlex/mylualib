using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Manager : SingletonMono<Manager>
{
	public List<Daemon> m_DaemonList;
	public void AddDaemon(Daemon daemon)
	{
		m_DaemonList.Add(daemon);
	}
	public T AddDaemon<T>() where T : Daemon, new()
	{
		T t = new T();
		m_DaemonList.Add(t);
		return t;
	}
	public Daemon AddScriptDaemon(string daemonName)
	{
		Daemon daemon = new ScriptDaemon(daemonName);
		AddDaemon(daemon);
		return daemon;
	}
	// public void RemoveDaemon(Daemon d)
	public T GetDaemon<T>() where T : Daemon
	{
		foreach (Daemon d in m_DaemonList)
		{
			if (d.GetType() == typeof(T))
				return d as T;
		}
		return null;
	}
	public void FixedUpdate()
	{
		foreach (Daemon d in m_DaemonList)
		{
			d.FixedUpdate();
		}
	}
}