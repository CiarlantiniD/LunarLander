using System.Collections; using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	MainManager mainManager;
	SoundManager soundManager;

	// Save Configuration
	private int haveSave = 1; // Configuration
	private int intTranforText = 1;
	private int optionSlectMaxArgument = 2; // 1 Yes / 2 No

	private int optionSlect = 0;
	private int maxOption = 3;

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
		optionsText[3] =transform.GetChild(3).GetComponent<Text>();

		haveSave =PlayerPrefs.GetInt ("Continue", 0);
		HaveSave();
		TranforText ();
	}

	void TranforText(){
		for (int i = intTranforText; i <= maxOption; i++) {
			if (i == optionSlect)
				optionsText [i].color = selectColor;
			else
				optionsText [i].color=notSelectColor;
		}
	}
		
	void Update () {
		 
		if (Input.GetKeyDown (KeyCode.UpArrow) && optionSlect >= optionSlectMaxArgument) {
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
				soundManager.PlayFX_MenuStart ();
				mainManager.GoToContinueGame();
				break;
			case 1:
				PlayerPrefs.SetInt ("Score", 0);
				PlayerPrefs.SetInt ("Lifes", 2);
				PlayerPrefs.SetInt ("Fuel", 1000);
				PlayerPrefs.SetInt ("Level", 1);
				PlayerPrefs.SetFloat ("Time", 0);
				PlayerPrefs.SetInt ("Continue", 0);
				soundManager.PlayFX_MenuStart ();
				mainManager.GoToNewGame ();
				break;
			case 2:
				soundManager.PlayFX_MenuSelect ();
				mainManager.ChangeMenu (2);
				break;
			case 3:
				soundManager.PlayFX_MenuSelect ();
				mainManager.ChangeMenu (3);
				break;
			default:
				soundManager.PlayFX_MenuSelect ();
				mainManager.ChangeMenu (3);
				break;
			}
		}
	}
		
	void HaveSave(){
		if (haveSave == 1) {
			intTranforText = 0;
			optionSlectMaxArgument = 1;
			optionSlect = 0;
		}
		else {
			intTranforText = 1;
			optionSlectMaxArgument = 2;
			optionSlect = 1;
			optionsText [0].color=Color.clear;
		}

	}

}
