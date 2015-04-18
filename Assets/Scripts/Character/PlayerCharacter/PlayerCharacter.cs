using UnityEngine;
using System.Collections;

/// <summary>
/// The class that controls the behaviour for the Player Character.
/// </summary>
public partial class PlayerCharacter : HitmanBase {
	/// <summary>
	/// A reference to the bullet object.
	/// </summary>
	public GameObject bulletObject;

	/// <summary>
	/// The rigid body.
	/// </summary>
	protected Rigidbody2D rigidBody;

	/// <summary>
	/// The animators.
	/// </summary>
	protected Animator[] animators;


	/// <inheritdoc/>
	protected override void OnStart () {
		rigidBody = GetComponent<Rigidbody2D>();
		animators = GetComponentsInChildren<Animator>();

		DontDestroyOnLoad(gameObject);
		GameController.instance.playerGameObject = gameObject;
		GameController.instance.PlayerCanMove = true;

		if(Application.loadedLevelName == "Start") {
			//HideCharacter(true);
		}
	}


	/// <summary>
	/// Hides the player's sprite and disables the movement based on <paramref name="disableMovement"/>.
	/// </summary>
	/// <param name="disableMovement">True if the player's movement should be disabled.</param>
	protected void HideCharacter(bool disableMovement = false) {
		if(disableMovement) {
			GameController.instance.PlayerCanMove = false;
		}

		var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

		foreach(var renderer in spriteRenderers) {
			renderer.enabled = false;
		}
	}


	/// <summary>
	/// Shows the player's sprite and enables the movement based on <paramref name="enableMovement"/>.
	/// </summary>
	/// <param name="enableMovement">True if the plaeyr's movement should be enabled.</param>
	public void ShowCharacter(bool enableMovement = false) {
		if(!GameController.instance.PlayerCanMove && enableMovement) {
			GameController.instance.PlayerCanMove = true;
		}

		var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

		foreach(var renderer in spriteRenderers) {
			renderer.enabled = true;
		}
	}


	/// <inheritdoc/>
	protected override void OnAwake() {
	}
	

	/// <inheritdoc/>
	protected override void OnUpdate () {
		UpdateMovement();
		FireWeapon();
	}


	/// <inheritdoc/>
	protected override void OnUpdatePaused() {
		if(GameController.instance.isGamePaused) {
			if(Input.GetKeyDown(KeyCode.E)) {
				GameController.instance.UnPauseGame();
			}
		}
	}


	/// <inheritdoc/>
	protected override IEnumerator OnLevelWasLoaded(int level) {
		GameController.instance.PlayerMap = Application.loadedLevelName;

		yield return StartCoroutine(GameController.instance.MapFinishedLoading());

		if(Application.loadedLevelName != "Start") {
			//ShowCharacter(false);
		}
	}
}
