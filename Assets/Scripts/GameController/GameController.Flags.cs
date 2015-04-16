using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class GameController {
	private Dictionary<string, object> gameFlags = new Dictionary<string, object>();

	#region Flag Getting/Setting
	public T GetFlag<T>(string key, T defaultValue = default(T)) {
		T flag;

		try {
			flag = (T)gameFlags[key];
		} catch(KeyNotFoundException) {
			flag = defaultValue;
		}

		return flag;
	}

	public void SetFlag<T>(string key, T value) {
		gameFlags[key] = (object)value;
	}
	#endregion
}
