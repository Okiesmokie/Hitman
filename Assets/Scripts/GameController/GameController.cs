using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public partial class GameController : Singleton<GameController> {
	#region Singleton Code
	//public static GameController instance;
	#endregion

	public GameObject playerGameObject;

	private bool doScreenFade = false;

	protected void Awake() {
		if(gameObject == null) {
			return;
		}

		/*#region Singleton Code
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(gameObject);
		}
		#endregion*/

		saveFileName = Application.persistentDataPath + "/gamedata_debug.dat";

		//SaveGame();
		//LoadGame();
	}

	protected override void OnStart() {
		DontDestroyOnLoad(gameObject);
	}

	public IEnumerator ChangeMap(GameObject obj, string levelName, float warpX, float warpY, float directionX, float directionY, bool fadeScreen = true) {
		PlayerCanMove = false;
		doScreenFade = fadeScreen;

		var screenFader = GameObject.FindGameObjectWithTag("ScreenFader").GetComponent<ScreenFader>();

		if(screenFader && fadeScreen) {
			yield return StartCoroutine(screenFader.HUD_FadeOut());
		} else {
			Debug.LogError("Couldn't find screenfader");
		}

		var newPosition = new Vector3(warpX, warpY, 0.0f);

		obj.transform.position = newPosition;
		MainCamera.instance.MoveCameraInstant(newPosition);

		foreach(var animator in obj.GetComponentsInChildren<Animator>()) {
			animator.SetFloat("DirectionX", directionX);
			animator.SetFloat("DirectionY", directionY);
		}

		if(levelName != Application.loadedLevelName && levelName != string.Empty) {
			Application.LoadLevel(levelName);
		}

		if(screenFader && fadeScreen) {
			yield return StartCoroutine(screenFader.HUD_FadeIn());
		}

		PlayerCanMove = true;
	}

	public IEnumerator MapFinishedLoading() {
		var screenFader = GameObject.FindGameObjectWithTag("ScreenFader").GetComponent<ScreenFader>();

		if(screenFader && doScreenFade) {
			doScreenFade = false;
			yield return StartCoroutine(screenFader.HUD_FadeIn());
		}

		PlayerCanMove = true;
	}

	public void PauseGame() {
		Time.timeScale = 0.0f;
		isGamePaused = true;
	}

	public void UnPauseGame() {
		Time.timeScale = 1.0f;
		isGamePaused = false;
	}

	protected virtual void OnGUI() {
		GUI.Label(new Rect(10, 10, 200, 30), string.Format("HP: {0}/{1}", PlayerHP, PlayerMaxHP));
		GUI.Label(new Rect(10, 30, 200, 30), string.Format("Map: {0}", PlayerMap));
		GUI.Label(new Rect(10, 50, 200, 30), string.Format("Position: ({0},{1})", PlayerX, PlayerY));
		GUI.Label(new Rect(10, 70, 200, 30), string.Format("Mouse Angle: {0}", MouseAngle));
	}
}
