using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour {

	public int veces;
	public SpriteRenderer ClockImage;
	//private Sprite ClockSprite;
	public Animator ClockAnimator;

	public int ClockNumber;
	public Sprite[] clocks;


	void Start () {
		
		ClockImage = GetComponent<SpriteRenderer>();
		//ClockSprite = ClockImage.sprite;
		ClockAnimator = GetComponent<Animator> ();


		ClockAnimator.enabled = false;
		ClockNumber = 0;
		ClockImage.sprite = clocks[ClockNumber];
		//veces = 0;


		//InvokeRepeating ("CambiaHora", 0f, 7.5f);
		//GameController.tiempo = 0;
	}
	/*
	public void IniciaReloj(){
		ClockAnimator.enabled = false;
		ClockNumber = 0;
		ClockImage.sprite = clocks[ClockNumber];
		veces = 0;
		//InvokeRepeating ("CambiaHora", 0f, 7.5f);
	}
	public void ParaReloj(){
		CancelInvoke();
	}

	void CambiaHora () {

		if (ClockNumber < 9) {
			ClockImage.sprite = clocks[ClockNumber];
			ClockNumber++;
			veces++;
		}else{
			ClockNumber = 0;
			veces = 0;
			CancelInvoke ();
			ClockAnimator.enabled = true;
			GameController.BeingEaten ();
		}
		/*
		//Debug.Log (GameController.tiempo + " - " + veces + " - " + ClockNumber);
		if (GameController.tiempo > veces) {
			//Debug.Log (ClockNumber);
			if (ClockNumber == 9)
				ClockNumber = 0;
			ClockImage.sprite = clocks[ClockNumber];
			ClockNumber++;
			veces++;
		} else {
			// Clock animation
			ClockNumber = 0;
			veces = 0;
			ClockAnimator.enabled = true;
			GameController.BeingEaten ();
		}
		
	}
	*/
	// Funcion llamada en el final de la animacion del clock
	// Tambien cuando Nerd es comido, para resetear el reloj
	
	public void ResetImage(){
		ClockAnimator.enabled = false;
		ClockNumber = 0;
		ClockImage.sprite = clocks[ClockNumber];
	}
	
}
