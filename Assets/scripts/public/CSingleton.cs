using UnityEngine;
using System.Collections;

public abstract class CSingletonMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour // 모노비헤이비어에 종속 받는 전역객체를 만들기 위한 클래스
{
	static T instance;

	public static T Instance
	{
		get
		{
			if (null == instance)
			{
				instance = FindObjectOfType(typeof(T)) as T;
				if (null == instance)
				{
					//Debug.Log("Cannot find Manager Instance. Create a new one." + typeof(T).Name);
					GameObject obj = new GameObject(typeof(T).Name);
					instance = obj.AddComponent<T>();
				}
			}

			return instance;
		}
	}
}


public abstract class CSingleton<T> where T : class, new() //모노비헤이비어에 종속받지 않는 전역객체를 만들기 위한 클래스
{
	static T instance;

	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new T();
			}

			return instance;
		}
	}
}
