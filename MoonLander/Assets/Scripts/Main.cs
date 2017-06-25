using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	public static Main instance = null;

	// Levels
	private LevelManager levelManager;
	int actualLevel;

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
	int tempScore;

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
		levelManager = GameObject.Find ("LevelsManager").GetComponent<LevelManager> ();


		// --- Esto es en el caso de un New Game
		PlayerPrefs.SetInt ("Lifes", 3);
		PlayerPrefs.SetInt ("Score", 0);
		PlayerPrefs.SetInt ("Level", 1);
		PlayerPrefs.SetInt ("Fuel", 1000);


		lifes = PlayerPrefs.GetInt("Lifes",3);
		score = PlayerPrefs.GetInt ("Score", 0);
		bestScore = PlayerPrefs.GetInt ("BestScore", 0);
		actualLevel = PlayerPrefs.GetInt ("Level", 1);

		levelManager.ChangeLevel (actualLevel);
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
				uiLose = false;
			}
		} else if (!naveScript.GetStatusAlive () && lander) {
			timer += Time.deltaTime;

			if (timer > 1f)
				uiWin = true;
			
			if (timer > 4.0f) {
				WinStage ();
				uiWin = false;
			}
		
		}



		// --- Pause ---
		if (Input.GetKeyDown(KeyCode.Escape)){
			pauseStatus = naveScript.PauseStatus ();
			uiPause = pauseStatus;
		}
	}
		

	void WinStage(){
		scoreCalculate ();
		PlayerPrefs.SetInt ("Lifes", lifes);
		PlayerPrefs.SetInt ("Score", score);
		PlayerPrefs.SetInt ("Fuel", naveFuel);
		timeGame = 0;

		actualLevel += 1;
		if (actualLevel > levelManager.GetMaxLevels ())
			WinGame ();
	
		PlayerPrefs.SetInt ("Level", actualLevel);

		levelManager.ChangeLevel (actualLevel);
		naveScript.SetReset ();
		timer = 0;
	}

	void LoseStage(){
		lifes -= 1;
		PlayerPrefs.SetInt ("Lifes", lifes);
		PlayerPrefs.SetInt ("Fuel", 1000);
		naveScript.SetReset ();
		timer = 0;

		if (lifes < 0)
			LoseGame ();
	}



	// --- Win / Lose Game
	void WinGame(){
		ResetLevelCount ();
		score += 100000; // Bonus Win

		if (score > bestScore) // Se puede mover a la scena Ganadora
			PlayerPrefs.SetInt ("BestScore", score);

		SceneManager.LoadScene ("WinGame");
	}

	void LoseGame(){
		ResetLevelCount ();
		score = 0;
		lifes = 3;
		PlayerPrefs.SetInt ("Lifes", lifes);

		SceneManager.LoadScene ("LoseGame");
	}
	// ------------------






	private void ResetLevelCount(){
		actualLevel = 1;
		PlayerPrefs.SetInt ("Level", actualLevel);
		PlayerPrefs.SetInt ("HaveSave", 0);
	}



	void scoreCalculate(){
		tempScore = ((int)timeGame * 1000) - (naveFuel * 10);
		tempScore = 150000 - tempScore;
		tempScore = tempScore *  naveScript.GetBaseMulti();
		score += tempScore;
	}

	public int GetLifes(){return lifes;}
	public int GetScore(){return score;}

	public bool GetUIWin(){return uiWin;}
	public bool GetUILose(){return uiLose;}
	public bool GetUIPause(){return uiPause;}

	 
	public int GetNaveFuel(){return naveFuel;}
	public float GetNaveVerticalVel(){return naveVerticalVel;}

	public float GetTime(){return timeGame;}

	public bool GetPauseStatus(){return pauseStatus;}
}
