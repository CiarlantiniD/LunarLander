using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsConfScript : MonoBehaviour {

	MainManager mainManager;

	// Valores del Menu
	private int setVolumen = 0;

	private int optionSlect = 0;
	private int maxOption = 2;

	Color selectColor = Color.white;
	Color notSelectColor = Color.gray;

	Text[] optionsText;

	void Awake () {
		mainManager = transform.GetComponentInParent<MainManager> ();

		optionsText = new Text[4];

		optionsText[0] =transform.GetChild(0).GetComponent<Text>();
		optionsText[1] =transform.GetChild(1).GetComponent<Text>();
		optionsText[2] =transform.GetChild(2).GetComponent<Text>();

		TranforText ();
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
		} else if (Input.GetKeyDown (KeyCode.DownArrow) && optionSlect < maxOption) {
			optionSlect += 1;
			TranforText ();
		}



		if (Input.GetKeyDown (KeyCode.Space)) {
			switch (optionSlect) {
			case 0:
				print ("Cambiando Sonido");
				ConfSoundOnOff ();
				break;
			case 1:
				print ("Cambiando Volumen");
				ConfVolumen ();
				break;
			case 2:
				print ("Volver a atras");
				mainManager.ChangeMenu (1);
				break;
			default:
				print ("Volver a atras");
				mainManager.ChangeMenu (1);
				break;
			}
		}
	}

	private void ConfSoundOnOff (){
		if (PlayerPrefs.GetInt ("SoundGame",1) == 1) {
			PlayerPrefs.SetInt ("SoundGame", 0);
			optionsText [0].text = "Sound OFF";
		} else {
			PlayerPrefs.SetInt ("SoundGame", 1);
			optionsText [0].text = "Sound ON";
		}
	}

	private void ConfVolumen (){
		switch (setVolumen) {
		case 0:
			PlayerPrefs.SetInt ("VolumenGame", 25);
			optionsText [1].text = "Volumen - 25";
			setVolumen += 1;
			break;
		case 1:
			PlayerPrefs.SetInt ("VolumenGame", 50);
			optionsText [1].text = "Volumen - 50";
			setVolumen += 1;
			break;
		case 2:
			PlayerPrefs.SetInt ("VolumenGame", 75);
			optionsText [1].text = "Volumen - 75";
			setVolumen += 1;
			break;
		case 3:
			PlayerPrefs.SetInt ("VolumenGame", 100);
			optionsText [1].text = "Volumen - 100";
			setVolumen = 0;
			break;
		default:
			PlayerPrefs.SetInt ("VolumenGame", 100);
			optionsText [1].text = "Volumen - 100";
			setVolumen = 0;
			break;
		}
	}
}
