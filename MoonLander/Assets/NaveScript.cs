using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveScript : MonoBehaviour {

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {



		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.eulerAngles = new Vector3 (0, 0, 15);
		} 
		else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.eulerAngles = new Vector3 (0, 0, 345);
		}
		else {
			transform.eulerAngles = new Vector3 (0, 0, 0);
		}




	}

    void FixedUpdate()
    {
		if (Input.GetKey(KeyCode.Space))
		{
			rb.AddForce(Vector2.up * 5);

			if (Input.GetKey (KeyCode.LeftArrow)) {
				rb.AddForce (Vector2.left * 2);
			}
			else if (Input.GetKey (KeyCode.RightArrow)){
				rb.AddForce(Vector2.right * 2);
			}
		}
    }
}
