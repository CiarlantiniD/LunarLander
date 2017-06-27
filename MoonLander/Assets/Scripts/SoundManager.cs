using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance = null;

	public AudioClip [] fxClips; 
	public AudioClip [] musicClips; 

	AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
	AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
	          
	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
	}


	//Used to play single sound clips.
	public void PlaySingle(AudioClip clip)
	{
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		efxSource.clip = clip;

		//Play the clip.
		efxSource.Play ();
	}



}
