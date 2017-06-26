using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


	AudioSource [] music;
	AudioSource [] menuFX;
	AudioSource [] gameFX;

	void Start () {
		music = transform.FindChild ("Music").GetComponents<AudioSource>();
		menuFX = transform.FindChild ("MenuFX").GetComponents<AudioSource>();
		gameFX = transform.FindChild ("GameFX").GetComponents<AudioSource>();
	}

	void Update () {

		/*if (Input.GetKeyDown (KeyCode.O)) {
			menuFX [0].PlayOneShot();
		}*/

	}
}
