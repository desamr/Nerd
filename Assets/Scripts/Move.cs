using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	private Animator animacion1;
	//private Rigidbody2D body2d;
	//private InputState inputState;
	private Transform transformacion;
	private SpriteRenderer nerdSpriteRenderer;
	private Sprite nerdSprite;
	private float currentY;
	private float currentX;
	private int x;
	private int y;


	void Awake () {
		animacion1 = GetComponent<Animator> ();
		//body2d = GetComponent<Rigidbody2D> ();
		//inputState = GetComponent<InputState> ();
		transformacion = GetComponent<Transform> ();
		nerdSpriteRenderer = GetComponent<SpriteRenderer> ();
		nerdSprite = nerdSpriteRenderer.sprite;


	}
	
	// Update is called once per frame
	void Update () {
		
		if (GameController.status == 1) {
			//Debug.Log (GameController.status);
			/*
			if (Input.GetButton ("Horizontal")) {
				animacion1.enabled = true;
				currentX = transform.localPosition.x;
				currentX += Input.GetAxis ("Horizontal");
				transformacion.localPosition = new Vector2 (currentX, transform.localPosition.y);
			} else if (Input.GetButton ("Vertical")) {
				animacion1.enabled = true;
				currentY = transform.localPosition.y;
				currentY += Input.GetAxis ("Vertical");
				transformacion.localPosition = new Vector2 (transform.localPosition.x, currentY);
			} else if (Input.GetButton ("Fire1")) {
				if (GameController.beamupavailable) {
					GameController.beamupavailable = false;
					GameController.PosicionValida ();
					GameController.pospixels (y, x);
					currentY = y+7;
					currentX = x+8;
					transformacion.localPosition = new Vector2 (currentX, currentY);
					GameController.objComplete.SetActive (false);
					GameController.objLoading.SetActive (true);
					GameController.objLoading.transform.localScale = new Vector2 (0f, GameController.objLoading.transform.localScale.y);
				}
			} else if (Input.GetButton("Pause")){
				Time.timeScale = 0;
				GameController.status = 3;
			}
			*/

			if (Input.GetButton ("HorizontalKey")) {
				animacion1.enabled = true;
				currentX = transform.localPosition.x;
				currentX += Input.GetAxis ("HorizontalKey");
				transformacion.localPosition = new Vector2 (currentX, transform.localPosition.y);
			} else if (Input.GetButton ("VerticalKey")) {
				animacion1.enabled = true;
				currentY = transform.localPosition.y;
				currentY += Input.GetAxis ("VerticalKey");
				transformacion.localPosition = new Vector2 (transform.localPosition.x, currentY);
			} else {	
				currentX = transform.localPosition.x;
				currentX += Input.GetAxis ("Horizontal");
				transformacion.localPosition = new Vector2 (currentX, transform.localPosition.y);

				currentY = transform.localPosition.y;
				currentY -= Input.GetAxis ("Vertical");
				transformacion.localPosition = new Vector2 (transform.localPosition.x, currentY);
			}
			if (Input.GetButton ("Fire1")) {
				if (GameController.beamupavailable) {
					GameController.beamupavailable = false;
					GameController.PosicionValida ();
					GameController.pospixels (y, x);
					currentY = y+7;
					currentX = x+8;
					transformacion.localPosition = new Vector2 (currentX, currentY);
					GameController.objComplete.SetActive (false);
					GameController.objLoading.SetActive (true);
					GameController.objLoading.transform.localScale = new Vector2 (0f, GameController.objLoading.transform.localScale.y);
				}
			} else if (Input.GetButton("Pause")){
				Time.timeScale = 0;
				GameController.status = 3;
			}
			
		}else if(GameController.status == 3){
			if(Input.GetButton ("Cancel") || Input.GetButton("Pause")){
				GameController.status = 1;
				Time.timeScale = 1;
			}
		}
	}
}
