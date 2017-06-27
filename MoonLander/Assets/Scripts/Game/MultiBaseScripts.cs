using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class MultiBaseScripts : MonoBehaviour {

	Main main;

	SpriteRenderer multiBase;
	float timer;
	float timerElements = 2f;

	bool naveAlive;
    bool hideBase = false;

	void Awake () {
		main = GameObject.Find("Main").GetComponent<Main>();

		multiBase = GetComponent<SpriteRenderer> ();
		multiBase.enabled = false;
	}

	void Update () {

		if (!main.GetPauseStatus () && main.GetStatusNaveAlive ()) {
			timer += Time.deltaTime;

			if (timer > timerElements) {
				if (multiBase.enabled == true) {
					timerElements = 4f;
					multiBase.enabled = false;
                    hideBase = false;
                } else if (multiBase.enabled == false) {
					timerElements = 2f;
					multiBase.enabled = true;
                    hideBase = true;
                }

				timer = 0;
			}
		}else if (main.GetPauseStatus() && hideBase){
            if (multiBase.enabled == true)
                multiBase.enabled = false;
        }
        else if (!main.GetStatusNaveAlive ()) {
			timer = 0;
			multiBase.enabled = false;
		}

        if (!main.GetPauseStatus() && hideBase){
            if (multiBase.enabled == false)
                multiBase.enabled = true;
        }
            

    }
}
