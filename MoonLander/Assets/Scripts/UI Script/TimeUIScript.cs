using UnityEngine;
using UnityEngine.UI;

public class TimeUIScript : MonoBehaviour {

	UImanager parentScript;

	Text timerTextUI;

	float gameTime;
	float seg, min = 0;
	float timer = 0;

	string sMin, sSeg, addMin, addSeg;

	void Awake () {
		parentScript = transform.GetComponentInParent<UImanager> ();
		timerTextUI = GetComponent<Text> ();
	}

	void Update () {
		timer += Time.deltaTime;

		gameTime = parentScript.timeGame;
		seg = (int)gameTime % 60;
		min = (int)gameTime / 60;

		sMin = min.ToString ();
		sSeg = seg.ToString ();

		if (seg < 10)
			sSeg = "0" + sSeg;

		if (min < 10)
			sMin = "0" + sMin;

		timerTextUI.text = "'" + sMin + "  ''" + sSeg;




		if (gameTime > 500){

			if (timer > 0.2f && timerTextUI.enabled == true){
				timerTextUI.enabled = false;
				timer = 0;
			}
			else if (timer > 0.2f && timerTextUI.enabled == false){
				timerTextUI.enabled = true;
				timer = 0;
			}   
		}



	}
}
