using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// The class responsible for handling game operations.
/// </summary>
public partial class GameController : Singleton<GameController> {

	/// <summary>
	/// A reference to the Player Character's GameObject
	/// </summary>
	public GameObject playerGameObject;

	private bool doScreenFade = false;


	/// <inheritdoc/>
	protected override void OnAwake() {
		saveFileName = Application.persistentDataPath + "/gamedata_debug.dat";

		//SaveGame();
		//LoadGame();
	}


	/// <inheritdoc/>
	protected override void OnStart() {
		DontDestroyOnLoad(gameObject);
	}


	/// <summary>
	/// Changes the current map.
	/// </summary>
	/// <param name="obj">The object to change the position of.</param>
	/// <param name="levelName">The name of the level.</param>
	/// <param name="warpX">The x-coordinate to move to.</param>
	/// <param name="warpY">The y-coordinate to move to.</param>
	/// <param name="directionX">The x value of the direction.</param>
	/// <param name="directionY">The y value of the direction.</param>
	/// <param name="fadeScreen">if set to <c>true</c> [fade the screen].</param>
	/// <returns></returns>
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


	/// <summary>
	/// Called by the PlayerCharacter object when the level has finished loading.
	/// </summary>
	public IEnumerator MapFinishedLoading() {
		var screenFader = GameObject.FindGameObjectWithTag("ScreenFader").GetComponent<ScreenFader>();

		if(screenFader && doScreenFade) {
			doScreenFade = false;
			yield return StartCoroutine(screenFader.HUD_FadeIn());
		}

		PlayerCanMove = true;
	}


	/// <summary>
	/// Pauses the game.
	/// </summary>
	public void PauseGame() {
		Time.timeScale = 0.0f;
		isGamePaused = true;
	}


	/// <summary>
	/// UnPauses the game.
	/// </summary>
	public void UnPauseGame() {
		Time.timeScale = 1.0f;
		isGamePaused = false;
	}


	/// <inheritdoc/>
	protected override void OnGUI() {
		GUI.Label(new Rect(10, 10, 200, 30), string.Format("HP: {0}/{1}", PlayerHP, PlayerMaxHP));
		GUI.Label(new Rect(10, 30, 200, 30), string.Format("Map: {0}", PlayerMap));
		GUI.Label(new Rect(10, 50, 200, 30), string.Format("Position: ({0},{1})", PlayerX, PlayerY));
		GUI.Label(new Rect(10, 70, 200, 30), string.Format("Mouse Angle: {0}", MouseAngle));
	}
}
