using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	public static Main instance = null;

	// SoundManager
	SoundManager soundManager;

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
    private bool uiComeBack = false;

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
		soundManager = GameObject.Find ("SoundManager").GetComponent<SoundManager> ();

		lifes = PlayerPrefs.GetInt("Lifes");
		score = PlayerPrefs.GetInt ("Score");
		bestScore = PlayerPrefs.GetInt ("BestScore");
		actualLevel = PlayerPrefs.GetInt ("Level");
		timeGame = PlayerPrefs.GetFloat ("Time", 0);

		levelManager.ChangeLevel (actualLevel);
		soundManager.PlayMusic_Game ("play");
		soundManager.ForceNotExplotion (true);
	}


	void Update () {

		if (!pauseStatus && naveScript.GetStatusAlive ())
			timeGame += Time.deltaTime;

		if (timeGame > 600) {
			naveScript.TimeOut ();
			lifes = 0;
		}
			

		naveFuel = naveScript.GetFuel ();
		naveVerticalVel = naveScript.GetVerticalVelocity ();
		lander = naveScript.Getlander ();

		if (!naveScript.GetStatusAlive () && !lander) {
			timer += Time.deltaTime;
			soundManager.PlayMusic_Game ("stop");

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


        if (pauseStatus || !naveScript.GetStatusAlive()) {
            uiComeBack = false;
        }
        else if(naveScript.GetvpPosition().x < 0.05 || naveScript.GetvpPosition().x > 0.95 || naveScript.GetvpPosition().y > 0.95 || !naveScript.GetStatusAlive()){
            uiComeBack = true;
        }
        else
            uiComeBack = false;


        // ------ Pause -------
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)){
			pauseStatus = naveScript.PauseStatus ();
			uiPause = pauseStatus;

			soundManager.PlayMusic_Game ("pause");
		}
	}


	// ------ Win / Lose Stage -------

	void WinStage(){
		scoreCalculate ();
		PlayerPrefs.SetInt ("Lifes", lifes);
		PlayerPrefs.SetInt ("Score", score);
		PlayerPrefs.SetInt ("Fuel", naveFuel);
		PlayerPrefs.SetFloat ("Time", 0);
		PlayerPrefs.SetInt ("Continue", 1);
		timeGame = 0;

		actualLevel += 1;
		if (actualLevel > levelManager.GetMaxLevels ())
			WinGame ();
		else {
			PlayerPrefs.SetInt ("Level", actualLevel);

			levelManager.ChangeLevel (actualLevel);
			naveScript.SetReset ();
			timer = 0;
		}
	}

	void LoseStage(){
		lifes -= 1;
		PlayerPrefs.SetInt ("Lifes", lifes);
		PlayerPrefs.SetInt ("Fuel", 1000);
		PlayerPrefs.SetFloat ("Time", timeGame);
		PlayerPrefs.SetInt ("Continue", 1);

		if (lifes < 0)
			LoseGame ();
		else {
			naveScript.SetReset ();
			timer = 0;
			soundManager.PlayMusic_Game ("play");
		}
	}
	// -----------------------------------------------------


	// ------ Win / Lose Game -------

	void WinGame(){
		ResetLevelCount ();

		if (lifes >= 2)  // Bonus Win
			score += 100000;

		if (score > bestScore)
			PlayerPrefs.SetInt ("BestScore", score);

		soundManager.PlayMusic_Game ("stop");
		soundManager.PlayFX_GameWinStage_Morse ();
		soundManager.ForceNotExplotion (false);

		PlayerPrefs.SetInt ("Fuel", 1000);
		PlayerPrefs.SetInt ("Score", score);
		PlayerPrefs.SetFloat ("Time", 0);

		SceneManager.LoadScene ("WinGame");
	}

	void LoseGame(){
		ResetLevelCount ();
		//score = 0; //lifes = 2;

		PlayerPrefs.SetInt ("Lifes", 2);
		PlayerPrefs.SetInt ("Score", 0);
		PlayerPrefs.SetFloat ("Time", 0);

		soundManager.PlayMusic_Game ("stop");

		SceneManager.LoadScene ("LoseGame");
	}

	private void ResetLevelCount(){
		actualLevel = 1;
		PlayerPrefs.SetInt ("Level", actualLevel);
		PlayerPrefs.SetInt ("Continue", 0);
	}
	// -----------------------------------------------------


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
    public bool GetUIComeBack(){return uiComeBack;}

    public int GetNaveFuel(){return naveFuel;}
	public float GetNaveVerticalVel(){return naveVerticalVel;}

	public float GetTime(){return timeGame;}

	public bool GetPauseStatus(){return pauseStatus;}
	public bool GetStatusNaveAlive() {return naveScript.GetStatusAlive ();}
}
