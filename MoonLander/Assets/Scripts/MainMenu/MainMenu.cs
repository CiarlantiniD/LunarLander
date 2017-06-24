using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	Text[] textOptions; // = new Text[]{0,1,2,3};


/*	Text continueGame;
	Text newGame;
	Text optionsGame;
	Text exitGame;*/

	int optionSlect = 0;
	int maxOption = 3;

	Color selectColor = Color.white;
	Color notSelectColor = Color.gray;

	void Awake () {
		/*continueGame=transform.GetChild(0).GetComponent<Text>();
		newGame=transform.GetChild(1).GetComponent<Text>();
		optionsGame=transform.GetChild(2).GetComponent<Text>();
		exitGame=transform.GetChild(3).GetComponent<Text>();*/

		Text[] textOptions = new Text[] {
			transform.GetChild (0).GetComponent<Text> (),
			transform.GetChild (1).GetComponent<Text> (),
			transform.GetChild (2).GetComponent<Text> (),
			transform.GetChild (3).GetComponent<Text> (),
		};
	}
	

	void Update () {
		 
		if (Input.GetKeyDown (KeyCode.UpArrow) && optionSlect < 1)
			optionSlect -= 1;
		else if(Input.GetKeyDown(KeyCode.DownArrow) && optionSlect > maxOption)
			optionSlect += 1;




		for (int i = 0; i < maxOption; i++) {
			if (i != optionSlect)
				textOptions[i].color = selectColor;
			else
				textOptions[i].color = notSelectColor;
		}





		/*if (Input.GetKeyDown (KeyCode.Space)) {
			switch (optionSlect) {
			case 0:
				print ("Continuar Juego");
			case 1:
				print ("Nuevo Juego");
			case 2:
				print ("Opciones Juego");
			case 3:
				print ("Salir Juego");
			default:
				print ("Salir Juego"); // revisar
			}*/
		}
		
}
