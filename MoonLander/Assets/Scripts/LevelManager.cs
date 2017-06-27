using System.Collections; using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public static LevelManager instance = null;

	private int selectLevel = 0;
	private int actuaLevel = 1;

	int maxlevels = 5;
	Transform [] level;

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		level = new Transform [6]; 

		for (int i = 1; i < maxlevels+1; i++) {
			level[i] = transform.GetChild(i-1).GetComponent<Transform>();
			level [i].gameObject.SetActive (false);
		}
	}

	void Update () {

		if (selectLevel != 0) {
			switch (selectLevel) {
			case 1:
				level [actuaLevel].gameObject.SetActive (false);
				level [selectLevel].gameObject.SetActive (true);
				break;
			case 2:
				level [actuaLevel].gameObject.SetActive (false);
				level [selectLevel].gameObject.SetActive (true);
				break;
			case 3:
				level [actuaLevel].gameObject.SetActive (false);
				level [selectLevel].gameObject.SetActive (true);
				break;
			case 4:
				level [actuaLevel].gameObject.SetActive (false);
				level [selectLevel].gameObject.SetActive (true);
				break;
			case 5:
				level [actuaLevel].gameObject.SetActive (false);
				level [selectLevel].gameObject.SetActive (true);
				break;
			default:
				level [actuaLevel].gameObject.SetActive (false);
				level [1].gameObject.SetActive (true);
				break;
			}
			actuaLevel = selectLevel;
			selectLevel = 0;
		}
			
	}

	public void ChangeLevel(int selectleveltochange){
		selectLevel = selectleveltochange;
	}
		
	public int GetMaxLevels(){return maxlevels;}
}
