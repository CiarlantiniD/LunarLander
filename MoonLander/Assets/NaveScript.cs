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
	void Update () {}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * 20);
        }
    }
}
