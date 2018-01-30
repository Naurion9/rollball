using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playbutton : MonoBehaviour {

	public Button buttonobj;
	public GameObject tablemenu;
	private Button btn;

	// Use this for initialization
	void Start () {
		btn = buttonobj.GetComponent<Button> ();
		btn.onClick.AddListener (buttonPressed);
		Debug.Log (btn.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void buttonPressed(){
		if (btn.name == "Play Button") {
			SceneManager.LoadScene ("level1");
			Time.timeScale = 1;
		} else if (btn.name == "Exit Button") {
			Application.Quit ();
		} else if (btn.name == "hs button") {
			tablemenu.SetActive (true);
			
		}
		
	}
}
