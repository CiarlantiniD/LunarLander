using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {

	public static UImanager instance = null; 

	private Main mainScript;

	public int naveFuel;
	public float naveVerticalVel;

	Transform winText;
	Transform loseText;
	Transform pauseText;
    Transform comeBackText;

    public int lifes;
	public int score;

	public float timeGame;

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		mainScript = GameObject.Find ("Main").GetComponent<Main> ();

		winText = transform.FindChild ("WinText");
		loseText = transform.FindChild ("LoseText");
		pauseText = transform.FindChild ("PauseText");
        comeBackText = transform.FindChild("ComeBack");

        winText.gameObject.SetActive (false);
		loseText.gameObject.SetActive (false);
		pauseText.gameObject.SetActive (false);
        comeBackText.gameObject.SetActive(false);

    }
		
	void Update () {

		// --- UI PLayer ---
		lifes = mainScript.GetLifes ();
		score = mainScript.GetScore ();

		// --- UI Nave ---
		naveFuel = mainScript.GetNaveFuel ();
		naveVerticalVel = mainScript.GetNaveVerticalVel ();

		// --- UI Time ---
		timeGame = mainScript.GetTime();

		// --- UI Mesenger ---
		if (mainScript.GetUIWin ())
			winText.gameObject.SetActive (true);
		else
			winText.gameObject.SetActive (false);

		if (mainScript.GetUILose ())
			loseText.gameObject.SetActive (true);
		else
			loseText.gameObject.SetActive (false);

		if (mainScript.GetUIPause ())
			pauseText.gameObject.SetActive (true);
		else
			pauseText.gameObject.SetActive (false);

        if (mainScript.GetUIComeBack())
            comeBackText.gameObject.SetActive(true);
        else
            comeBackText.gameObject.SetActive(false);
    }
}
 