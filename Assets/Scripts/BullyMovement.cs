using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyMovement : MonoBehaviour {

	// En esta clase el BUlly mira donde se encuentra
	// el Nerd y en funcion de eso decide hacia donde moverse.
	// Solo se mueve a lo largo del pasillo.

	// In this class Bully look at the Nerd's position
	// and then decides where to move to.
	// He only moves along the gallery.


	public static float currentY;
	public static float currentX;
	private float Dx;
	private float Dy;
	private int dir;
	public static float aceleracion;

	// Use this for initialization
	 void Start () {
		dir = 3;
		currentX = 56;//GameController.BullyTransform.localPosition.x;
		currentY = 56;//GameController.BullyTransform.localPosition.y;
		//Dx = Mathf.Abs (currentX) - Mathf.Abs (GameController.NerdTransform.localPosition.x);
		//Dy = Mathf.Abs (currentY) - Mathf.Abs (GameController.NerdTransform.localPosition.y);
		aceleracion = 1;
	}
	
	// Update is called once per frame
	void Update () {
		aceleracion = GameController.BullyAceleracion;
		//Debug.Log ("aceleracion="+aceleracion);
		if (GameController.status == 1) {
			switch (dir) {
			case 0:
				//currentY++;
				currentY = currentY + aceleracion;
				break;
			case 1:
				//currentX++;
				currentX = currentX + aceleracion;
				break;
			case 2:
				//currentY--;
				currentY = currentY - aceleracion;
				break;
			case 3:
				//currentX--;
				currentX = currentX - aceleracion;
				break;
			}

			//Dx = Mathf.Abs (currentX) - Mathf.Abs (GameController.NerdTransform.localPosition.x);
			//Dy = Mathf.Abs (currentY) - Mathf.Abs (GameController.NerdTransform.localPosition.y);
				
			GameController.BullyTransform.localPosition = new Vector2 (currentX, currentY);
			// Si llega a una de las esquinas tiene que decidir cual es la siguiente direccion
			// en funcion de donde este el Nerd
			if (currentX >= 55.98 && currentY >= 55.98) { //Bully esta en top right
				currentX = 56;
				currentY = 56;
				if (GameController.ClosestCorner() == 0) {
					dir = 3;
				} else {
					dir = 2;
				}
			} else if (currentX <= -55.98 && currentY >= 55.98) { //Bully esta en top left
				currentX = -56;
				currentY = 56;
				if (GameController.ClosestCorner() == 1) {
					dir = 1;
				} else {
					dir = 2;
				}
			} else if (currentX <= -55.98 && currentY <= -55.98) { //Bully esta en bottom left
				currentX = -56;
				currentY = -56;
				if (GameController.ClosestCorner() == 0) {
					dir = 0;
				} else {
					dir = 1;
				}
			} else if (currentX >= 55.98 && currentY <= -55.98) { //Bully esta en bottom right
				currentX = 56;
				currentY = -56;
				if (GameController.ClosestCorner() == 1) {
					dir = 0;
				} else {
					dir = 3;
				}
			}
		}
	}
}
