using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector2(player.transform.position.x, transform.position.y);
	}
}
