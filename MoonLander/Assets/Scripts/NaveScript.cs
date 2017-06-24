using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NaveScript : MonoBehaviour {


	//public delegate void NaveDestruida();
	//public static event NaveDestruida naveDestroid;
	//UnityEvent NaveLander;

    Rigidbody2D rb;

	float timer = 0f;
	bool gravityEstable = false;

	// Fuel
	private int fuel;
	private bool fuelEmpty;

	// Velocidad Vertical
	private float verticalVel;

	// Estado de Vivo
	private bool alive;

	RaycastHit2D hit;

	Vector2 startPosition;

	// Pause
	bool pause;
	Vector3 velocitySave;
	float angularVelocitySave;


	void Awake () {
        rb = GetComponent<Rigidbody2D>();
		startPosition = new Vector2(-9,8);
		Reset ();
		//NaveDestroid.AddListener ("Prueba");
	}


	void Reset()
	{
		rb.AddForce(Vector2.right * 20);
		transform.eulerAngles = new Vector3 (0,0,-15);
		verticalVel = 0;
		fuel = 1000;
		fuelEmpty = false;
		rb.gravityScale = 0.00001f;
		timer = 0f;
		transform.position = startPosition;
		pause = false;
		alive = true;
	}

	void Update () {
		if (alive && !pause)
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
		if (Input.GetKey(KeyCode.Space) && fuel > -1 && alive && !pause)
		{
			rb.AddRelativeForce(Vector2.up);
			gravityEstable = true;
			fuel -= 1;
		}

		if (fuelEmpty)
			rb.AddForce (Vector2.down * 0.1f);
    }





	void OnCollisionEnter2D(Collision2D coll){
		
		if (coll.relativeVelocity.magnitude > 0.6f)
			Destroid ();
		else if (transform.rotation.z > 0.25f || transform.rotation.z < -0.25f)
			Destroid ();
		else
			Lander(); // Puede medir la complejidad del aterrizaje y dar ma so manos puntos por eso.
	}

	void OnBecameInvisible(){Destroid();}




	void Destroid(){
		// + Animacion de Destruccion
		// + Hombre saliendo al espacio (plus)
		alive = false;
		StopMove ();
		verticalVel = 0f;
		print ("Perdiste");
		//naveDestroid.Invoke ();
	}

	void Lander(){
		alive = false;
		StopMove ();
		verticalVel = 0f;
		print ("Ganaste");
		//naveLander.Invoke ();
	}

	void StopMove(){
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0f;
	}

	public bool PauseStatus(){
		if (!pause) {
			pause = true;
			rb.gravityScale = 0f;
			velocitySave = rb.velocity;
			angularVelocitySave = rb.angularVelocity;
			StopMove ();

		} else {
			pause = false;
			rb.gravityScale = 0.002f;
			rb.velocity = velocitySave;
			rb.angularVelocity = angularVelocitySave;
		}
		return pause;
	}

	public int GetFuel(){return fuel;}

	public float GetVerticalVelocity(){return verticalVel;}

	public bool GetStatusAlive(){return alive;}

	public void SetReset(){Reset ();}

}
