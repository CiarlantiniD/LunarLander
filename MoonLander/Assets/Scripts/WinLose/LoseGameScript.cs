using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGameScript : MonoBehaviour {

	float timer = 0;

	void Awake () {}

	void Update () {
		timer += Time.deltaTime;

		if (timer > 4.0f)
			SceneManager.LoadScene ("MainMenu");
	}
}
