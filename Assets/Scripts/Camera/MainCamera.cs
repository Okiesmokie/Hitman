using UnityEngine;
using System.Collections;

/// <summary>
/// The class that controls the behaviour of the main camera.
/// </summary>
public class MainCamera : Singleton<MainCamera> {

	/// <summary>
	/// The object the camera will follow.
	/// </summary>
	public Transform target;

	/// <summary>
	/// The scale factor.
	/// </summary>
	public float scaleFactor = 4.0f;

	private Camera mainCamera;

	/// <inheritdoc/>
	protected override void OnStart() {
		mainCamera = GetComponent<Camera>();
		DontDestroyOnLoad(gameObject);
	}
	
	/// <inheritdoc/>
	protected override void OnUpdate() {
		mainCamera.orthographicSize = (Screen.height / 100.0f) / scaleFactor;

		if(target) {
			transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(0.0f, 0.0f, -10.0f);
		}
	}

	/// <summary>
	/// Moves the camera instantaneously.
	/// </summary>
	/// <param name="position">The position to move to</param>
	public void MoveCameraInstant(Vector3 position) {
		transform.position = position;
	}

	/// <summary>
	/// Changes the camera's target.
	/// </summary>
	/// <param name="newTarget">The new target.</param>
	public void ChangeCameraTarget(Transform newTarget) {
		target = newTarget;
	}

}
