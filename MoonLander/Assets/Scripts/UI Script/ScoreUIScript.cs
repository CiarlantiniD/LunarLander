using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIScript : MonoBehaviour {

	UImanager parentScript;

	Text scoreCount;
	int score;

	// Use this for initialization
	void Awake () {
		scoreCount = GetComponent<Text> ();
		parentScript = transform.GetComponentInParent<UImanager> ();
	}
		
	void Update () {
		score = parentScript.score;

		if (score == 0)
			scoreCount.text = "00000000";
		if (score < 10)
			scoreCount.text = "0000000" + score.ToString();
		else if (score < 100)
			scoreCount.text = "000000" + score.ToString();
		else if (score < 1000)
			scoreCount.text = "00000" + score.ToString();
		else if (score < 10000)
			scoreCount.text = "0000" + score.ToString();
		else if (score < 100000)
			scoreCount.text = "000" + score.ToString();
		else if (score < 1000000)
			scoreCount.text = "00" + score.ToString();
		else if (score < 10000000)
			scoreCount.text = "0" + score.ToString();
		else if (score < 100000000)
			scoreCount.text = score.ToString();
		else
			scoreCount.text = "99999999";
	}
}
