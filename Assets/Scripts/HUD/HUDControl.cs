using UnityEngine;
using System.Collections;

public class HUDControl : HitmanBase {
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
}
