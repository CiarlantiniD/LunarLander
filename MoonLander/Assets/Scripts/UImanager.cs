using System.Collections;
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

	public int lifes;
	public int score;

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		nave = GameObject.Find ("Ship");
		naveScript = nave.GetComponent<NaveScript>();

		main = GameObject.Find ("Main");
		mainScript = main.GetComponent<Main> ();
	}


	// Use this for initialization
	//void Start () {}

	// Update is called once per frame
	void Update () {
		naveFuel = naveScript.GetFuel ();
		naveVerticalVel = naveScript.GetVerticalVelocity ();

		lifes = mainScript.GetLifes ();
		score = mainScript.GetScore ();
	}
}
 