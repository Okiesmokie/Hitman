using UnityEngine;
using System.Collections;

/// <summary>
/// Extensions for the GameObject class.
/// <see cref="GameObject"/>
/// </summary>
public static class GameObjectExtensions {

	/// <summary>
	/// Finds the parent and attaches the <paramref name="go"/> to it.
	/// </summary>
	/// <param name="go">The game object.</param>
	/// <param name="parentName">The name of the parent to attach to.</param>
	public static void FindParentAndAttach(this GameObject go, string parentName) {
		GameObject memberParent = GameObject.Find(parentName);

		if(memberParent.Equals(null)) {
			memberParent = new GameObject();
			memberParent.name = parentName;
		}

		go.transform.parent = memberParent.transform;
	}

}
