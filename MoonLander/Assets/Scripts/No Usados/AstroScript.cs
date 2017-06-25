using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroScript : MonoBehaviour {

	//Transform parent;
	Rigidbody2D rb;

	// Use this for initialization
	void Akawe () {
		//parent = transform.GetComponentInParent<Transform> ();
		rb = GetComponent<Rigidbody2D> ();
		rb.gravityScale = 0.00001f;
		// revisar gravedad del astronauta
		//this.gameObject.SetActive (false);


		//transform.position = parent.transform.position;
	}

	void Start(){}

	void Update(){}

	//void OnEnable(){}

	void FixUpdate () {}
}
