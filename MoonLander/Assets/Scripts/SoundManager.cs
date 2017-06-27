using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance = null;


	public AudioSource musicMenu;
	public AudioSource musicGame;

	public AudioSource fxMenuMove;   
	public AudioSource fxMenuSelect;
	public AudioSource fxMenuBack;
	public AudioSource fxMenuStart;

	int soundGame;
	float volumenGame;
	bool setMute = true;

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		volumenGame = PlayerPrefs.GetInt ("VolumenGame", 100);
		soundGame = PlayerPrefs.GetInt ("SoundGame", 1);

		print ("volumenGame: " + volumenGame + "   soundGame: " + soundGame);

		StopAllSounds ();
		VolumenAllSounds(volumenGame);
		MuteAllSounds (soundGame);

		DontDestroyOnLoad (gameObject);
	}

	private void StopAllSounds(){
		musicMenu.Stop();
		musicGame.Stop();

		fxMenuMove.Stop(); 
		fxMenuSelect.Stop();
		fxMenuBack.Stop();
		fxMenuStart.Stop();
	}

	public void VolumenAllSounds(float volumen){


		if (volumen >= 100f) {
			volumen = 0.6f;
			volumenGame = volumen;
		} else if (volumen >= 75f) {
			volumen = 0.5f;
			volumenGame = volumen;
		} else if (volumen >= 50f) {
			volumen = 0.3f;
			volumenGame = volumen;
		} else if (volumen >= 25f) {
			volumen = 0.1f;
			volumenGame = volumen;
		}
		else if (volumen >= 0f){
			volumen = 0f;
		}
		else{
			volumen = 0.6f;
			volumenGame = volumen;
		}
			
		if (setMute) {
			musicMenu.volume = volumen;
			musicGame.volume = volumen;

			fxMenuMove.volume = volumen;
			fxMenuSelect.volume = volumen;
			fxMenuBack.volume = volumen;
			fxMenuStart.volume = volumen;
		}

	}

	public void MuteAllSounds(int defMute){

		if (defMute == 0) {
			VolumenAllSounds (0);
			setMute = false;
		}
		else{
			VolumenAllSounds (volumenGame);
			setMute = true;
		}
	}


	public void PlayMusic_Menu(){
		if (musicMenu.isPlaying)
			musicMenu.Stop ();
		else
			musicMenu.Play ();
	}

	public void PlayMusic_Game(){
		if (musicMenu.isPlaying)
			musicGame.Stop ();
		else
			musicGame.Play ();
	}



	public void PlayFX_MenuMove(){fxMenuMove.Play ();}

	public void PlayFX_MenuSelect(){fxMenuSelect.Play ();}

	public void PlayFX_MenuBack(){fxMenuBack.Play ();}

	public void PlayFX_MenuStart(){fxMenuStart.Play ();}

}
