using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SureScript : MonoBehaviour {


	private int optionSlect = 1;
	private int maxOption = 2;

	Color selectColor = Color.white;
	Color notSelectColor = Color.gray;

	Text[] optionsText;

	void Awake () {
		optionsText = new Text[3];

		optionsText[0] =transform.GetChild(0).GetComponent<Text>();
		optionsText[1] =transform.GetChild(1).GetComponent<Text>();
		optionsText[2] =transform.GetChild(2).GetComponent<Text>();

		TranforText ();
	}

	void TranforText(){
		for (int i = 1; i <= maxOption; i++) {
			if (i == optionSlect)
				optionsText [i].color = selectColor;
			else
				optionsText [i].color=notSelectColor;
		}
	}


	void Update () {

		if (Input.GetKeyDown (KeyCode.UpArrow) && optionSlect >= 2) {
			optionSlect -= 1;
			TranforText ();
		} else if (Input.GetKeyDown (KeyCode.DownArrow) && optionSlect < maxOption) {
			optionSlect += 1;
			TranforText ();
		}



		if (Input.GetKeyDown (KeyCode.Space)) {
			switch (optionSlect) {
			case 0:
				print ("NO estoy seguro");
				break;
			case 1:
				print ("Quitar Juego");
				break;
			default:
				print ("NO estoy seguro");
				break;
			}
		}
	}



}
