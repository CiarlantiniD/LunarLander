using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NaveScript : MonoBehaviour {

	UnityEvent NaveDestroid;
	UnityEvent NaveLander;

    Rigidbody2D rb;

	float timer = 0f;
	bool gravityEstable = false;
	bool alive = true;

	private int fuel = 1000;
	private bool fuelEmpty = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 0.00001f;
		rb.AddForce(Vector2.right * 20);
		transform.eulerAngles = new Vector3 (0,0,-15);

		//NaveDestroid.AddListener ("Prueba");
	}


	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (Input.GetKey (KeyCode.LeftArrow) && fuel > -1) {
			transform.eulerAngles += Vector3.forward;
		} 
		else if (Input.GetKey (KeyCode.RightArrow) && fuel > -1) {
			transform.eulerAngles += Vector3.back;
		}


		if (gravityEstable || timer > 5.0f){
			rb.gravityScale = 0.002f;
		}

		if (fuel <= 0){fuelEmpty = true;}
	}





    void FixedUpdate()
    {
		if (Input.GetKey(KeyCode.Space) && fuel > -1)
		{
			rb.AddRelativeForce(Vector2.up);
			gravityEstable = true;
			fuel -= 1;
		}

		if (!fuelEmpty)
			rb.AddForce (Vector2.down * 0.2f);
    }





	void OnCollisionEnter2D(Collision2D coll){

        //rb.velocity.magnitude > 0.001f
        //print(coll.relativeVelocity.magnitude);



		if (coll.relativeVelocity.magnitude > 0.6f && transform.rotation.eulerAngles.z < 355.0f && transform.rotation.eulerAngles.z > 5.0f)
			NaveDestroid.Invoke ();
		else
			print ("Ganaste");
	}

	public int GetFuel(){return fuel;}


}
