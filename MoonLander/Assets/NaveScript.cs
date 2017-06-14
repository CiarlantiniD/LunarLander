using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveScript : MonoBehaviour {

    Rigidbody2D rb;

	float timer = 0f;
	bool gravityEstable = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 0.00001f;
		rb.AddForce(Vector2.right * 20);
		transform.eulerAngles = new Vector3 (0,0,-15);
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.eulerAngles += Vector3.forward;
		} 
		else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.eulerAngles += Vector3.back;
		}


		if (gravityEstable || timer > 5.0f){
			rb.gravityScale = 0.002f;
		}


	}

    void FixedUpdate()
    {
		if (Input.GetKey(KeyCode.Space))
		{
			rb.AddRelativeForce(Vector2.up);
			gravityEstable = true;
		}
    }


	void OnCollisionEnter2D(Collision2D coll){

        //rb.velocity.magnitude > 0.001f
        print(coll.relativeVelocity.magnitude);


        if (coll.relativeVelocity.magnitude > 0.6f) {
			print ("Perdiste");
		} else {
			print ("Ganaste");
		}
	}


}
