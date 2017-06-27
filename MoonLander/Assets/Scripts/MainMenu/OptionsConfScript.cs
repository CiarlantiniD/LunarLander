using System.Collections; using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsConfScript : MonoBehaviour {

	MainManager mainManager;
	SoundManager soundManager;

	// Valores del Menu
	private int setVolumen = 0;

	private int optionSlect = 0;
	private int maxOption = 2;

	Color selectColor = Color.white;
	Color notSelectColor = Color.gray;

	Text[] optionsText;

	void Awake () {
		mainManager = transform.GetComponentInParent<MainManager> ();
		soundManager = GameObject.Find ("SoundManager").GetComponent<SoundManager> ();

		optionsText = new Text[4];

		optionsText[0] =transform.GetChild(0).GetComponent<Text>();
		optionsText[1] =transform.GetChild(1).GetComponent<Text>();
		optionsText[2] =transform.GetChild(2).GetComponent<Text>();

		TranforText ();
		StartConfiguration ();
	}

	void TranforText(){
		for (int i = 0; i <= maxOption; i++) {
			if (i == optionSlect)
				optionsText [i].color = selectColor;
			else
				optionsText [i].color=notSelectColor;
		}
	}


	void Update () {

		if (Input.GetKeyDown (KeyCode.UpArrow) && optionSlect >= 1) {
			optionSlect -= 1;
			TranforText ();
			soundManager.PlayFX_MenuMove ();
		} else if (Input.GetKeyDown (KeyCode.DownArrow) && optionSlect < maxOption) {
			optionSlect += 1;
			TranforText ();
			soundManager.PlayFX_MenuMove ();
		}



		if (Input.GetKeyDown (KeyCode.Space)) {
			switch (optionSlect) {
			case 0:
				soundManager.PlayFX_MenuSelect ();
				ConfSoundOnOff ();
				break;
			case 1:
				soundManager.PlayFX_MenuSelect ();
				ConfVolumen ();
				break;
			case 2:
				soundManager.PlayFX_MenuBack ();
				mainManager.ChangeMenu (1);
				break;
			default:
				soundManager.PlayFX_MenuBack ();
				mainManager.ChangeMenu (1);
				break;
			}
		}
	}

	private void ConfSoundOnOff (){
		if (PlayerPrefs.GetInt ("SoundGame",1) == 1) {
			PlayerPrefs.SetInt ("SoundGame", 0);
			optionsText [0].text = "Sound OFF";
			soundManager.MuteAllSounds (0);
		} else {
			PlayerPrefs.SetInt ("SoundGame", 1);
			optionsText [0].text = "Sound ON";
			soundManager.MuteAllSounds (1);
		}
	}

	private void ConfVolumen (){
		switch (setVolumen) {
		case 0:
			PlayerPrefs.SetInt ("VolumenGame", 25);
			optionsText [1].text = "Volumen - 25";
			soundManager.VolumenAllSounds (25);
			setVolumen += 1;
			break;
		case 1:
			PlayerPrefs.SetInt ("VolumenGame", 50);
			optionsText [1].text = "Volumen - 50";
			soundManager.VolumenAllSounds (50);
			setVolumen += 1;
			break;
		case 2:
			PlayerPrefs.SetInt ("VolumenGame", 75);
			optionsText [1].text = "Volumen - 75";
			soundManager.VolumenAllSounds (75);
			setVolumen += 1;
			break;
		case 3:
			PlayerPrefs.SetInt ("VolumenGame", 100);
			optionsText [1].text = "Volumen - 100";
			soundManager.VolumenAllSounds (100);
			setVolumen = 0;
			break;
		default:
			PlayerPrefs.SetInt ("VolumenGame", 100);
			optionsText [1].text = "Volumen - 100";
			soundManager.VolumenAllSounds (100);
			setVolumen = 0;
			break;
		}
	}

	private void StartConfiguration(){

		if (PlayerPrefs.GetInt ("VolumenGame") == 100) {
			optionsText [1].text = "Volumen - 100";
			setVolumen = 0;
		}
		else if (PlayerPrefs.GetInt ("VolumenGame") == 75) {
			optionsText [1].text = "Volumen - 75";
			setVolumen = 3;
		}
		else if (PlayerPrefs.GetInt ("VolumenGame") == 50) {
			optionsText [1].text = "Volumen - 50";
			setVolumen = 2;
		}
		else if (PlayerPrefs.GetInt ("VolumenGame") == 25) {
			optionsText [1].text = "Volumen - 25";
			setVolumen = 1;
		}


		if (PlayerPrefs.GetInt ("SoundGame") == 1) {
			optionsText [0].text = "Sound ON";
		} 
		else if (PlayerPrefs.GetInt ("SoundGame") == 0){
			optionsText [0].text = "Sound OFF";
		}
	}
}
