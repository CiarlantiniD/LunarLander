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

	public AudioSource shipFire;
	public AudioSource explotionShip;
	public AudioSource fuelAlarm;
	public AudioSource landerShip;

	public AudioSource morseWinStage;

	bool setMute = true;
	bool forceNotExplotion = true;

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		StopAllSounds ();
		VolumenAllSounds(PlayerPrefs.GetInt ("VolumenGame", 100));
		MuteAllSounds (PlayerPrefs.GetInt ("SoundGame", 1));

		DontDestroyOnLoad (gameObject);
	}

	private void StopAllSounds(){
		musicMenu.Stop();
		musicGame.Stop();

		fxMenuMove.Stop(); 
		fxMenuSelect.Stop();
		fxMenuBack.Stop();
		fxMenuStart.Stop();

		shipFire.Stop ();
		explotionShip.Stop ();
		fuelAlarm.Stop ();
		landerShip.Stop ();

		morseWinStage.Stop ();
	}

	public void VolumenAllSounds(float volumen){

		if (volumen >= 100f) 
			volumen = 0.6f;
		else if (volumen >= 75f)
			volumen = 0.5f;
		else if (volumen >= 50f)
			volumen = 0.3f;
		else if (volumen >= 25f)
			volumen = 0.1f;
		else if (volumen >= 0f)
			volumen = 0f;
		else
			volumen = 0.6f;
		
		if (setMute) {
			musicMenu.volume = volumen;
			musicGame.volume = volumen;

			fxMenuMove.volume = volumen;
			fxMenuSelect.volume = volumen;
			fxMenuBack.volume = volumen;
			fxMenuStart.volume = volumen;

			shipFire.volume = volumen;
			explotionShip.volume = volumen;
			fuelAlarm.volume = volumen;
			landerShip.volume = volumen;

			morseWinStage.volume = volumen;
		}

	}

	public void MuteAllSounds(int defMute){

		if (defMute == 0) {
			VolumenAllSounds (0);
			setMute = false;
		} else {
			setMute = true;
			VolumenAllSounds (PlayerPrefs.GetInt ("VolumenGame", 100));
		}

	}


	public void PlayMusic_Menu(){
		if (musicMenu.isPlaying)
			musicMenu.Stop ();
		else
			musicMenu.Play ();
	}

	public void PlayMusic_Game(string command){

		if (command == "play")
			musicGame.Play ();
		else if (command == "stop")
			musicGame.Stop ();
		else if (command == "pause") {
			if (musicGame.isPlaying)
				musicGame.Pause ();
			else
				musicGame.Play ();
		}
		else
			command = "ERROR";


		if (command == "ERROR"){
			if (musicMenu.isPlaying)
				musicGame.Stop ();
			else
				musicGame.Play ();
		}



	}

	public void PlayFX_GameShipFire(bool status){
		if (status) {
			if (!shipFire.isPlaying) {
				shipFire.Play ();
			}
		}
		else
			shipFire.Stop ();

	}
		
	public void PlayFX_GameShipFuelAlarm(){
		if (!fuelAlarm.isPlaying)
			fuelAlarm.Play ();
	}


	public void PlayFX_GameShipExplotion(){
		if (forceNotExplotion)
			explotionShip.Play ();
	}

	public void PlayFX_GameShipLander(){landerShip.Play ();}



	public void PlayFX_GameWinStage_Morse(){morseWinStage.Play ();}



	public void PlayFX_MenuMove(){fxMenuMove.Play ();}

	public void PlayFX_MenuSelect(){fxMenuSelect.Play ();}

	public void PlayFX_MenuBack(){fxMenuBack.Play ();}

	public void PlayFX_MenuStart(){fxMenuStart.Play ();}


	public void ForceNotExplotion(bool setNotExplotion){
		if (!setNotExplotion)
			forceNotExplotion = false;
		else
			forceNotExplotion = true;
	}

}
