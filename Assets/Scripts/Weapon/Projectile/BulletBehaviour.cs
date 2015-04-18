using UnityEngine;
using System.Collections;

/// <summary>
/// The class that controls the behaviour of the bullet-type projectiles.
/// </summary>
public class BulletBehaviour : HitmanBase {

	/// <summary>
	/// The angle that the bullet is travelling at.
	/// </summary>
	public float angle;

	/// <summary>
	/// The amount of time the bullet will live for.
	/// </summary>
	public float liveTime = 5.0f;

	/// <summary>
	/// The GameObject that spawned the bullet.
	/// </summary>
	public GameObject owner;

	/// <summary>
	/// The rigid body
	/// </summary>
	protected Rigidbody2D rigidBody;


	/// <inheritdoc/>
	protected override void OnStart () {
		rigidBody = GetComponent<Rigidbody2D>();

		gameObject.FindParentAndAttach("Projectiles");

		rigidBody.AddForce(transform.right * 100);
	}


	/// <inheritdoc/>
	protected override void OnUpdate () {
		liveTime -= Time.deltaTime;

		if(liveTime <= 0.0f) Destroy(gameObject);
	}


	/// <inheritdoc/>
	protected override void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject != owner) {
			Destroy(gameObject);
		}
	}


	/// <inheritdoc/>
	protected override void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject != owner) {
			Destroy(gameObject);
		}
	}

}
