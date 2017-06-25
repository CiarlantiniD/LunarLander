using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

	// Configuraciones Basicas del Juego 


	Transform mainMenu;
	Transform optionsConf;
	Transform exitSure;

	private int actualMenu = 0;

	void Awake () {
		GameStart ();

		mainMenu = transform.FindChild ("MainMenu");
		optionsConf = transform.FindChild ("OptionsConf");
		exitSure =  transform.FindChild ("ExitSure");

		optionsConf.gameObject.SetActive (false);
		exitSure.gameObject.SetActive (false);
	}
	

	void Update () {


		if (actualMenu != 0) {

			AllStateActiveFalse ();

			switch (actualMenu) {				
			case 1:
				mainMenu.gameObject.SetActive (true);
				break;
			case 2:
				optionsConf.gameObject.SetActive (true);
				break;
			case 3:
				exitSure.gameObject.SetActive (true);
				break;
			default:
				mainMenu.gameObject.SetActive (true);
				break;
			}
			actualMenu = 0;
		}



	}

	private void AllStateActiveFalse(){
		mainMenu.gameObject.SetActive (false);
		optionsConf.gameObject.SetActive (false);
		exitSure.gameObject.SetActive (false);
	}

	private void GameStart(){
		if (PlayerPrefs.GetInt ("SoundGame") < 0)
			PlayerPrefs.SetInt ("SoundGame", 1);

		if (PlayerPrefs.GetInt ("VolumenGame") < 0)
			PlayerPrefs.SetInt ("VolumenGame", 100);

		// AMPLIAR
		// best score, score, lifes, Havesave
	} 

	public void ChangeMenu(int menuchange){
		actualMenu = menuchange;
	}
}
