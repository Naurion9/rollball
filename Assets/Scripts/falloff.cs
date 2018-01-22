using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falloff : MonoBehaviour {

	private Rigidbody player;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider hole){

		switch(hole.tag) {
			case "hole": 
				player.gameObject.SetActive (false);
				Debug.Log ("Se cayó la bola. Game Over");
				break;
			case "meta":
				Debug.Log ("Has completado el nivel!");
				break;
		}
						
	}
}
;