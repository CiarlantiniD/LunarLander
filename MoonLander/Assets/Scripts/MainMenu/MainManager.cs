using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

	Transform mainMenu;
	Transform optionsConf;
	Transform exitSure;


	void Awake () {
		mainMenu = transform.FindChild ("MainMenu");
		optionsConf = transform.FindChild ("OptionsConf");
		exitSure =  transform.FindChild ("ExitSure");

		optionsConf.gameObject.SetActive (false);
		exitSure.gameObject.SetActive (false);
	}
	

	void Update () {
		
	}
}
