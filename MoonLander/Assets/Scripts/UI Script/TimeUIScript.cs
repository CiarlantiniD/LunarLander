﻿using UnityEngine;
using UnityEngine.UI;

public class TimeUIScript : MonoBehaviour {

	UImanager parentScript;

	Text timerTextUI;

	float timer;
	float seg, min = 0;

	string sMin, sSeg, addMin, addSeg;

	void Awake () {
		parentScript = transform.GetComponentInParent<UImanager> ();
		timerTextUI = GetComponent<Text> ();
	}

	void Update () {
		timer = parentScript.timeGame;
		seg = (int)timer % 60;
		min = (int)timer / 60;

		sMin = min.ToString ();
		sSeg = seg.ToString ();

		if (seg < 10)
			sSeg = "0" + sSeg;

		if (min < 10)
			sMin = "0" + sMin;

		timerTextUI.text = "'" + sMin + "  ''" + sSeg;
	}
}
