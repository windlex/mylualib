/*
Author:		Augustine
History:	10.29.2015 创建
note   :    单件类。
 * 
fix by zaki 2015-11-30
 */
using System.Collections.Generic;
using UnityEngine;

public class TTSingleton<Type> where Type : new()
{
    private static Type s_Instance = default(Type);
	private static object _lock = new object();
    static public Type GetInstance()
    {
		lock(_lock) {
			if(null == s_Instance) {
				s_Instance = new Type();
			}
			return s_Instance;
		}
    }
}

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour {
	private static T _instance;
	private static object _lock = new object();
	private static bool applicationIsQuitting = false;
	public static T Instance {
		get {
			if(applicationIsQuitting) {
				Debug.LogWarning("[Singleton] Instance "+ typeof(T) +   
					" already destroyed on application quit." +          
					"Won't create again - returning null.");          
				return null;         
			}

			lock(_lock)
			{ 
				if (_instance == null)
				{
					_instance = (T) FindObjectOfType(typeof(T));
					if (_instance == null)
					{
						GameObject singleton = new GameObject();
						_instance = singleton.AddComponent<T>();
						singleton.name = "(singleton) "+ typeof(T).ToString();
#if !UNITY_EDITOR
						DontDestroyOnLoad(singleton);
#endif
						Debug.Log("[Singleton] An instance of " + typeof(T) + 
							" is needed in the scene, so '" + singleton +
							"' was created with DontDestroyOnLoad.");
					} else {
						Debug.Log("[Singleton] Using instance already created: " +
							_instance.gameObject.name);
					}
				}
				return _instance;
			}
		}
	}

    public void OnDestroy () {
		applicationIsQuitting = true;
	}
}


// force Singleton and not Inheritance
// like this
//
//class SingletonClass {
//	private static object _lock = new object();
//	private static SingletonClass _this = null;
//	public static SingletonClass GetInstance() { lock(_lock) { return null == _this ? (_this = new SingletonClass()) : _this; } }
//	private SingletonClass() { }
//}
//
// replace all 'SingletonClass' to your class name

