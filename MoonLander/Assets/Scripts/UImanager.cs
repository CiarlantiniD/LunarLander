﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {

	public static UImanager instance = null; 

	GameObject main;
	Main mainScript;

	GameObject nave;
	NaveScript naveScript;
	public int naveFuel;
	public float naveVerticalVel;

	Transform winText;
	Transform loseText;
	Transform pauseText;

	public int lifes;
	public int score;

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		nave = GameObject.Find ("Ship");
		naveScript = nave.GetComponent<NaveScript>(); // esto esta mal

		main = GameObject.Find ("Main");
		mainScript = main.GetComponent<Main> ();

		winText = transform.FindChild ("WinText");
		loseText = transform.FindChild ("LoseText");
		pauseText = transform.FindChild ("PauseText");
		winText.gameObject.SetActive (false);
		loseText.gameObject.SetActive (false);
		pauseText.gameObject.SetActive (false);

	}


	// Use this for initialization
	//void Start () {}

	// Update is called once per frame
	void Update () {
		naveFuel = naveScript.GetFuel ();
		naveVerticalVel = naveScript.GetVerticalVelocity ();

		lifes = mainScript.GetLifes ();
		score = mainScript.GetScore ();





		// --- UI Mesenger ---
		if (mainScript.GetUIWin ())
			winText.gameObject.SetActive (true);
		else
			winText.gameObject.SetActive (false);

		if (mainScript.GetUILose ())
			loseText.gameObject.SetActive (true);
		else
			loseText.gameObject.SetActive (false);

		if (mainScript.GetUIPause ())
			pauseText.gameObject.SetActive (true);
		else
			pauseText.gameObject.SetActive (false);


	}
}
 