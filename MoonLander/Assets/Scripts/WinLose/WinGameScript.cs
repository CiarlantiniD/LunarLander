using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinGameScript : MonoBehaviour {

	Transform [] texts;

	float timer = 0;

	int score;
	int bestScore;
	string bestScoreYou;

	Text scoreText;
	Text bestScoreText;

	void Awake () {
		texts = transform.GetComponentsInChildren<Transform> (); 

		scoreText = texts[2].GetComponent<Text> ();
		bestScoreText= texts[3].GetComponent<Text> ();

		score = PlayerPrefs.GetInt ("Score");
		bestScore = PlayerPrefs.GetInt ("BestScore");
		PlayerPrefs.SetInt ("Score", 0);

		if (score > bestScore)
			bestScoreYou = " (You)";
		else
			bestScoreYou = "";

		scoreText.text = "You Score - " + ConvertScore (score);
		bestScoreText.text = "Best Score - " + ConvertScore (bestScore) + bestScoreYou;
	}

	void Update () {
		timer += Time.deltaTime;


		if (timer > 4.5f) {
			for (int i = 1; i < texts.Length; i++) {
				texts [i].gameObject.SetActive (false);
			}
		}

		if (timer > 6.0f)
			SceneManager.LoadScene ("MainMenu");
		
	}

	string ConvertScore(int scoreToConvert){
		if (scoreToConvert == 0)
			return "00000000";
		if (scoreToConvert < 10)
			return "0000000" + scoreToConvert.ToString();
		else if (scoreToConvert < 100)
			return "000000" + scoreToConvert.ToString();
		else if (scoreToConvert < 1000)
			return "00000" + scoreToConvert.ToString();
		else if (scoreToConvert < 10000)
			return "0000" + scoreToConvert.ToString();
		else if (scoreToConvert < 100000)
			return "000" + scoreToConvert.ToString();
		else if (scoreToConvert < 1000000)
			return "00" + scoreToConvert.ToString();
		else if (scoreToConvert < 10000000)
			return "0" + scoreToConvert.ToString();
		else if (scoreToConvert < 100000000)
			return scoreToConvert.ToString();
		else
			return "99999999";
	}
}
