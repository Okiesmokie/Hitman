using UnityEngine;
using System.Collections;

/// <summary>
/// The base class for all Game Objects.
/// </summary>
public class HitmanBase : MonoBehaviour {

	/// <summary>
	/// Event that is called when the object is initialized.  Only called when the object is enabled.
	/// </summary>
	protected void Start() {
		OnStart();
	}


	/// <summary>
	/// Event that is called when the object is initialized, regardless of whether or not it is enabled.
	/// </summary>
	protected void Awake() {
		OnAwake();
	}


	/// <summary>
	/// Event that is called once per frame.
	/// </summary>
	protected void Update() {
		if(!GameController.instance.isGamePaused) {
			OnUpdate();
		} else {
			OnUpdatePaused();
		}
	}


	/// <summary>
	/// Event that is called when the object is initialized.  Only called when the object is enabled.
	/// </summary>
	protected virtual void OnStart() { }


	/// <summary>
	/// Event that is called when the object is initialized, regardless of whether or not it is enabled.
	/// </summary>
	protected virtual void OnAwake() { }


	/// <summary>
	/// Event that is called once per frame when the game is not paused.
	/// </summary>
	protected virtual void OnUpdate() { }


	/// <summary>
	/// Event that is called once per frame when the game is paused.
	/// </summary>
	protected virtual void OnUpdatePaused() { }


	/// <summary>
	/// Event that is called when an object enters the trigger collider attached to this object.
	/// </summary>
	/// <param name="collider">The collider of the object that entered.</param>
	protected virtual void OnTriggerEnter2D(Collider2D collider) { }


	/// <summary>
	/// Event that is called when an object collides with this object.
	/// </summary>
	/// <param name="collision">Collision information about the object that collided.</param>
	protected virtual void OnCollisionEnter2D(Collision2D collision) { }

	/// <summary>
	/// Event that is called when the level has been loaded.
	/// </summary>
	/// <param name="level">The level id.</param>
	protected virtual IEnumerator OnLevelWasLoaded(int level) { return null; }


	/// <summary>
	/// Event that is called when the GUI needs to be updated.
	/// </summary>
	protected virtual void OnGUI() { }

}
