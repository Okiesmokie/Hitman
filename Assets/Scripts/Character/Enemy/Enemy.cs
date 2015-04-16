using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public int HP = 10;

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.tag == "Projectile") {
			--HP;
			Debug.Log(string.Format("Enemy hit with bullet;  HP: {0}", HP));

			if(HP <= 0) {
				Destroy(gameObject);
			}
		}
	}
}
