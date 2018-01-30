using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class countdown : MonoBehaviour {

	public Text clock;
	public float timetobeat;
	public int points = 0;

	public GameObject player;
	private falloff script;
	// Use this for initialization
	void Start () {
		script = player.GetComponent<falloff> ();

	}
	
	// Update is called once per frame
	void Update () {

		float time = timetobeat - Time.timeSinceLevelLoad;
		int minutes = (int)time / 60;
		int seconds = (int)time - minutes * 60;
		clock.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
		points = (int)(time * 1.5f);

		if (time <= 0f){
			script.timeout ();
			Debug.Log ("Se acabó el tiempo");
		}
	}
}
