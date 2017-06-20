using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroScript : MonoBehaviour {

	Transform parent;
	Rigidbody2D rb;

	// Use this for initialization
	void Akawe () {
		parent = transform.GetComponentInParent<Transform> ();
		rb.gravityScale = 0.002f; // revisar gravedad del astronauta
		//this.gameObject.SetActive (false);


		//transform.position = parent.transform.position;
	}

	//void OnEnable(){}

	// Update is called once per frame
	void FixUpdate () {
		
	}
}
