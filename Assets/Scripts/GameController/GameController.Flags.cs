using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class GameController {
	private Dictionary<string, object> gameFlags = new Dictionary<string, object>();

	#region Flag Getting/Setting	
	/// <summary>
	/// Gets the value of the flag specified by <paramref name="key"/>.
	/// </summary>
	/// <typeparam name="T">The type of the flag to retrieve.</typeparam>
	/// <param name="key">The name of the flag.</param>
	/// <param name="defaultValue">The default value.</param>
	/// <returns>The value of the flag.</returns>
	public T GetFlag<T>(string key, T defaultValue = default(T)) {
		T flag;

		try {
			flag = (T)gameFlags[key];
		} catch(KeyNotFoundException) {
			flag = defaultValue;
		}

		return flag;
	}


	/// <summary>
	/// Sets the flag specified by <paramref name="key"/>.
	/// </summary>
	/// <typeparam name="T">The type of the flag to set.</typeparam>
	/// <param name="key">The name of the flag.</param>
	/// <param name="value">The value to set the flag to.</param>
	public void SetFlag<T>(string key, T value) {
		gameFlags[key] = (object)value;
	}
	#endregion
}
