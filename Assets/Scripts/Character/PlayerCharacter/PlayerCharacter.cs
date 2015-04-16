using UnityEngine;
using System.Collections;

/*
 * PlayerSprite is a class with player-controlled movement
 */
public partial class PlayerCharacter : MonoBehaviour {
	// Properties
	public GameObject bulletObject;

	protected Rigidbody2D rigidBody;
	protected Animator[] animators;

	// Use this for initialization
	protected void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		animators = GetComponentsInChildren<Animator>();

		DontDestroyOnLoad(gameObject);
		GameController.instance.playerGameObject = gameObject;
		GameController.instance.PlayerCanMove = true;

		if(Application.loadedLevelName == "Start") {
			//HideCharacter(true);
		}
	}

	protected void HideCharacter(bool disableMovement = false) {
		if(disableMovement) {
			GameController.instance.PlayerCanMove = false;
		}

		var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

		foreach(var renderer in spriteRenderers) {
			renderer.enabled = false;
		}
	}

	public void ShowCharacter(bool enableMovement = false) {
		if(!GameController.instance.PlayerCanMove && enableMovement) {
			GameController.instance.PlayerCanMove = true;
		}

		var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

		foreach(var renderer in spriteRenderers) {
			renderer.enabled = true;
		}
	}

	protected void OnAwake() {
	}
	
	// Update is called once per frame
	protected void Update () {
		UpdateMovement();
		//FireWeapon();
	}

	/*
	protected IEnumerator OnLevelWasLoaded(int level) {
		GameController.instance.PlayerMap = Application.loadedLevelName;

		yield return StartCoroutine(GameController.instance.MapFinishedLoading());

		if(Application.loadedLevelName != "Start") {
			//ShowCharacter(false);
		}
	}*/
}
