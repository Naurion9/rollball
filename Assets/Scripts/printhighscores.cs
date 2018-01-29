using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class printhighscores : MonoBehaviour {

	public Text namecolumn;
	public Text scorecolumn;


	// Use this for initialization
	void Start () {
		getTable();
	}
	private string dbname = "testDB.db";
	private void getTable()
	{
		var ds = new DataService (dbname);
//		ds.CreateTopScore ("LEYER", 11);
//		ds.CreateTopScore("ILA", 9999);
//		ds.CreateTopScore ("LUA", 2222);


		var lb = ds.GetLeaderBoard();
		int i = 1;
		string names = "";
		string scores = "";
		foreach (var topScores in lb) {
			names += string.Format ("{0}. {1}\n", i, topScores.name);
			scores += string.Format("{0}\n", topScores.score);
			i++;

		}
		namecolumn.text = names;
		scorecolumn.text = scores;
	}
}