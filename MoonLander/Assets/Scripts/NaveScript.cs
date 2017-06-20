using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NaveScript : MonoBehaviour {


	public delegate void NaveDestruida();
	public static event NaveDestruida naveDestroid;
	//UnityEvent NaveLander;

    Rigidbody2D rb;

	float timer = 0f;
	bool gravityEstable = false;


	private int fuel = 1000;
	private bool fuelEmpty = false;

	private float verticalVel = 0;

	private bool alive = true;

	RaycastHit2D hit;


	void Awake () {
        rb = GetComponent<Rigidbody2D>();
		Reset ();

		//NaveDestroid.AddListener ("Prueba");
	}


	void Reset()
	{
		rb.AddForce(Vector2.right * 20);
		transform.eulerAngles = new Vector3 (0,0,-15);
		rb.gravityScale = 0.00001f;
		timer = 0f;
		alive = true;
	}

	void Update () {
		if (alive)
		{
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
	}





    void FixedUpdate()
    {
		if (Input.GetKey(KeyCode.Space) && fuel > -1 && alive == true)
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
			Destroid ();
		else if (transform.rotation.z > 0.25f || transform.rotation.z < -0.25f)
			Destroid ();
		else
			print ("Ganaste"); // Puede medir la complejidad del aterrizaje y dar ma so manos puntos por eso.
	}

	void OnBecameInvisible(){Destroid();}

	void Destroid(){
		// + agregar la explicion y el conjelamiento de las conbustible y demas elementos
		alive = false;
		StopMove ();
		verticalVel = 0f;
		print ("Perdiste");
		//naveDestroid.Invoke ();
	}

	void StopMove(){
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0f;
	}

	public int GetFuel(){return fuel;}

	public float GetVerticalVelocity(){return verticalVel;}

}
