using UnityEngine;
using System.Collections;

public partial class PlayerCharacter {
	public float playerSpeed = 1.0f;

	/// <summary>
	/// Handles the player's movement.
	/// </summary>
	protected void UpdateMovement () {
		var movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		// Face player in the direction of the mouse
		var screenPos = Camera.main.WorldToScreenPoint(transform.position);
		var mouseDir = Input.mousePosition - screenPos;
		float mouseAngle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
		GameController.instance.MouseAngle = mouseAngle;

		float vecX = 0, vecY = 0;

		if(Mathf.Abs(mouseAngle) >= 45 && Mathf.Abs(mouseAngle) <= 135) vecY = 1.0f * Mathf.Sign(mouseAngle);
		else if(Mathf.Abs(mouseAngle) < 90) vecX = 1.0f;
		else vecX = -1.0f;

		var lookDirection = new Vector2(vecX, vecY);

		if(!GameController.instance.PlayerCanMove) {
			movementVector = Vector2.zero;
		}

		foreach(var animator in animators) {
			animator.SetBool("isWalking", (movementVector != Vector2.zero));
			animator.SetFloat("DirectionX", lookDirection.x);
			animator.SetFloat("DirectionY", lookDirection.y);
		}

		if(movementVector != Vector2.zero) {
			// Player is moving

			rigidBody.MovePosition(rigidBody.position + (movementVector * playerSpeed) * Time.deltaTime);

			// Update the player X and Y coordinates within the GameControl object
			GameController.instance.PlayerX = rigidBody.position.x;
			GameController.instance.PlayerY = rigidBody.position.y;
		} else {
			foreach(var animator in animators) {
				animator.SetBool("isWalking", false);
			}
		}
	}


	/// <summary>
	/// Handles the player's attacks.
	/// </summary>
	protected void FireWeapon() {
		if(Input.GetMouseButtonDown(0)) {
			// Get the angle of the bullet
			var bulletOffset = new Vector3(0.0f, -0.16f, 0.0f);
			var bulletPos = transform.position + bulletOffset;

			var bulletPosOnScreen = Camera.main.WorldToScreenPoint(bulletPos);
			var dir = Input.mousePosition - bulletPosOnScreen;
			float bulletAngle = Mathf.Atan2(dir.y, dir.x);
			
			bulletPos.x += Mathf.Cos(bulletAngle) * 0.2f;
			bulletPos.y += Mathf.Sin(bulletAngle) * 0.2f;

			var bullet = Instantiate(bulletObject, bulletPos, Quaternion.Euler(0.0f, 0.0f, bulletAngle * Mathf.Rad2Deg)) as GameObject;
			bullet.GetComponent<BulletBehaviour>().owner = gameObject;
		}

		if(Input.GetKeyDown(KeyCode.E)) {
			if(!GameController.instance.isGamePaused) {
				GameController.instance.PauseGame();
			}
		}
	}

}
