using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinPoints : MonoBehaviour {
	/*
	public void Borra100(){
		Destroy(this);
	}
*/

	public float delay = 0f;

	// Use this for initialization
	void BorraPoints () {
		Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay); 
	}

}