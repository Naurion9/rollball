using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelMov : MonoBehaviour {

	private float f = 1.0f;

	// Use this for initialization
	void Start () {

		Gyroscope gyro = Input.gyro;
		if (!gyro.enabled){
			gyro.enabled = true;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		Quaternion startRot = transform.rotation;
		Quaternion gyroRot = Input.gyro.attitude;
		Quaternion newRot = new Quaternion(gyroRot.x, gyroRot.z, gyroRot.y, gyroRot.w);
		//Slerp hace el movmiento de newRot a startRot y se usa Inverse para que los ejes
		//correspondan al movimiento real del smartphone
		transform.rotation = Quaternion.Inverse(Quaternion.Slerp(startRot, newRot, f));
	}
}
