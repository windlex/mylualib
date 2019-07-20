using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ECSUtils
{
	[System.Serializable]
	public class testDaemon : Daemon
	{
		public override int FixedUpdate()
		{
			//Logic.Instance.AddText ("C# Test Daemon:FixedUpdate");
			return 1;
		}

	}
	public static void Setup()
	{
		Manager.Instance.AddDaemon<testDaemon> ();
	}
}