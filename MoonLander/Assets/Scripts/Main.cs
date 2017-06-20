using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Main : MonoBehaviour {

	public static Main instance = null;

	NaveScript naveScript;// cambiar
	//UImanager uiManager;// cambiar

	private int lifes;

	private int score;
	private int bestScore;

	float timer = 0;

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		naveScript = GameObject.Find ("Ship").GetComponent<NaveScript>(); // cambiar
		//uiManager = GameObject.Find ("CanvasUI").GetComponent<UImanager>(); // cambiar

		PlayerPrefs.SetInt ("Lifes", 15);
		PlayerPrefs.SetInt ("Score", 0);

		lifes = PlayerPrefs.GetInt("Lifes",15);
		score = PlayerPrefs.GetInt ("Score", 0);
		bestScore = PlayerPrefs.GetInt ("BestScore", 0);
	}

	// Revisar
	//void OnEnable(){}
	//void OnDisable(){}
	//void Start () {}

	void Update () {









		if (!naveScript.GetStatusAlive()){
			timer += Time.deltaTime;

			if (timer > 4.0f) {
				LoseStage ();
				naveScript.SetReset ();
				timer = 0;
			}
				
		}
	}
		

	void WinStage(){
		PlayerPrefs.SetInt ("Lifes", lifes);
		PlayerPrefs.SetInt ("Score", score);
	}

	void LoseStage(){
		lifes -= 1;
		PlayerPrefs.SetInt ("Lifes", lifes);
	}

	void WinGame(){
		if (score > bestScore) // Se puede mover a la scena Ganadora
			PlayerPrefs.SetInt ("BestScore", score);
	}

	void LoseGame(){
	}

	int scoreCalculate(){/* Tiempo * Combustible * Zona*/ return 0;}

	public int GetLifes(){return lifes;}

	public int GetScore(){return score;}
}
