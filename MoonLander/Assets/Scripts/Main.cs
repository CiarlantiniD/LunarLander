using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Main : MonoBehaviour {

	public static Main instance = null;



	// Nave Data
	private NaveScript naveScript;
	int naveFuel;
	float naveVerticalVel;
	bool lander;

	// Lifes
	private int lifes;

	// Score
	private int score;
	private int bestScore;

	// Text
	private bool uiWin = false;
	private bool uiLose = false;
	private bool uiPause = false;

	// Pause
	private bool pauseStatus;

	// Timer
	float timer = 0;
	float timeGame = 0;


	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		naveScript = GameObject.Find ("Ship").GetComponent<NaveScript> ();

		PlayerPrefs.SetInt ("Lifes", 15);
		PlayerPrefs.SetInt ("Score", 0);

		lifes = PlayerPrefs.GetInt("Lifes",15);
		score = PlayerPrefs.GetInt ("Score", 0);
		bestScore = PlayerPrefs.GetInt ("BestScore", 0);
	}


	void Update () {

		if (!pauseStatus && naveScript.GetStatusAlive ())
			timeGame += Time.deltaTime;

		naveFuel = naveScript.GetFuel ();
		naveVerticalVel = naveScript.GetVerticalVelocity ();
		lander = naveScript.Getlander ();






		if (!naveScript.GetStatusAlive () && !lander) {
			timer += Time.deltaTime;

			if (timer > 1f)
				uiLose = true;

			if (timer > 4.0f) {
				LoseStage ();
				naveScript.SetReset ();
				timer = 0;
				uiLose = false;
			}
		} else if (!naveScript.GetStatusAlive () && lander) {
			timer += Time.deltaTime;

			if (timer > 1f)
				uiWin = true;
			
			if (timer > 4.0f) {
				//LoseStage ();
				naveScript.SetReset ();
				timer = 0;
				uiWin = false;
				score += 500; // Usar algoritmo para calcular un mejor score
			}
		
		}



		// --- Pause ---
		if (Input.GetKeyDown(KeyCode.Escape)){
			pauseStatus = naveScript.PauseStatus ();
			uiPause = pauseStatus;
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

	public bool GetUIWin(){return uiWin;}
	public bool GetUILose(){return uiLose;}
	public bool GetUIPause(){return uiPause;}

	 
	public int GetNaveFuel(){return naveFuel;}
	public float GetNaveVerticalVel(){return naveVerticalVel;}

	public float GetTime(){return timeGame;}
}
