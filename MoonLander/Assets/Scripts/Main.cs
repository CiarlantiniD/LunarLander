using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Main : MonoBehaviour {



	int lifes;

	private int score;
	private int bestScore;

	void Awake () {
		lifes = PlayerPrefs.GetInt("Lifes",3);
		score = PlayerPrefs.GetInt ("Score", 0);
		bestScore = PlayerPrefs.GetInt ("BestScore", 0);
	}

	// Revisar
	void OnEnable(){}
	void OnDisable(){}


	void Start () {}

	void Update () {
	}

	void Lose(){
		print ("Escuche");
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
