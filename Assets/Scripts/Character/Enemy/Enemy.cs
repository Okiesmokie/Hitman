using UnityEngine;
using System.Collections;

/// <summary>
/// A base class for enemies.
/// </summary>
public class Enemy : HitmanBase {

	/// <summary>
	/// The enemy's HP.
	/// </summary>
	public int HP = 10;

	/// <inheritdoc/>
	protected override void OnStart () {
	}


	/// <inheritdoc/>
	protected override void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.tag == "Projectile") {
			--HP;
			Debug.Log(string.Format("Enemy hit with bullet;  HP: {0}", HP));

			if(HP <= 0) {
				Destroy(gameObject);
			}
		}
	}

}
