using UnityEngine;
using UnityEngine.UI;

public class FuelUIScript : MonoBehaviour {

	UImanager parentScript;

	Text fuelCount;

    int naveFuel;
    float timer = 0;

	void Awake () {
        fuelCount = GetComponent<Text>();
		parentScript = transform.GetComponentInParent<UImanager> ();
	}
		
	void Update () {
        timer += Time.deltaTime;
        naveFuel = parentScript.naveFuel;

		if (naveFuel < 0) {
            fuelCount.text = "Fuel   Empty";
            fuelCount.enabled = true;
        }
        else{
            
			fuelCount.text = "Fuel   " + naveFuel.ToString();

            if (naveFuel < 200 && naveFuel > 0){

                if (timer > 0.2f && fuelCount.enabled == true){
                    fuelCount.enabled = false;
                    timer = 0;
                }
                else if (timer > 0.2f && fuelCount.enabled == false){
                    fuelCount.enabled = true;
                    timer = 0;
                }   
            }
            
        }
			
	}
}
