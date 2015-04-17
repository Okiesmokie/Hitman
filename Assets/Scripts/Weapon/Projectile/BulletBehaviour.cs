using UnityEngine;
using System.Collections;

public class BulletBehaviour : HitmanBase {
	public float angle;
	public float liveTime = 5.0f;

	public GameObject owner;

	protected Rigidbody2D rigidBody;

	protected override void OnStart () {
		rigidBody = GetComponent<Rigidbody2D>();

		gameObject.FindParentAndAttach("Projectiles");

		rigidBody.AddForce(transform.right * 100);
	}
	
	protected override void OnUpdate () {
		liveTime -= Time.deltaTime;

		if(liveTime <= 0.0f) Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject != owner) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject != owner) {
			Destroy(gameObject);
		}
	}
}
