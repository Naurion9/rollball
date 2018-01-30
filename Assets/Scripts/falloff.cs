using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class falloff : MonoBehaviour {

	public GameObject finalpanel;
	public GameObject gameoverUI;
	public GameObject nextlevel;
	public GameObject inputops;

	public GameObject canvas;
	private countdown script;

	public bool isgameover = false;
	private bool clearlevel = false;

	private printhighscores dbcontrol;
	public Text newname;

	private Rigidbody player;

	void Awake(){
		//DontDestroyOnLoad (transform.gameObject);
		finalpanel.SetActive (false);
		gameoverUI.SetActive (false);
		inputops.SetActive (false);
		nextlevel.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody>();
		script = canvas.GetComponent<countdown> ();
		dbcontrol = new printhighscores ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		postCollider ();
	}


	void OnTriggerEnter (Collider hole){

		switch(hole.tag) {
		case "hole": 
			isgameover = true;
			Debug.Log ("Se cayó la bola. Game Over");
			Debug.Log (isgameover);
			break;
		case "meta":
			clearlevel = true;
			script.points += 500;
			PlayerStats.Points = script.points;
			Debug.Log ("Has completado el nivel!");
			break;
		}
	}

	private void postCollider () {
		if (isgameover){
			finalpanel.SetActive (true);
			gameoverUI.SetActive (true);
			player.gameObject.SetActive (false);
			Time.timeScale = 0;
		} else if(clearlevel){
			finalpanel.SetActive (true);
			nextlevel.SetActive (true);
			Time.timeScale = 0;
		}
		var ds = new DataService("testDB.db");
		if (SceneManager.GetActiveScene().buildIndex == 2 && (ds.GetLeaderBoard ().Count () < 10 || PlayerStats.Points > dbcontrol.checkLowestScore())){
			inputops.SetActive (true);
		}
	}

	public void loadnextlvl(){
		//llamada desde los botones de salir/continuar al final de la partida
		if (clearlevel && SceneManager.GetActiveScene ().buildIndex != 2){
			SceneManager.LoadScene ("level2");
			Time.timeScale = 1;
		}else {
			SceneManager.LoadScene ("menu");
		}
	}

	public void timeout(){
		isgameover = true;
	}

	public void enterNewScore(){
		dbcontrol.newScore (newname.text, PlayerStats.Points);
	}
}