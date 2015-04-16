using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;

public partial class GameController {
	#region Saving and Loading Code
	private string saveFileName;

	public void SaveGame() {
		try {
			using(var fs = new FileStream(saveFileName, FileMode.Create, FileAccess.Write)) {
				var bf = new BinaryFormatter();
				bf.Serialize(fs, gameFlags);

				fs.Close();
			}
		} catch(Exception e) {
			Debug.Log(e.ToString());
		}
	}

	public void LoadGame() {
		if(File.Exists(saveFileName)) {
			try {
				using(var fs = new FileStream(saveFileName, FileMode.Open, FileAccess.Read)) {
					gameFlags.Clear();

					var bf = new BinaryFormatter();
					gameFlags = (Dictionary<string, object>)bf.Deserialize(fs);
				}

				Debug.Log(string.Format("testFlag: {0}", GetFlag<int>("testFlag")));
				Debug.Log(string.Format("secondTestFlag: {0}", GetFlag<string>("secondTestFlag")));
			} catch(Exception e) {
				Debug.Log(e.ToString());
			}
		} else {
			// No save file exists, start a new game
			LoadDefaults();
		}
	}

	private void LoadDefaults() {
		// Default values for a new game
		PlayerHP = 100;
		PlayerMaxHP = 100;
		PlayerMap = "Start";
		PlayerX = 100;
		PlayerY = 100;
	}
	#endregion
}
