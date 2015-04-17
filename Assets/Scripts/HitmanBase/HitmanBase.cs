using UnityEngine;
using System.Collections;

public class HitmanBase : MonoBehaviour {
	protected void Start() {
		OnStart();
	}

	protected void Update() {
		if(!GameController.instance.isGamePaused) {
			OnUpdate();
		} else {
			OnUpdatePaused();
		}
	}

	protected virtual void OnStart() { }
	protected virtual void OnUpdate() { }
	protected virtual void OnUpdatePaused() { }
}
