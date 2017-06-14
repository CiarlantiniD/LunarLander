using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Cuadrado : MonoBehaviour {

	private Rigidbody2D rb;
	private SpriteRenderer rend;

	void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
		rend = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Q)) { 
			rb.AddForce (Vector2.right, ForceMode2D.Impulse);
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			rb.Sleep ();
			rb.MovePosition (Vector2.zero);
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			rb.AddForceAtPosition(Vector2.right,
				new Vector2(transform.position.x, rend.bounds.min.y),ForceMode2D.Impulse);
		}
	}
}
