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


	private int fuel = 1000;
	private bool fuelEmpty = false;

	private float verticalVel = 0;

	RaycastHit2D hit;

	// Use this for initialization
	void Awake () {
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
		} else if (Input.GetKey (KeyCode.RightArrow) && fuel > -1) {
			transform.eulerAngles += Vector3.back;
		}


		if (gravityEstable || timer > 5.0f) {
			rb.gravityScale = 0.002f;
		}

		if (fuel <= 0) {
			fuelEmpty = true;
		}

		// --- Prueba RayCast ---
		//hit = Physics2D.Raycast (transform.position, Vector2.down, Mathf.Infinity);
		//print("Distance : "+ hit.distance + " Hip Point: " + hit.point);
		//float distance = Mathf.Abs(hit.point.y - transform.position.y);
		//pr	int (distance);


		// --- Prueba Vertical Velocity ---
		verticalVel = rb.velocity.y * -100;
		if (verticalVel < 0)
			verticalVel = verticalVel * -1;
	}





    void FixedUpdate()
    {
		if (Input.GetKey(KeyCode.Space) && fuel > -1)
		{
			rb.AddRelativeForce(Vector2.up);
			gravityEstable = true;
			fuel -= 1;
		}

		if (fuelEmpty)
			rb.AddForce (Vector2.down * 0.1f);
    }





	void OnCollisionEnter2D(Collision2D coll){

		//print(transform.rotation.eulerAngles.z);
		//print (transform.rotation.z);

		if (coll.relativeVelocity.magnitude > 0.6f)
			print ("Perdiste");//NaveDestroid.Invoke ();
		else if (transform.rotation.z > 0.25f || transform.rotation.z < -0.25f)
			print ("Perdiste");
		else
			print ("Ganaste"); // Puede medir la complejidad del aterrizaje y dar ma so manos puntos por eso.
	}

	void OnBecameInvisible(){print ("Perdiste");} // agregar evento de derrota

	public int GetFuel(){return fuel;}

	public float GetVerticalVelocity(){return verticalVel;}

}
