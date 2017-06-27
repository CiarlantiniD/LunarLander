using System.Collections; using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreGameScript : MonoBehaviour {

	Transform [] texts;
	float timer = 0;

	void Awake () {
		texts = transform.GetComponentsInChildren<Transform> (); 

		for (int i = 1; i < texts.Length; i++) {
			texts [i].gameObject.SetActive (false);
		}
	}

	void Update () {
		timer += Time.deltaTime;


		if (timer > 1.5f) {
			for (int i = 1; i < texts.Length; i++) {
				texts [i].gameObject.SetActive (true);
			}
		}

		if (timer > 1.7f) {
			if (Input.GetKeyDown (KeyCode.Space))
				timer = 5.1f;
		}


		if (timer > 5f) {
			for (int i = 1; i < texts.Length; i++) {
				texts [i].gameObject.SetActive (false);
			}
		}

		if (timer > 6f)
			SceneManager.LoadScene ("Game");
		
	}
}
