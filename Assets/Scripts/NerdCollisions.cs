using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerdCollisions : MonoBehaviour {
	/*
	public static int calculo;
	private static GameObject Clock;
	private static ClockController RelojController;
	private static SpriteRenderer ClockSpriteRenderer;
	*/
	void Start(){
		//calculo = 0;

	}

	void OnTriggerEnter2D(Collider2D col){
	//void OnCollisionEnter2D(Collision2D col){
		//Debug.Log("He entrado en OnTriggerEnter y lo mando a ColisionHoja");
		GameController.ColisionHoja (col.gameObject.name);
		/*
		Debug.Log ("AL ENTRAR en OnTriggerEnter2D");
		//Debug.Log ("Colliding with " + col.gameObject.name);
		if (col.gameObject.name == "PaperCopy_operando1") {

			if (calculo == 0) {
				GameController.AnimacionPuntos ("PaperCopy_operando1");
				GameController.PasarEscoba ("PaperCopy_operando1");
				calculo = 1;
			} else if (calculo == 2 && GameController.operacion) {
				GameController.AnimacionPuntos ("PaperCopy_operando1");
				GameController.PasarEscoba ("PaperCopy_operando1");
				calculo = 3;
			}
		}else if(col.gameObject.name == "PaperCopy_operando2"){
			if (calculo == 0 && GameController.operacion) {
				GameController.AnimacionPuntos ("PaperCopy_operando2");
				GameController.PasarEscoba ("PaperCopy_operando2");
				GameController.CambiaPizarra (true);
				calculo = 1;
			} else if (calculo == 2) {
				GameController.AnimacionPuntos ("PaperCopy_operando2");
				GameController.PasarEscoba ("PaperCopy_operando2");
				calculo = 3;
			}else if (calculo == 4 && !GameController.operacion) {
				GameController.AnimacionPuntos ("PaperCopy_operando2");
				GameController.PasarEscoba ("PaperCopy_operando2");
				Clock = GameObject.Find ("Clock");
				RelojController = Clock.GetComponent<ClockController> ();
				ClockSpriteRenderer = Clock.GetComponent<SpriteRenderer>();
				if (RelojController.ClockNumber >= 2) {
					RelojController.ClockNumber -= 2;
					GameController.tiempo += 2;
					RelojController.veces -= 2;
				} else if (RelojController.ClockNumber == 1) {
					RelojController.ClockNumber=0;
					GameController.tiempo ++;
					RelojController.veces = 1;
				}
				if(RelojController.ClockNumber>=0) ClockSpriteRenderer.sprite = RelojController.clocks [RelojController.ClockNumber];
				calculo = 0;
				Debug.Log ("Antes de llamar a NuevaOperacion (en una resta)");
				GameController.NuevaOperacion ();
			}
		}else if(col.gameObject.name == "PaperCopy_operacion"){
			if (calculo == 1) {
				GameController.AnimacionPuntos ("PaperCopy_operacion");
				GameController.PasarEscoba ("PaperCopy_operacion");
				calculo = 2;
			}
		}else if(col.gameObject.name == "PaperCopy_resultado"){
			if (calculo == 2 && !GameController.operacion) {
				GameController.AnimacionPuntos ("PaperCopy_resultado");
				GameController.PasarEscoba ("PaperCopy_resultado");
				calculo = 3;
				GameController.CambiaPizarra (false);
			} else if (calculo == 4) {
				GameController.AnimacionPuntos ("PaperCopy_resultado");
				GameController.PasarEscoba ("PaperCopy_resultado");
				Clock = GameObject.Find ("Clock");
				RelojController = Clock.GetComponent<ClockController> ();
				ClockSpriteRenderer = Clock.GetComponent<SpriteRenderer> ();
				if (RelojController.ClockNumber >= 2) {
					RelojController.ClockNumber -= 2;
					GameController.tiempo += 2;
					RelojController.veces -= 2;
				} else if (RelojController.ClockNumber == 1) {
					RelojController.ClockNumber = 0;
					GameController.tiempo++;
					RelojController.veces = 1;
				}
				if (RelojController.ClockNumber >= 0)
					ClockSpriteRenderer.sprite = RelojController.clocks [RelojController.ClockNumber];
				calculo = 0;
				Debug.Log ("Antes de llamar a NuevaOperacion (en una suma)");
				GameController.NuevaOperacion ();
			}
		}else if(col.gameObject.name == "PaperCopy_igual"){
			if (calculo == 3) {
				GameController.AnimacionPuntos ("PaperCopy_igual");
				GameController.PasarEscoba ("PaperCopy_igual");

				calculo = 4;
			}
		}

		*/
		/*
		if (calculo == 0 && col.gameObject.name == "PaperCopy_operando1") {
			//GameController.AnimacionPuntos ("PaperCopy_operando1");
			//GameController.PasarEscoba ("PaperCopy_operando1");

			//calculo = 1;
		} else if (calculo == 0 && GameController.operacion && col.gameObject.name == "PaperCopy_operando2") {
			//GameController.AnimacionPuntos ("PaperCopy_operando2");
			//GameController.PasarEscoba ("PaperCopy_operando2");
			//Cambia valores de la pizarra
			//GameController.CambiaPizarra(true);
			//calculo = 1;
		} else if (calculo == 1 && col.gameObject.name == "PaperCopy_operacion") {
			//GameController.AnimacionPuntos ("PaperCopy_operacion");
			//GameController.PasarEscoba ("PaperCopy_operacion");

			//calculo = 2;
		} else if (calculo == 2 && col.gameObject.name == "PaperCopy_operando2") {
			//GameController.AnimacionPuntos ("PaperCopy_operando2");
			//GameController.PasarEscoba ("PaperCopy_operando2");

			//calculo = 3;
		} else if (calculo == 2 && GameController.operacion && col.gameObject.name == "PaperCopy_operando1") {
			//GameController.AnimacionPuntos ("PaperCopy_operando1");
			//GameController.PasarEscoba ("PaperCopy_operando1");

			//calculo = 3;
		} else if (calculo == 2 && !GameController.operacion && col.gameObject.name == "PaperCopy_resultado") {
			//GameController.AnimacionPuntos ("PaperCopy_resultado");
			//GameController.PasarEscoba ("PaperCopy_resultado");

			//calculo = 3;
			//GameController.CambiaPizarra(false);
		} else if (calculo == 3 && col.gameObject.name == "PaperCopy_igual") {
			//GameController.AnimacionPuntos ("PaperCopy_igual");
			//GameController.PasarEscoba ("PaperCopy_igual");

			//calculo = 4;
		} else if (calculo == 4 && col.gameObject.name == "PaperCopy_resultado") {
			
			GameController.AnimacionPuntos ("PaperCopy_resultado");
			GameController.PasarEscoba ("PaperCopy_resultado");

			Clock = GameObject.Find ("Clock");
			RelojController = Clock.GetComponent<ClockController> ();
			ClockSpriteRenderer = Clock.GetComponent<SpriteRenderer>();


			//Debug.Log (RelojController.ClockNumber);
			if (RelojController.ClockNumber >= 2) {
				RelojController.ClockNumber -= 2;
				GameController.tiempo += 2;
				RelojController.veces -= 2;
			}else if (RelojController.ClockNumber == 1) {
				RelojController.ClockNumber=0;
				GameController.tiempo ++;
				RelojController.veces = 1;
			}
			//Debug.Log (GameController.tiempo);



			if(RelojController.ClockNumber>=0) ClockSpriteRenderer.sprite = RelojController.clocks [RelojController.ClockNumber];
			//ClockSpriteRenderer.sprite = RelojController.clocks [0];

			calculo = 0;

			Debug.Log ("Antes de llamar a NuevaOperacion (en una suma)");
			GameController.NuevaOperacion ();

		} else if (calculo == 4 && !GameController.operacion && col.gameObject.name == "PaperCopy_operando2") {
			
			GameController.AnimacionPuntos ("PaperCopy_operando2");
			GameController.PasarEscoba ("PaperCopy_operando2");

			Clock = GameObject.Find ("Clock");
			RelojController = Clock.GetComponent<ClockController> ();
			ClockSpriteRenderer = Clock.GetComponent<SpriteRenderer>();

			//Debug.Log (RelojController.ClockNumber);
			if (RelojController.ClockNumber >= 2) {
				RelojController.ClockNumber -= 2;
				GameController.tiempo += 2;
				RelojController.veces -= 2;
				//RelojController.ResetImage ();
			} else if (RelojController.ClockNumber == 1) {
				RelojController.ClockNumber=0;
				GameController.tiempo ++;
				RelojController.veces = 1;
				//RelojController.ResetImage ();
			}
			//Debug.Log (GameController.tiempo);



			if(RelojController.ClockNumber>=0) ClockSpriteRenderer.sprite = RelojController.clocks [RelojController.ClockNumber];
			//ClockSpriteRenderer.sprite = RelojController.clocks [0];

			calculo = 0;

			Debug.Log ("Antes de llamar a NuevaOperacion (en una resta)");
			GameController.NuevaOperacion ();

		}
		*/
	}
}