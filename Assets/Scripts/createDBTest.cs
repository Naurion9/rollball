using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class createDBTest : MonoBehaviour {


	// Use this for initialization
	void Start () {
		StartSync();
	}
	private string dbname = "testDB.db";
	private void StartSync()
	{
		var ds = new DataService (dbname);
		if (File.Exists(string.Format(@"Assets/StreamingAssets/{0}", dbname))){
			ds.CreateTopScore ("LEYER", 11);
		} else {
			ds.CreateDB();
			ds.CreateTopScore("ILA", 9999);
			ds.CreateTopScore ("LUA", 2222);
		}


		var lb = ds.GetLeaderBoard();
		Debug.Log(string.Format("{0}", lb.ElementAt(0).name));

		foreach (var topScores in lb) {
			Debug.Log (topScores.name);
		}
	}
}