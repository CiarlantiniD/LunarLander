using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreGameScript : MonoBehaviour {

	float timer = 0;

	void Awake () {}

	void Update () {
		timer += Time.deltaTime;

		if (timer > 4.0f)
			SceneManager.LoadScene ("Scene");
		
	}
}
