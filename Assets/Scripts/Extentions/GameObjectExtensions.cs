using UnityEngine;
using System.Collections;

public static class GameObjectExtensions {
	public static void FindParentAndAttach(this GameObject go, string parentName) {
		GameObject memberParent = GameObject.Find(parentName);

		if(memberParent.Equals(null)) {
			memberParent = new GameObject();
			memberParent.name = parentName;
		}

		go.transform.parent = memberParent.transform;
	}
}
