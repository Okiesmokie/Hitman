using UnityEngine;
using System.Collections;

/// <summary>
/// The HUD Control Class.
/// </summary>
public class HUDControl : HitmanBase {

	/// <inheritdoc/>
	protected override void OnStart() {
		DontDestroyOnLoad(gameObject);
	}

}
