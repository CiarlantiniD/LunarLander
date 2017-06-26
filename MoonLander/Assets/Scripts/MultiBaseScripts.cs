using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBaseScripts : MonoBehaviour {

	Main main;


	SpriteRenderer multiBase;
	float timer;
	float timerElements = 2f;

	bool naveAlive;

	void Awake () {
		main = GameObject.Find("Main").GetComponent<Main>();

		multiBase = GetComponent<SpriteRenderer> ();
		multiBase.enabled = false;
	}

	void Update () {

		if (!main.GetPauseStatus () && main.GetStatusNaveAlive ()) {
			timer += Time.deltaTime;

			if (timer > timerElements) {
				if (multiBase.enabled == true) {
					timerElements = 4f;
					multiBase.enabled = false;
				} else if (multiBase.enabled == false) {
					timerElements = 2f;
					multiBase.enabled = true;
				}

				timer = 0;
			}
		} else if (!main.GetStatusNaveAlive ()) {
			timer = 0;
			multiBase.enabled = false;
		}

	}
}
