using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class countdown : MonoBehaviour {

	public Text clock;
	public float timetobeat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float time = timetobeat - Time.timeSinceLevelLoad;
		int minutes = (int)time / 60;
		int seconds = (int)time - minutes * 60;
		clock.text = string.Format ("{0:00}:{1:00}", minutes, seconds);

		if (time == 0f){
			Debug.Log ("Se acabó el tiempo");
		}
	}
}
