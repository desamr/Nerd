using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyCollisions : MonoBehaviour {

	public bool Colliding;
	private ClockController RelojController;





	void Start(){
		Colliding = false;
		RelojController = GameObject.Find ("Clock").GetComponent<ClockController> ();
			
		//NerdBeingEaten = GameObject.Find ("NerdBeingEaten");
		//NerdBeingEatenSprite = NerdBeingEaten.GetComponent<SpriteRenderer>().sprite;
	}

	void OnTriggerEnter2D(Collider2D col){
		//Destroy (col.gameObject);

		Colliding = true;
		//Debug.Log ("Colliding with " + col.gameObject.name);
		if (col.gameObject.name == "Nerd") {
			//Debug.Log ("Nerd collides with Bully");
			/*GameController.status = 2;
			GameController.BullyWalking.enabled = false;*/
			//GameController.NerdAnimator = col.gameObject.GetComponent<Animator> ();
			//NerdAnimator.enabled = false;
			//NerdSprite = col.gameObject.GetComponent<SpriteRenderer> ();
			//Debug.Log(NerdSprite.sprite);
			//NerdSprite.sprite = NerdBeingEatenSprite;
			//GameController.NerdAnimator.SetBool("BeingEaten",true);
			//if (RelojController) {
			RelojController.ClockNumber = 0;
			RelojController.veces = 1;
			//RelojController.ResetImage ();
				//RelojController.ClockAnimator.enabled = true;
			//}
			GameController.BeingEaten();
			/*GameController.NerdTransform2.localPosition = new Vector2(GameController.Nerd.transform.localPosition.x, GameController.Nerd.transform.localPosition.y);
			GameController.NerdTransform.localPosition = new Vector2 (-200f, GameController.Nerd.transform.localPosition.y);
			GameController.NerdAnimator2.enabled = true;
			GameController.NerdAnimator2.Play ("New_BeingEaten", 0, 0f);
			 */
		}

	}
	/*
	void onCollisionExit2D(){
		Colliding = false;
	}
	*/	
}
