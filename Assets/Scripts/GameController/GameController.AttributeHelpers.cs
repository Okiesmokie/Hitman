using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class GameController {
	#region Player Attributes Helpers	
	/// <summary>
	/// Gets or sets the player hp.
	/// </summary>
	/// <value>
	/// The player hp.
	/// </value>
	public int PlayerHP {
		get {
			return GetFlag<int>("PlayerHP");
		}

		set {
			SetFlag<int>("PlayerHP", value);
		}
	}

	/// <summary>
	/// Gets or sets the player maximum hp.
	/// </summary>
	/// <value>
	/// The player maximum hp.
	/// </value>
	public int PlayerMaxHP {
		get {
			return GetFlag<int>("PlayerMaxHP");
		}

		set {
			SetFlag<int>("PlayerMaxHP", value);
		}
	}

	/// <summary>
	/// Gets or sets the player map.
	/// </summary>
	/// <value>
	/// The player map.
	/// </value>
	public string PlayerMap {
		get {
			return GetFlag<string>("PlayerMap");
		}

		set {
			SetFlag<string>("PlayerMap", value);
		}
	}

	/// <summary>
	/// Gets or sets the player x.
	/// </summary>
	/// <value>
	/// The player x.
	/// </value>
	public float PlayerX {
		get {
			return GetFlag<float>("PlayerX");
		}

		set {
			SetFlag<float>("PlayerX", value);
		}
	}

	/// <summary>
	/// Gets or sets the player y.
	/// </summary>
	/// <value>
	/// The player y.
	/// </value>
	public float PlayerY {
		get {
			return GetFlag<float>("PlayerY");
		}

		set {
			SetFlag<float>("PlayerY", value);
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether [player can move].
	/// </summary>
	/// <value>
	///   <c>true</c> if [player can move]; otherwise, <c>false</c>.
	/// </value>
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

	/// <summary>
	/// Gets or sets the mouse angle.
	/// </summary>
	/// <value>
	/// The mouse angle.
	/// </value>
	public float MouseAngle {
		get {
			return GetFlag<float>("MouseAngle");
		}

		set {
			SetFlag<float>("MouseAngle", value);
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether the game is paused.
	/// </summary>
	/// <value>
	/// <c>true</c> if the game is paused; otherwise, <c>false</c>.
	/// </value>
	public bool isGamePaused {
		get {
			return GetFlag<bool>("isGamePaused", false);
		}

		set {
			SetFlag<bool>("isGamePaused", value);
		}
	}
	#endregion
}
