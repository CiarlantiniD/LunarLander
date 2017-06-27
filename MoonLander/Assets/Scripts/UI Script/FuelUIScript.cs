using UnityEngine;
using UnityEngine.UI;

public class FuelUIScript : MonoBehaviour {

	UImanager parentScript;

	Text fuelCount;
    SpriteRenderer sr;

    int naveFuel;
    float timer = 0;

	void Awake () {
        fuelCount = GetComponent<Text>();
        sr = GetComponent<SpriteRenderer>();
		parentScript = transform.GetComponentInParent<UImanager> ();
	}
		
	void Update () {
        timer += Time.deltaTime;
        naveFuel = parentScript.naveFuel;

		if (naveFuel < 0)
			fuelCount.text = "Fuel   Empty";
        else
        {
            fuelCount.text = "Fuel   " + naveFuel.ToString();

            if (naveFuel < 200 && naveFuel > 0){
                if(timer > 1f && sr.enabled == true)
                {
                    sr.enabled = false;
                    timer = 0;
                }
                else if (timer > 1f && sr.enabled == false){
                    sr.enabled = true;
                    timer = 0;
                }
                
            }
        }
			
	}
}
