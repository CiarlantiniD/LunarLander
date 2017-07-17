using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class NaveScript : MonoBehaviour {

    Rigidbody2D rb;
	SpriteRenderer sr;
	RaycastHit2D hit;
	Vector2 startPosition;
    Camera cameraShip;
    Vector3 vpPosition;

	float timer = 0f;
	bool gravityEstable = false;

	// SoundManager
	SoundManager soundManager;

	// Fuel
	private int fuel;
	private bool fuelEmpty;

	// Velocidad Vertical
	private float verticalVel;

	// Estado de Vivo
	private bool alive;
	private bool lander;
	private string tempNameMaultiBase;

	// GoodSpot Lander
	private bool goodSpotLander;
	private int multiScore;

	// Fuego de Propulsores
	GameObject shipFire;

	// Explotion
	ExplotionScript explotion;

	// Help Force
	private bool helpForce;

	// Pause
	bool pause;
	Vector3 velocitySave;
	float angularVelocitySave;

	void Awake () {
        rb = GetComponent<Rigidbody2D>(); 
		sr = GetComponent<SpriteRenderer> ();
        cameraShip = GameObject.Find("Main Camera").GetComponent<Camera>();
		startPosition = new Vector2(-9,8);
		shipFire = transform.GetChild (0).gameObject;
		explotion = transform.GetChild (1).GetComponent<ExplotionScript>();
		soundManager = GameObject.Find ("SoundManager").GetComponent<SoundManager> ();
		Reset ();
	}


	void Reset()
	{
		sr.enabled = true;
		shipFire.SetActive (false);
		explotion.ResetExplosion ();
		goodSpotLander = false;
		multiScore = 1;
		rb.AddForce(Vector2.right * 20);
		transform.eulerAngles = new Vector3 (0,0,-15);
		verticalVel = 0;
		fuel = PlayerPrefs.GetInt ("Fuel", 1000);
		fuelEmpty = false;
		rb.gravityScale = 0.00001f;
		timer = 0f;
		transform.position = startPosition;
		pause = false;
		alive = true;
		lander = false;
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
	
			if (fuel <= 0)
				fuelEmpty = true;
			else if (fuel < 200 && fuel > 0)
				soundManager.PlayFX_GameShipFuelAlarm ();

			// --- Prueba RayCast ---
			//hit = Physics2D.Raycast (transform.position, Vector2.down, Mathf.Infinity);
			//print("Distance : "+ hit.distance + " Hip Point: " + hit.point);
			//float distance = Mathf.Abs(hit.point.y - transform.position.y);
			//pr	int (distance);


			// --- Vertical Velocity ---
			verticalVel = rb.velocity.y * -100;
			if (verticalVel < 0)
				verticalVel = verticalVel * -1;

            // --- Position in Camera ---
            vpPosition = cameraShip.WorldToViewportPoint(transform.position);

			if (vpPosition.x < -0.1f || vpPosition.x > 1.1f || vpPosition.y > 1.1f)
				NaveOutSpace ();
        }
    }


    void FixedUpdate()
    {
		if (Input.GetKey (KeyCode.Space) && fuel > -1 && alive && !pause) {
			rb.AddRelativeForce (Vector2.up);
			gravityEstable = true;
			shipFire.SetActive (true);
			fuel -= 1;
			soundManager.PlayFX_GameShipFire (true);
		} 
		else {
			shipFire.SetActive (false);
			soundManager.PlayFX_GameShipFire (false);
		}

		if (fuelEmpty)
			rb.AddForce (Vector2.down * 0.1f);

		if (rb.velocity.y == 0 && rb.velocity.x == 0)
			rb.AddRelativeForce (Vector2.down * 0.1f);
    }


	void OnTriggerEnter2D(Collider2D triggerColl){

		if (triggerColl.gameObject.tag == "GoodSpot") {
			goodSpotLander = true;

			tempNameMaultiBase = triggerColl.gameObject.name;
			tempNameMaultiBase = tempNameMaultiBase.Substring (0, 11);

			if (tempNameMaultiBase == "BaseMult_x2")
				multiScore = 2;
			else if (tempNameMaultiBase == "BaseMult_x3")
				multiScore = 3;
			else if (tempNameMaultiBase == "BaseMult_x5")
				multiScore = 5;
		}
	}

	void OnTriggerExit2D(Collider2D triggerColl){

		if (triggerColl.gameObject.tag == "GoodSpot") {
			goodSpotLander = false;
			multiScore = 1;
		}
	}
		
	void OnCollisionEnter2D(Collision2D coll){

		if (coll.relativeVelocity.magnitude > 0.20f)
			Destroid ();
		else if (transform.rotation.z > 0.12f || transform.rotation.z < -0.12f)
			Destroid ();
		else if (!goodSpotLander)
			Destroid ();
		else
			Lander();
	}

	void Destroid(){
		alive = false;
		StopMove ();
		verticalVel = 0f;
		sr.enabled = false;
		explotion.ActiveExplotion ();
		soundManager.PlayFX_GameShipExplotion ();
	}

	void Lander(){
		alive = false;
		StopMove ();
		verticalVel = 0f;
		lander = true;
		soundManager.PlayFX_GameShipLander ();
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

	public void SetReset(){Reset ();}

	public int GetFuel(){return fuel;}
	public float GetVerticalVelocity(){return verticalVel;}

	public bool GetStatusAlive(){return alive;}
	public bool Getlander(){return lander;}

	public int GetBaseMulti(){return multiScore;}

    public Vector3 GetvpPosition() { return vpPosition; }

	public void TimeOut(){
		if (alive)
			Destroid ();
	}

	private void NaveOutSpace(){
		if (alive)
			Destroid ();
	}
}