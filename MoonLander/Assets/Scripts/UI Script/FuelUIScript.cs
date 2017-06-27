using System.Collections; using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelUIScript : MonoBehaviour {

	UImanager parentScript;

	Text fuelCount;
	int naveFuel;

	void Awake () {
		fuelCount = GetComponent<Text> ();
		parentScript = transform.GetComponentInParent<UImanager> ();
	}
		
	void Update () {
		naveFuel = parentScript.naveFuel;

		if (naveFuel < 0)
			fuelCount.text = "Fuel   Empty";
		else
			fuelCount.text = "Fuel   " + naveFuel.ToString ();
	}
}
