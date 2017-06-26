using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionScript : MonoBehaviour {


	SpriteRenderer [] animationExplotion;
	float timer = 0;
	bool activate = false;
	int count = 0;



	void Awake () {
		//animationExplotion = transform.GetComponentsInChildren<SpriteRenderer> ();
		animationExplotion = new SpriteRenderer [5];

		animationExplotion [0] = transform.FindChild ("explo04").GetComponentInChildren<SpriteRenderer> ();
		animationExplotion [1] = transform.FindChild ("explo03").GetComponentInChildren<SpriteRenderer> ();
		animationExplotion [2] = transform.FindChild ("explo02").GetComponentInChildren<SpriteRenderer> ();
		animationExplotion [3] = transform.FindChild ("explo01").GetComponentInChildren<SpriteRenderer> ();
		animationExplotion [4] = transform.FindChild ("explo00").GetComponentInChildren<SpriteRenderer> ();
	}




	void Update () {

		if (activate) {
			timer += Time.deltaTime;

			if (timer > 0.05f) {
				++count;
				timer = 0;
			}
				


			switch(count){
				case 0:
					animationExplotion [0].enabled = true;
					break;
				case 1:
					animationExplotion [0].enabled = false;
					animationExplotion [1].enabled = true;
					break;
				case 2:
					animationExplotion [1].enabled = false;
					animationExplotion [2].enabled = true;
					break;
				case 3:
					animationExplotion [2].enabled = false;
					animationExplotion [3].enabled = true;
					break;
				case 4:
					animationExplotion [3].enabled = false;
					animationExplotion [4].enabled = true;
					break;
				default:
					animationExplotion [4].enabled = true;
					break;
			}
		}

	}

	public void ResetExplosion(){
		activate = false;
		count = 0;
		timer = 0;

		for (int i = 0; i < animationExplotion.Length; i++) {
			animationExplotion [i].enabled = false;
		}
	}

	public void ActiveExplotion(){
		activate = true;
	}

}
