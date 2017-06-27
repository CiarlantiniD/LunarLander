using System.Collections; using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {

	public static CursorManager instance = null;

	void Start()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);

		Cursor.visible = false;
	}
}
