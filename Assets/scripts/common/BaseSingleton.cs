using UnityEngine;
using System.Collections;

/// <summary>
/// Base singleton. singletonのベースとなるクラス
/// </summary>
public class BaseSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;
	public static T instance
	{
		get {
			if (_instance == null)
			{
				_instance = (T)FindObjectOfType(typeof(T));
				
				if (_instance == null)
				{ 
					Debug.LogError (typeof(T) + "is nothin g");
				}
			}
			
			return _instance;
		}
	}
}