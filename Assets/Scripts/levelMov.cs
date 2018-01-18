using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelMov : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Gyroscope gyro = Input.gyro;
		if (!gyro.enabled){
			gyro.enabled = true;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		transform.rotation = Input.gyro.attitude;		
	}
}
