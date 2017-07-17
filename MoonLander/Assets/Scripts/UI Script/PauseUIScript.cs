using UnityEngine;
using UnityEngine.UI;

public class PauseUIScript : MonoBehaviour { 

	SoundManager soundManager;
	private Main mainScript;

	private int optionSlect = 1;
	private int maxOption = 2;

	Color selectColor = Color.white;
	Color notSelectColor = Color.gray;

	Text[] optionsText;
	Image pauseBackGround;

	bool pauseActive = false;

	void Awake () {
		soundManager = GameObject.Find ("SoundManager").GetComponent<SoundManager> ();
		mainScript = GameObject.Find ("Main").GetComponent<Main> ();

		optionsText = new Text[3];

		optionsText[0] = transform.FindChild ("PauseText").GetComponent<Text>();
		optionsText[1] = transform.FindChild ("PauseTextReturn").GetComponent<Text>();
		optionsText[2] = transform.FindChild ("PauseTextMenu").GetComponent<Text>();

		pauseBackGround = transform.FindChild ("PauseBackGround").GetComponent<Image>();

		TranforText ();
		SetUIOnOff (false);
	}

	void TranforText(){
		for (int i = 1; i <= maxOption; i++) {
			if (i == optionSlect)
				optionsText [i].color = selectColor;
			else
				optionsText [i].color=notSelectColor;
		}
	}


	void Update () {

		if (pauseActive) {

			if (Input.GetKeyDown (KeyCode.UpArrow) && optionSlect >= 2) {
				optionSlect -= 1;
				TranforText ();
				soundManager.PlayFX_MenuMove ();
			} else if (Input.GetKeyDown (KeyCode.DownArrow) && optionSlect < maxOption) {
				optionSlect += 1;
				TranforText ();
				soundManager.PlayFX_MenuMove ();
			}



			if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Return)) {
				switch (optionSlect) {
				case 1:
					mainScript.ReturnToGame (true);
					break;
				case 2:
					soundManager.PlayFX_MenuStart ();
					mainScript.ReturnToGame (false);
					break;
				default:
					mainScript.ReturnToGame (true);
					break;
				}
			}
		}
	}

	public void SetUIOnOff(bool onOff){
		if (onOff) {
			optionsText [0].enabled = true;
			optionsText [1].enabled = true;
			optionsText [2].enabled = true;
			pauseBackGround.enabled = true;
			pauseActive = true;
		} else {
			optionsText [0].enabled = false;
			optionsText [1].enabled = false;
			optionsText [2].enabled = false;
			pauseBackGround.enabled = false;
			pauseActive = false;
		}
			
	}
}
