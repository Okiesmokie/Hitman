using UnityEngine;
using System.Collections;


/// <summary>
/// A generic class for creating Singletons.
/// </summary>
/// <typeparam name="T">The type of the class</typeparam>
public class Singleton<T> : HitmanBase where T : HitmanBase {
	/// <summary>
	/// The instance of the singleton.
	/// </summary>
	protected static T _instance;


	/// <summary>
	/// Gets the instance of the Singleton.
	/// </summary>
	/// <value>
	/// The instance.
	/// </value>
	public static T instance {
		get {
			if(_instance == null) {
				_instance = (T)FindObjectOfType(typeof(T));

				if(_instance == null) {
					Debug.LogError("An instance of " + typeof(T) +
					   " is needed in the scene, but there is none.");
				}
			}

			return _instance;
		}
	}
}