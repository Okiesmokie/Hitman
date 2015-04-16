using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
	public float angle;
	public float liveTime = 5.0f;

	public GameObject owner;

	protected Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		Debug.Log("Bullet created");

		rigidBody = GetComponent<Rigidbody2D>();

		rigidBody.AddForce(transform.right * 100);
	}
	
	// Update is called once per frame
	void Update () {
		liveTime -= Time.deltaTime;

		if(liveTime <= 0.0f) Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject != owner) {
			Debug.Log("TRIGGER ENTER");
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject != owner) {
			Debug.Log("COLLISION ENTER");
			Destroy(gameObject);
		}
	}
}
