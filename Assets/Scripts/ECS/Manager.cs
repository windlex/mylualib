using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Manager : SingletonMono<Manager>
{
	public bool bUpdate = true;
	public List<Daemon> m_DaemonList = new List<Daemon>();
	public void AddDaemon(Daemon daemon)
	{
		m_DaemonList.Add(daemon);
		daemon.Init();
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
		Debug.Log("AddScriptDaemon " + daemonName);
		AddDaemon(daemon);
		return daemon;
	}
	public void RemoveAllDaemon()
	{
		m_DaemonList.Clear ();
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
		if (!bUpdate)
			return;
		foreach (Daemon d in m_DaemonList)
		{
			d.FixedUpdate();
		}
	}


	public Dictionary<int, Entity> entityMap = new Dictionary<int, Entity>();
	static int entityIdSeed = 1234;
	public Entity CreateEntity()
	{
		Entity entity = new Entity();
		entity.uuid = entityIdSeed++;
		entityMap.Add(entity.uuid, entity);
		return entity;
	}
	public void DestroyEntity(int uuid)
	{
		entityMap.Remove(uuid);
	}
	public Entity GetEntity(int uuid)
	{
		Entity entity;
		entityMap.TryGetValue(uuid, out entity);
		return entity;
	}
}