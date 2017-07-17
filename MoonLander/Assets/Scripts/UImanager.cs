using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {

	public static UImanager instance = null; 

	private Main mainScript;
	private PauseUIScript pauseUI;

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
		pauseUI = GetComponent<PauseUIScript> ();

		winText = transform.FindChild ("WinText");
		loseText = transform.FindChild ("LoseText");
        comeBackText = transform.FindChild("ComeBack");

        winText.gameObject.SetActive (false);
		loseText.gameObject.SetActive (false);
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

        if (mainScript.GetUIComeBack())
            comeBackText.gameObject.SetActive(true);
        else
            comeBackText.gameObject.SetActive(false);


		// --- Pause ---
		if (mainScript.GetUIPause ())
			pauseUI.SetUIOnOff (true);
		else
			pauseUI.SetUIOnOff (false);
    }
}
 