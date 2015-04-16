using UnityEngine;
using System.Collections;

public partial class PlayerCharacter {
	protected void UpdateMovement () {
		var movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		Debug.Log(string.Format("Updating Movement: {0},{1}", movementVector.x, movementVector.y));

		if(!GameController.instance.PlayerCanMove) {
			movementVector = Vector2.zero;
		}

		if(movementVector != Vector2.zero) {
			// Player is moving
			foreach(var animator in animators) {
				animator.SetBool("isWalking", true);
				animator.SetFloat("DirectionX", movementVector.x);
				animator.SetFloat("DirectionY", movementVector.y);
			}

			rigidBody.MovePosition(rigidBody.position + movementVector * Time.deltaTime);

			// Update the player X and Y coordinates within the GameControl object
			GameController.instance.PlayerX = rigidBody.position.x;
			GameController.instance.PlayerY = rigidBody.position.y;
		} else {
			foreach(var animator in animators) {
				animator.SetBool("isWalking", false);
			}
		}
	}

	protected void FireWeapon() {
		if(Input.GetMouseButtonDown(0)) {
			//Debug.Log(string.Format("{0},{1},{2}", Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));

			var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


			var bullet = Instantiate(bulletObject, pos, Quaternion.Euler(45, 0, 0)) as GameObject;
			//bullet.transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f), 10.0f);

			Debug.DrawRay(transform.position, pos, Color.red);
		}
	}
}
