using UnityEngine;
using System.Collections;
public class iTweenExtension
{
}
public class iTweenHashtable
{
	Hashtable m_innerTable = new Hashtable();
	public iTweenHashtable Name(string name)
	{
		m_innerTable["name"] = name;
		return this;
	}
	public iTweenHashtable From(float val)
	{
		m_innerTable["from"] = val;
		return this;
	}
	public iTweenHashtable From(double val)
	{
		m_innerTable["from"] = val;
		return this;
	}
	public iTweenHashtable From(Vector3 val)
	{
		m_innerTable["from"] = val;
		return this;
	}
	public iTweenHashtable From(Vector2 val)
	{
		m_innerTable["from"] = val;
		return this;
	}
	public iTweenHashtable From(Color val)
	{
		m_innerTable["from"] = val;
		return this;
	}
	public iTweenHashtable From(Rect val)
	{
		m_innerTable["from"] = val;
		return this;
	}
	public iTweenHashtable To(float val)
	{
		m_innerTable["to"] = val;
		return this;
	}
	public iTweenHashtable To(double val)
	{
		m_innerTable["to"] = val;
		return this;
	}
	public iTweenHashtable To(Vector3 val)
	{
		m_innerTable["to"] = val;
		return this;
	}
	public iTweenHashtable To(Vector2 val)
	{
		m_innerTable["to"] = val;
		return this;
	}
	public iTweenHashtable To(Color val)
	{
		m_innerTable["to"] = val;
		return this;
	}
	public iTweenHashtable To(Rect val)
	{
		m_innerTable["to"] = val;
		return this;
	}
	public iTweenHashtable Amount(Vector3 amount)
	{
		m_innerTable["amount"] = amount;
		return this;
	}
	public iTweenHashtable Space(Space space)
	{
		m_innerTable["space"] = space;
		return this;
	}
	public iTweenHashtable Position(Vector3 position)
	{
		m_innerTable["position"] = position;
		return this;
	}
	public iTweenHashtable Rotation(Vector3 rotation)
	{
		m_innerTable["rotation"] = rotation;
		return this;
	}
	public iTweenHashtable Scale(Vector3 scale)
	{
		m_innerTable["scale"] = scale;
		return this;
	}
	public iTweenHashtable IsLocal(bool isLocal)
	{
		m_innerTable["islocal"] = isLocal;
		return this;
	}
	public iTweenHashtable Time(float time)
	{
		m_innerTable["time"] = time;
		return this;
	}
	public iTweenHashtable Time(double time)
	{
		m_innerTable["time"] = time;
		return this;
	}
	public iTweenHashtable Speed(float speed)
	{
		m_innerTable["speed"] = speed;
		return this;
	}
	public iTweenHashtable Speed(double speed)
	{
		m_innerTable["speed"] = speed;
		return this;
	}
	public iTweenHashtable Delay(float delay)
	{
		m_innerTable["delay"] = delay;
		return this;
	}
	public iTweenHashtable Delay(double delay)
	{
		m_innerTable["delay"] = delay;
		return this;
	}
	public iTweenHashtable EaseType(iTween.EaseType easeType)
	{
		m_innerTable["easetype"] = easeType;
		return this;
	}
	public iTweenHashtable LoopType(iTween.LoopType loopType)
	{
		m_innerTable["looptype"] = loopType;
		return this;
	}
	public iTweenHashtable IgnoreTimeScale(bool ignoreTimeScale)
	{
		m_innerTable["ignoretimescale"] = ignoreTimeScale;
		return this;
	}


	public delegate void iTweenCallback();
	public delegate void iTweenCallbackParam(System.Object param);

	public iTweenHashtable OnStart(iTweenCallback onStart)
	{
		m_innerTable["onstart"] = onStart.Method.Name;
		var target = onStart.Target as MonoBehaviour;
		//AssertUtil.Assert(target != null);
		m_innerTable["onstarttarget"] = target.gameObject;
		return this;
	}
	public iTweenHashtable OnStart(iTweenCallbackParam onStart, System.Object param)
	{
		m_innerTable["onstart"] = onStart.Method.Name;
		var target = onStart.Target as MonoBehaviour;
		//AssertUtil.Assert(target != null);
		m_innerTable["onstarttarget"] = target.gameObject;
		// NOTE: seems iTween can not handle this correct... in iTween.CleanArgs, it just do raw element access
		//AssertUtil.Assert(param != null);
		m_innerTable["onstartparams"] = param;
		return this;
	}

    public iTweenHashtable OnUpdate(string updateMethod)
    {
        m_innerTable["onupdate"] = updateMethod;
        //AssertUtil.Assert(target != null);
        //m_innerTable["onupdatetarget"] = target;
        return this;
    }
	public iTweenHashtable OnUpdate(iTweenCallbackParam onUpdate, System.Object param)
	{
		m_innerTable["onupdate"] = onUpdate.Method.Name;
		var target = onUpdate.Target as MonoBehaviour;
		//AssertUtil.Assert(target != null);
		m_innerTable["onupdatetarget"] = target.gameObject;
		// NOTE: seems iTween can not handle this correct ...
		//       in iTween.CleanArgs, it just do raw element access
		//AssertUtil.Assert(param != null);
		m_innerTable["onupdateparams"] = param;
		return this;
	}
	public iTweenHashtable OnComplete(iTweenCallback onComplete)
	{
		m_innerTable["oncomplete"] = onComplete.Method.Name;
		var target = onComplete.Target as MonoBehaviour;
		//AssertUtil.Assert(target != null);
		m_innerTable["oncompletetarget"] = target.gameObject;
		return this;
	}
	public iTweenHashtable OnComplete(iTweenCallbackParam onComplete, System.Object param)
	{
		m_innerTable["oncomplete"] = onComplete.Method.Name;
		var target = onComplete.Target as MonoBehaviour;
		//AssertUtil.Assert(target != null);
		m_innerTable["oncompletetarget"] = target.gameObject;
		// NOTE: seems iTween can not handle this correct ...
		//       in iTween.CleanArgs, it just do raw element access
		//AssertUtil.Assert(param != null);
		m_innerTable["oncompleteparams"] = param;
		return this;
	}
	public void Clear()
	{
		m_innerTable.Clear();
	}
	public static implicit operator Hashtable(iTweenHashtable table)
	{
		return table.m_innerTable;
	}
}