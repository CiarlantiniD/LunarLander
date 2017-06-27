using UnityEngine;

public class CursorManager : MonoBehaviour {

	public static CursorManager instance = null;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);

		Cursor.visible = false;
	}
}
