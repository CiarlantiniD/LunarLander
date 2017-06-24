using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {


	Text continueGame;
	Text newGame;
	Text optionsGame;
	Text exitGame;

	int optionSlect = 0;
	int maxOption = 3;

	Color selectColor = Color.white;
	Color notSelectColor = Color.gray;

	void Awake () {
		continueGame=transform.GetChild(0).GetComponent<Text>();
		newGame=transform.GetChild(1).GetComponent<Text>();
		optionsGame=transform.GetChild(2).GetComponent<Text>();
		exitGame=transform.GetChild(3).GetComponent<Text>();


	}
	

	void Update () {
		 
		if (Input.GetKeyDown (KeyCode.UpArrow) && optionSlect >= 1)
			optionSlect -= 1;
		else if(Input.GetKeyDown(KeyCode.DownArrow) && optionSlect < maxOption)
			optionSlect += 1;



		continueGame.color = notSelectColor;
		newGame.color=notSelectColor;
		optionsGame.color=notSelectColor;
		exitGame.color=notSelectColor;

		switch (optionSlect) {
		case 0:
			continueGame.color = selectColor;
			break;
		case 1:
			newGame.color=selectColor;
			break;
		case 2:
			optionsGame.color=selectColor;
			break;
		case 3:
			exitGame.color=selectColor;
			break;
		default:
			continueGame.color = selectColor;
			break;
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
