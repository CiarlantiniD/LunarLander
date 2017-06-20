using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {

	public static UImanager instance = null; 

	GameObject nave;
	NaveScript naveScript;
	public int naveFuel;






	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}


	// Use this for initialization
	void Start () {
		

		nave = GameObject.Find ("Ship");
		naveScript = nave.GetComponent<NaveScript>();
	}

	// Update is called once per frame
	void Update () {
		naveFuel = naveScript.GetFuel ();


	}
}
 