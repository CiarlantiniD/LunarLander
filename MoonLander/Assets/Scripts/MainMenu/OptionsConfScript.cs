using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsConfScript : MonoBehaviour {

	private int optionSlect = 0;
	private int maxOption = 3;

	Color selectColor = Color.white;
	Color notSelectColor = Color.gray;

	Text[] optionsText;

	void Awake () {
		optionsText = new Text[4];

		optionsText[0] =transform.GetChild(0).GetComponent<Text>();
		optionsText[1] =transform.GetChild(1).GetComponent<Text>();
		optionsText[2] =transform.GetChild(2).GetComponent<Text>();
		optionsText[3] =transform.GetChild(3).GetComponent<Text>();

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
				print ("Continuar Juego");
				break;
			case 1:
				print ("Nuevo Juego");
				break;
			case 2:
				print ("Opciones Juego");
				break;
			case 3:
				print ("Salir Juego");
				break;
			default:
				print ("Salir Juego"); // revisar
				break;
			}
		}
	}
}
