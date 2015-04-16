using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class GameController {
	#region Player Attributes Helpers
	public int PlayerHP {
		get {
			return GetFlag<int>("PlayerHP");
		}

		set {
			SetFlag<int>("PlayerHP", value);
		}
	}

	public int PlayerMaxHP {
		get {
			return GetFlag<int>("PlayerMaxHP");
		}

		set {
			SetFlag<int>("PlayerMaxHP", value);
		}
	}

	public string PlayerMap {
		get {
			return GetFlag<string>("PlayerMap");
		}

		set {
			SetFlag<string>("PlayerMap", value);
		}
	}

	public float PlayerX {
		get {
			return GetFlag<float>("PlayerX");
		}

		set {
			SetFlag<float>("PlayerX", value);
		}
	}

	public float PlayerY {
		get {
			return GetFlag<float>("PlayerY");
		}

		set {
			SetFlag<float>("PlayerY", value);
		}
	}

	public bool PlayerCanMove {
		get {
			return GetFlag<bool>("PlayerCanMove", false);
		}

		set {
			if(!value) {
				Debug.Log("FDJSKLFJSDKLF");
			}

			SetFlag<bool>("PlayerCanMove", value);
		}
	}
	#endregion
}
