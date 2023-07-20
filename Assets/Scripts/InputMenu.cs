using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMenu : MonoBehaviour {

	public bool keyOne;


	void Awake(){
		
	}


	void Update () {
		if (GameController.status == 0) {
			keyOne = Input.GetKey (KeyCode.Alpha1);
		}
	}
}
