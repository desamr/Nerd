using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionMenu : MonoBehaviour {
	private InputMenu inputMenu;
	// Use this for initialization
	void Awake () {
		inputMenu = GetComponent<InputMenu> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.status == 0) {
			if (inputMenu.keyOne) {
				Debug.Log ("llamando a Preinicio");
				//comienza el juego
				GameController.PreInicio ();
				inputMenu.keyOne = false;
			}
		}
	}
}
