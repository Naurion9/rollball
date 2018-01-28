using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class closetable : MonoBehaviour {

	public Button buttonobj;
	public GameObject tablemenu;

	private Button btn;

	void Awake(){
		tablemenu.SetActive (false);
	}


	// Use this for initialization
	void Start () {
		btn = buttonobj.GetComponent<Button> ();
		btn.onClick.AddListener (buttonPressed);
	}

	public void buttonPressed(){
		if (btn.name == "closetb btn") {
			tablemenu.SetActive (false);
		}
	}
}