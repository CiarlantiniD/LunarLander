using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {

	GameObject nave;
	NaveScript naveScript;
	int naveFuel;

	Transform fuelUI;
	Text contador;

	Vector3 distanciaUI;



	//int temp = 0; // se puede borrat

	// Use this for initialization
	void Start () {


		fuelUI = transform.FindChild ("FuelUI");
		contador = fuelUI.GetComponent<Text> ();
		fuelUI.gameObject.SetActive (false);


		nave = GameObject.Find ("Ship");
		naveScript = nave.GetComponent<NaveScript>();

		distanciaUI = new Vector3 (0.5f,1f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		naveFuel = naveScript.GetFuel ();

		//transform.position = nave.transform.position + distanciaUI; // REVISAR

	

		contador.text = naveFuel.ToString ();

		if (naveFuel < 9500) {
			fuelUI.gameObject.SetActive (true);
		}

	}
}
 