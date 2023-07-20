using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	//variables generales del juego

	private static GameObject MainMenu;
	public static int level;
	public static int vidas;

	public static int hiscore;
	public static int score;
	private static ControlScore Marcador;
	private static GameObject LittleNerd1;
	private static GameObject LittleNerd2;
	private static GameObject LittleNerd3;


	public static int cuentasleft;

	public static int operando1;
	public static int operando2;
	public static bool operacion;//true - suma; false - resta
	public static int resultado;

	public static int status;
	private static int ciclos;

	// -------------------------------------



	//Variables for Nerd and Bully
	private static int NerdInitialX;
	private static int NerdInitialY;
	public static GameObject Nerd;
	public static Transform NerdTransform;
	public static Animator NerdAnimator;
	public static SpriteRenderer NerdSpriteRenderer;
	public static Sprite NerdSprite;

	public static GameObject Nerd2;
	public static Transform NerdTransform2;
	public static Animator NerdAnimator2;

	private static int BullyX;
	private static int BullyY;
	public static GameObject Bully;
	public static Transform BullyTransform;
	public static Animator BullyWalking;
	public static float BullyAceleracion;
	// --------------------------------------



	//Variables for Desk instances
	public static int[,] arrayBoard = new int[8,8];
	private static int i;
	private static int j;
	private static bool added;
	private static int a;
	private static int b;
	//public GameObject Desk;
	public static GameObject[] desks;
	public static GameObject desk;
	public static Transform boardHolder;

	public static GameObject papel;
	public static Transform papelHolder;

	private static int x;
	private static int y;
	private static int pixelX;
	private static int pixelY;
	// ----------------------------------------------



	// ---------------------------------------
	// Variables para controlar el reloj
	private static GameObject Clock;
	private static ClockController RelojController;
	private static SpriteRenderer ClockSpriteRenderer;
	private static Animator ClockAnimator;
	public static int tiempo;

	private static float tiempoInicial;
	private static float tiempoParcial;
	private static float tiempoTotal;

	// --------------------------------------------
	// Variables para los papeles
	private static Sprite[] sheetSprites;
	private static GameObject instanceOperando1;
	private static GameObject instanceOperando2;
	private static GameObject instanceResultado;
	private static GameObject instanceOperacion;
	private static GameObject instanceIgual;

	private static int calculo;
	// -----------------------------------------------
	// Variables para la pizarra
	private static Sprite[] numerosPizarra;
	private static Sprite masPizarra;
	private static Sprite menosPizarra;
	private static Sprite igualPizarra;




	// ----------------------------
	// Variables beam up
	public static GameObject objLoading;
	public static GameObject objComplete;
	public static bool beamupavailable;


	// -------------------------------------------------

	//Variables Debug
	private static int debug1;
	//private static int debug2;

	void Start () {
		//Debug.Log ("GameController.Start");
		cuentasleft = level;

		MainMenu = GameObject.Find ("MainMenu");

		Marcador = GetComponent<ControlScore> ();
		LittleNerd1 = GameObject.Find ("ScoreNerd1");
		LittleNerd2 = GameObject.Find ("ScoreNerd2");
		LittleNerd3 = GameObject.Find ("ScoreNerd3");

		boardHolder = new GameObject ("Board").transform;
		boardHolder.SetParent (GameObject.Find ("Board").transform);

		sheetSprites = Resources.LoadAll<Sprite>("sprite_sheet");
		numerosPizarra = Resources.LoadAll<Sprite>("numeros");
		masPizarra = Resources.Load<Sprite> ("mas");
		menosPizarra = Resources.Load<Sprite> ("menos");
		igualPizarra = Resources.Load<Sprite> ("igual");



		Nerd = GameObject.Find ("Nerd");
		NerdTransform = Nerd.GetComponent<Transform> ();
		NerdAnimator = Nerd.GetComponent<Animator> ();
		NerdSpriteRenderer = Nerd.GetComponent<SpriteRenderer> ();
		NerdSprite = NerdSpriteRenderer.sprite;

		Nerd2 = GameObject.Find ("NerdBeingEaten");
		NerdTransform2 = Nerd2.GetComponent<Transform> ();
		NerdAnimator2 = Nerd2.GetComponent<Animator> ();

		Bully = GameObject.Find ("Bully");
		BullyTransform = Bully.GetComponent<Transform> ();
		BullyWalking = Bully.GetComponent<Animator> ();

		Clock = GameObject.Find ("Clock");
		ClockAnimator = Clock.GetComponent<Animator>();
		//tiempo = CalculaTiempo(level);
		ClockAnimator.enabled = false;
		RelojController = Clock.GetComponent<ClockController> ();


		objLoading = GameObject.Find ("beamuploading");
		objComplete = GameObject.Find ("beamupcomplete");
		beamupavailable = true;

		tiempoParcial = 0f;
		tiempoTotal = 0f;

		hiscore = 0;

		status = 0;
		MenuPrincipal();


	}

	void Update(){
		//Debug.Log ("GameController.Update");
		if (status == 1) {
			tiempoParcial++;
			//tiempoTotal++;
			if (tiempoParcial >= 100) {
				RelojController.ClockAnimator.enabled = false;
				RelojController.ClockNumber++;
				RelojController.ClockImage.sprite = RelojController.clocks[RelojController.ClockNumber];

				tiempoParcial = 0f;

				//if (tiempoTotal >= 1800) {
				if(RelojController.ClockNumber >=8){
					RelojController.ClockAnimator.enabled = true;
					BeingEaten ();
					RelojController.ClockNumber = 0;
					RelojController.ClockImage.sprite = RelojController.clocks[RelojController.ClockNumber];
					tiempoParcial = 0f;
					//tiempoTotal = 0f;
				}
			}
			if (!beamupavailable) {
				objLoading.transform.localScale = new Vector2 (objLoading.transform.localScale.x + 0.0025f, objLoading.transform.localScale.y);
				if (objLoading.transform.localScale.x >= 1) {
					objLoading.SetActive (false);
					objComplete.SetActive (true);
					beamupavailable = true;
				}
			}
		}
	}



	// ----------------------------

	public static void RetrasaReloj(){
		//Debug.Log ("GameController. RetrasaReloj");
		RelojController.ClockAnimator.enabled = false;
		if (RelojController.ClockNumber >= 1) {
			RelojController.ClockNumber --;
			//tiempoTotal -= 200f;
			RelojController.ClockImage.sprite = RelojController.clocks[RelojController.ClockNumber];
			tiempoParcial = 0f;
		} /*else {
			RelojController.ClockNumber = 1;
			tiempoTotal = 0f;
		}*/

	}



	// ---------------------------

	public static void MenuPrincipal (){
		Debug.Log ("GameController. MenuPrincipal");

		status = 0;
		ParaNerd ();
		ParaBully ();

		PasarEscoba("todas");
		LimpiaBoard ();
		MainMenu.SetActive (true);
		BullyAceleracion = 0.75f;
		if (score > hiscore) {
			hiscore = score;
			Marcador.ActualizaHiScore ();
		}
		Debug.Log (status);
	}


	// -------------------------


	public static void InicializaNerd(){
		//Debug.Log ("GameController. InicializaNerd");
		Nerd.SetActive (true);
		NerdAnimator.enabled = true;
		NerdSpriteRenderer.sprite = NerdSprite;
		NerdInitialX = -56;
		NerdInitialY = -56;
		NerdTransform.localPosition = new Vector3 (NerdInitialX, NerdInitialY, 0);
		NerdTransform.localScale = new Vector3 (1, 1, 0);

		NerdTransform2.localPosition = new Vector3 (-200, -56, 0);
		NerdAnimator2.enabled = false;
	}

	// ------------------------------------

	public static void InicializaBully(){
		//Debug.Log ("GameController. InicializaBully");
		Bully.SetActive (true);
		BullyX = 56;
		BullyY = 56;
		BullyTransform.localPosition = new Vector2 (BullyX, BullyY);
		BullyWalking.enabled = true;
		//BullyAceleracion = 0.75f;
	}

	// -------------------------------------
	public static void ParaNerd(){
		//Debug.Log ("GameController. InicializaNerd");

		NerdSpriteRenderer.sprite = NerdSprite;
		NerdInitialX = -56;
		NerdInitialY = -56;
		NerdTransform.localPosition = new Vector3 (NerdInitialX, NerdInitialY, 0);
		NerdTransform.localScale = new Vector3 (1, 1, 0);

		NerdTransform2.localPosition = new Vector3 (-200, -56, 0);
		NerdAnimator2.enabled = false;
		Nerd.SetActive (false);
		NerdAnimator.enabled = false;
	}

	// ------------------------------------

	public static void ParaBully(){
		//Debug.Log ("GameController. InicializaBully");
		BullyMovement.currentX = 56;
		BullyMovement.currentY = 56;
		BullyX = 56;
		BullyY = 56;
		BullyTransform.localPosition = new Vector2 (BullyX, BullyY);
		Bully.SetActive (false);
		BullyWalking.enabled = false;
		//BullyAceleracion = 0.75f;
	}


	// ------------------------------------


	public static void PreInicio(){
		Debug.Log ("GameController. PreInicio");
		ciclos = 0;

		level = 1;
		vidas = 3;
		score = 0;

		MainMenu.SetActive (false);

		LittleNerd1.SetActive (true);
		LittleNerd2.SetActive (true);
		LittleNerd3.SetActive (true);


		InicializaBully ();
		InicializaNerd ();
		tiempo = 8;
		//RelojController.IniciaReloj ();
		//tiempo = CalculaTiempo(level);

		objComplete.SetActive (true);
		objLoading.SetActive (false);


		Marcador.ActualizaScore ();
		Inicio ();
	}
	// ----------------------------------------------
	// Esta funcion se llama para iniciar el tablero.
	// Se llama al principio y cada vez que el Nerd
	// es comido y no es el final del juego.
	// ----------------------------------------------
	public static void Inicio(){
		Debug.Log ("GameController. Inicio");

		if (ciclos == 5) {
			incrementaNivel ();
			ciclos = 0;
		} else {
			ciclos ++;
		}
		calculo = 0;

		//Board
		IniciaBoard();
		status = 1; //game
		ClockAnimator.enabled = false;
		//RelojController.IniciaReloj ();

	}

	// -----------------------------------
	// Funcion que devuelve el tiempo que dura el nivel pasado por parametro
	// ----------------------------------------
	private static int CalculaTiempo(int level){
		//Debug.Log ("GameController. CalculaTiempo");
		switch (level) {
		case 1:
			return 8;
		default:
			return 8;
		}
	}

	// ----------------------------------------
	// Funcion para poner las cosas mas dificiles level by level
	// ------------------------------------------
	public static void incrementaNivel(){
		//Debug.Log ("GameController. incrementaNivel");
		//BullyAceleracion = BullyAceleracion + ((float)level/6f);
		BullyAceleracion = BullyAceleracion + 0.25f;
		level++;
		//Debug.Log ("Nivel incrementado " + level + " Acel=" + BullyAceleracion);
	}

	// ------------------------------------------
	// En esta funcion tiene que programarse todo lo que tenga que ocurrir
	// cuando el Nerd es comido.
	// ---------------------------------------------------------------
	public static void BeingEaten(){
		//RelojController.ParaReloj ();
		Debug.Log ("GameController. BeingEaten");
		status = 2;
		BullyWalking.enabled = false;

		Nerd2.SetActive (true);
		NerdTransform2.localPosition = new Vector2(Nerd.transform.localPosition.x, Nerd.transform.localPosition.y);
		NerdTransform.localPosition = new Vector2 (-200f, Nerd.transform.localPosition.y);
		NerdAnimator2.enabled = true;
		NerdAnimator2.Play ("New_BeingEaten", 0, 0f);



	}

	// ------------------------------------------
	// Funcion que es llamada cuando el Nerd es comido.
	// Comprueba las vidas restantes, actualiza scores si
	// es pertinente, y manda el flujo del juego bien de 
	// nuevo al tablero, o bien al menu principal.
	// -------------------------------------------------
	public static void Contabiliza(){
		status = 0;
		Debug.Log ("GameController. Contabiliza");
		vidas--;

		if (vidas == 0) {
			LittleNerd1.SetActive (false);
			//RelojController.ParaReloj ();
			NerdAnimator.enabled = false;
			NerdAnimator2.enabled = false;
			Nerd.SetActive (false);
			Nerd2.SetActive (false);
			Bully.SetActive (false);
			//LimpiaBoard ();
			RelojController.ClockNumber = 0;
			RelojController.ClockImage.sprite = RelojController.clocks [RelojController.ClockNumber];
			tiempoParcial = 0f;
			MenuPrincipal ();

		} else {
			
			LimpiaBoard ();
			//Destroy (Bully);
			BullyMovement.currentX = 56;
			BullyMovement.currentY = 56;
			PasarEscoba ("todas");
			ciclos = 0;


			if (vidas == 2) {
				LittleNerd3.SetActive (false);
			} else if (vidas == 1) {
				LittleNerd2.SetActive (false);
			}

			objLoading.SetActive (false);
			objComplete.SetActive (true);
			beamupavailable = true;

			Inicio ();
			InicializaBully ();
			InicializaNerd ();
			RelojController.ClockNumber = 0;
			RelojController.ClockImage.sprite = RelojController.clocks [RelojController.ClockNumber];
			tiempoParcial = 0f;


		}


	}

	// ---------------------------------------------------
	// Funcion para eliminar hojas de calculo
	// Entrada: nombre de la hoja - se elemina esa hoja
	//          todas - se eleminan todas las hojas restantes en el tablero
	// ---------------------------------------------------
	public static void PasarEscoba (string nombreHoja){
		//Debug.Log ("GameController. PasarEscoba");
		GameObject hoja;
		int posX;
		int posY;



		if (nombreHoja == "todas"){
			
			// Volver a poner un 2 en el arrayBoard y destruir el objeto

			//hoja operando1
			if (instanceOperando1 != null) {
				posX = instanceOperando1.GetComponent<hojaxy> ().hojax;
				posY = instanceOperando1.GetComponent<hojaxy> ().hojay;
				arrayBoard [posY, posX] = 2;
				Destroy (instanceOperando1);
			}
			//hoja operando2
			if (instanceOperando2 != null) {
				posX = instanceOperando2.GetComponent<hojaxy> ().hojax;
				posY = instanceOperando2.GetComponent<hojaxy> ().hojay;
				arrayBoard [posY, posX] = 2;
				Destroy (instanceOperando2);
			}
			//hoja resultado
			if (instanceResultado != null) {
				posX = instanceResultado.GetComponent<hojaxy> ().hojax;
				posY = instanceResultado.GetComponent<hojaxy> ().hojay;
				arrayBoard [posY, posX] = 2;
				Destroy (instanceResultado);
			}
			//hoja operacion
			if (instanceOperacion != null) {
				posX = instanceOperacion.GetComponent<hojaxy> ().hojax;
				posY = instanceOperacion.GetComponent<hojaxy> ().hojay;
				arrayBoard [posY, posX] = 2;
				Destroy (instanceOperacion);
			}
			//hoja igual
			if (instanceIgual != null) {
				posX = instanceIgual.GetComponent<hojaxy> ().hojax;
				posY = instanceIgual.GetComponent<hojaxy> ().hojay;
				arrayBoard [posY, posX] = 2;
				Destroy (instanceIgual);
			}
			//NerdCollisions.calculo = 0;
			calculo = 0;
		}else{
			hoja = GameObject.Find(nombreHoja);
			posX = hoja.GetComponent<hojaxy> ().hojax;
			posY = hoja.GetComponent<hojaxy> ().hojay;
			arrayBoard [y, x] = 2;
			Destroy (hoja);
		}

	}

	// ---------------------------------------------------
	// Funcion que muestra los puntos que hemos conseguido al pillar un papel
	// Es llamada desde la clase NerdCollisions
	// -------------------------------------------------------
	public static void AnimacionPuntos(string nombreHoja){
		//Debug.Log ("GameController. AnimacionPuntos");
		// Invocar una instancia del objeto de puntos y colocarlo en el mismo sitio donde estaba la hoja
		GameObject hoja;
		GameObject objPuntos;
		int posX;
		int posY;

		hoja = GameObject.Find(nombreHoja);

		posX = (int)hoja.transform.localPosition.x;
		posY = (int)hoja.transform.localPosition.y;

		 

		if (calculo == 4) {
			objPuntos = Instantiate (GameObject.Find ("points200"), new Vector3 (posX, posY, 2f), Quaternion.identity) as GameObject;
			objPuntos.GetComponent<Animator> ().enabled = true;
			objPuntos.GetComponent<Animator> ().Play ("200", 0, 0);
			score += 200;
			RetrasaReloj ();
		} else {
			objPuntos = Instantiate (GameObject.Find ("points100"), new Vector3 (posX, posY, 2f), Quaternion.identity) as GameObject;
			objPuntos.GetComponent<Animator> ().enabled = true;
			objPuntos.GetComponent<Animator> ().Play ("100", 0, 0);
			score += 100;
		}
		RetrasaReloj ();

	}


	// ---------------------------------------------------
	// Funcion para inicializar el tablero en terminos de 
	// instanciamiento de nuevos pupitres, asi como de 
	// seteo del array de posiciones (el cual hay que tener 
	// en cuenta para la creacion de las hojas de calculo.
	// ---------------------------------------------------
	public static void IniciaBoard () {
		//Debug.Log ("GameController. IniciaBoard");
		int contador;
		int i;
		//boardHolder = new GameObject ("Board").transform;
		//boardHolder.SetParent (GameObject.Find ("Board").transform);



		//Rellenar el board con empty
		for (i=0; i < 8; i++){
			for (j=0; j < 8; j++){
				arrayBoard[j,i] = 0;
			}
		}

		//arrayBoard[0,7] = 102; //Nerd
		//arrayBoard[7,0] = 101; //Bully

		for (i = 0; i < 14; i++) { //bucle 14 veces para 14 pupitres
			added = false;
			while (!added) {
				a = Random.Range (1, 7);
				b = Random.Range (1, 7);
				//Debug.Log ("i="+i+"a=" + a);
				//Debug.Log ("i="+i+"b=" + b);
				if (arrayBoard [a, b] == 0) {

					arrayBoard [a, b] = 1;
					pospixels (a, b);

					GameObject instance = Instantiate(GameObject.Find("Desk"),new Vector3(pixelX, pixelY, 0f), Quaternion.identity) as GameObject;
					instance.gameObject.tag = "DeskCopy";
					instance.transform.SetParent (boardHolder);
					instance.SetActive (true);

					added = true;
				}
			}
		}


		// Ahora relleno el resto de la matriz con los numeros que le corresponda
		// 0 - no esta todavia calculado, 1 - Hay pupitre (relleno en el bucle anterior) o no es accesible, 2 - accesible, >2, calculando

		// EXPLICACION DEL ALGORITMO -----------------------------------------------------------
		// Rellenado de la matriz con numeros que me indiquen mas tarde si una determinada
		// posicion es accesible. El resultado final sera un tablero con UNOS Y DOSES. 1 - No accesible, 2 - accesible
		// Al principio tenemos la matriz con CEROS y UNOS. Cero, donde no se ha calculado aun si es o no accesible.
		// 1, para las posiciones donde se han creado aleatoriamente los pupitres (es decir, que son posiciones no accesibles)
		// Primero se rellena lo que es accesible por antonomasia, es decir el perimetro, donde nunca habra pupitres
		// Despues el segundo perimetro, donde si no hay pupitre (1), escribimos un 2, ya que siempre va a estar pegado al
		// perimetro exterior, es decir, siempre sera accesible.
		// Luego queda recorrer varias veces el cuadro mas interior, compuesto por 4 filas y 4 columnas. 
		// Por cada posicion que no contiene un 1 miramos alrededor
		// Si alrededor solo hay UNOS, escribimos un 1. Si hay algun 2, escribimos un 2. 
		// Si hay otro numero, escribimos el numero de veces que hemos hecho toda esta operacion (contador), empezando en 3.
		// El numero escrito en esta posicion ira cambiando hasta que se haya convertido en un 2, o en un 1, o hasta que el bucle 
		// de veces haya llegado a 10 (numero suficiente y mas que de sobra para delimitar todos los numeros en una cuadricula de 4x4)
		// En tal caso se escribe un 1 en esa posicion.
		// De esta manera tendremos finalmente el tablero preparado para ser consultado en cualquier momento y saber si 
		// una determinada posicion es o no accesible.
		// ------------------------------------------------------------------------------------------


		// Llenar primer perímetro con DOSES
		b = 0;
		for (a = 0; a < 8; a++) { //fila superior
			arrayBoard [a, b] = 2;
		}
		b = 7;
		for (a = 0; a < 8; a++) { //fila inferior
			arrayBoard [a, b] = 2;
		}
		a = 0; 
		for (b = 1; b < 7; b++) { //columna izquierda
			arrayBoard [a, b] = 2;
		}
		a = 7;
		for (b = 0; b < 7; b++) { //columna derecha
			arrayBoard [a, b] = 2;
		}


		// Llenar segundo perímetro con DOSES. Si es cero, lo convierto en 2
		b = 1;
		for (a = 1; a < 7; a++) { //segunda fila superior
			if (arrayBoard[a,b] == 0) arrayBoard [a, b] = 2;
		}
		b = 6;
		for (a = 1; a < 7; a++) { //segunda fila empezando por abajo
			if (arrayBoard[a,b] == 0) arrayBoard [a, b] = 2;
		}
		a = 1;
		for (b = 2; b < 6; b++) { //segunda col empezando por la izq
			if (arrayBoard[a,b] == 0) arrayBoard [a, b] = 2;
		}
		a = 6;
		for (b = 2; b < 6; b++) { //segunda col empezando por la dere
			if (arrayBoard[a,b] == 0) arrayBoard [a, b] = 2;
		}

		// Ahora se recorre el recuadro interior 7 veces
		a = 2; //columna
		b = 2; //fila
		contador = 3;
		while (contador < 10) {
			for (b = 2; b < 6; b++) {
				for (a = 2; a < 6; a++) {
					if (arrayBoard [a, b] < 1 || arrayBoard [a, b] > 2) {
						if (arrayBoard [a, b] == 9) {
							arrayBoard [a, b] = 1;
						} else {

							if (arrayBoard [a, b - 1] == 2 || arrayBoard [a + 1, b] == 2 || arrayBoard [a, b + 1] == 2 || arrayBoard [a - 1, b] == 2) {
								arrayBoard [a, b] = 2;
							} else {
								if (arrayBoard [a, b - 1] == 1 && arrayBoard [a + 1, b] == 1 && arrayBoard [a, b + 1] == 1 && arrayBoard [a - 1, b] == 1){
									arrayBoard[a,b] = 1;
								} else {
									arrayBoard [a, b] = contador;
								}
							}
						}
					}
				}
			}
			contador++;
		}


		NuevaOperacion ();
		RetrasaReloj ();

	}

	// -----------------------------------------------------
	// Funcion para crear las 5 hojas de calculo
	// -----------------------------------------------------
	 

	public static void NuevaOperacion(){
		
		//Debug.Log ("GameController. NuevaOperacion");

		// Calculo de la operacion. Se alimentan las variables de la operacion.
		CalculaOperacion(out operacion,out operando1,out operando2,out resultado);


		// seleccion de los papeles para representar esa operacion




		// Creamos el operando1 //////////////////////////////////////
		PosicionPapel ();
		pospixels (y, x);

		instanceOperando1 = Instantiate(GameObject.Find("Paper"),new Vector3(pixelX, pixelY, 0f), Quaternion.identity) as GameObject;

		//instanceOperando1.gameObject.tag = "PaperCopy_operando1";
		instanceOperando1.gameObject.name = "PaperCopy_operando1";
		instanceOperando1.transform.SetParent (boardHolder);
		instanceOperando1.SetActive (true);

		instanceOperando1.GetComponent<hojaxy> ().hojax = x;
		instanceOperando1.GetComponent<hojaxy> ().hojay = y;

		//Debug.Log ("hojax=" + instanceOperando1.GetComponent<hojaxy> ().hojax);
		//Debug.Log ("hojay=" + instanceOperando1.GetComponent<hojaxy> ().hojay);

		//sheetop1SpriteRenderer = instanceOperando1.GetComponent<SpriteRenderer> ();
		//sheetop1SpriteRenderer.sprite = sheetSprites[operando1 + 2];
		//sheetop1SpriteRenderer.sortingOrder = 1;

		instanceOperando1.GetComponent<SpriteRenderer> ().sprite = sheetSprites[operando1 + 2];
		instanceOperando1.GetComponent<SpriteRenderer> ().sortingOrder = 1;

		// Se pinta en la pizarra
		GameObject.Find("pizarra_op1").GetComponent<SpriteRenderer>().sprite = numerosPizarra[operando1 - 1];




		// Creamos la hoja de la operacion //////////////////////////////////
		PosicionPapel ();
		pospixels (y, x);

		instanceOperacion = Instantiate(GameObject.Find("Paper"),new Vector3(pixelX, pixelY, 0f), Quaternion.identity) as GameObject;

		instanceOperacion.gameObject.name = "PaperCopy_operacion";
		instanceOperacion.transform.SetParent (boardHolder);
		instanceOperacion.SetActive (true);

		//sheetopSpriteRenderer = instanceOperacion.GetComponent<SpriteRenderer> ();
		//sheetopSpriteRenderer.sprite = operacion ? sheetSprites[1] : sheetSprites[2];
		//sheetopSpriteRenderer.sortingOrder = 1;

		instanceOperacion.GetComponent<SpriteRenderer> ().sprite = operacion ? sheetSprites[1] : sheetSprites[2];
		instanceOperacion.GetComponent<SpriteRenderer> ().sortingOrder = 1;

		// Se pinta en la pizarra
		GameObject.Find("pizarra_signo").GetComponent<SpriteRenderer>().sprite = operacion ? masPizarra : menosPizarra;




		// Creamos la hoja del operando2 ///////////////////////////////7
		PosicionPapel ();
		pospixels (y, x);

		instanceOperando2 = Instantiate(GameObject.Find("Paper"),new Vector3(pixelX, pixelY, 0f), Quaternion.identity) as GameObject;

		instanceOperando2.gameObject.name = "PaperCopy_operando2";
		instanceOperando2.transform.SetParent (boardHolder);
		instanceOperando2.SetActive (true);

		//sheetop2SpriteRenderer = instanceOperando2.GetComponent<SpriteRenderer> ();
		//sheetop2SpriteRenderer.sprite = sheetSprites[operando2 + 2];
		//sheetop2SpriteRenderer.sortingOrder = 1;

		instanceOperando2.GetComponent<SpriteRenderer> ().sprite = sheetSprites[operando2 + 2];
		instanceOperando2.GetComponent<SpriteRenderer> ().sortingOrder = 1;

		// Se pinta en la pizarra
		GameObject.Find("pizarra_op2").GetComponent<SpriteRenderer>().sprite = numerosPizarra[operando2 - 1];





		// Creamos la hoja del resultado ///////////////////////////////////
		PosicionPapel ();
		pospixels (y, x);

		instanceResultado = Instantiate(GameObject.Find("Paper"),new Vector3(pixelX, pixelY, 0f), Quaternion.identity) as GameObject;

		instanceResultado.gameObject.name = "PaperCopy_resultado";
		instanceResultado.transform.SetParent (boardHolder);
		instanceResultado.SetActive (true);

		//sheetresSpriteRenderer = instanceResultado.GetComponent<SpriteRenderer> ();
		//sheetresSpriteRenderer.sprite = sheetSprites[resultado + 2];
		//sheetresSpriteRenderer.sortingOrder = 1;

		instanceResultado.GetComponent<SpriteRenderer> ().sprite = sheetSprites[resultado + 2];
		instanceResultado.GetComponent<SpriteRenderer> ().sortingOrder = 1;

		// Se pinta en la pizarra
		GameObject.Find("pizarra_res").GetComponent<SpriteRenderer>().sprite = numerosPizarra[resultado - 1];





		// Creamos la hoja del signo de igual /////////////////////////////////
		PosicionPapel ();
		pospixels (y, x);

		instanceIgual = Instantiate(GameObject.Find("Paper"),new Vector3(pixelX, pixelY, 0f), Quaternion.identity) as GameObject;

		instanceIgual.gameObject.name = "PaperCopy_igual";
		instanceIgual.transform.SetParent (boardHolder);
		instanceIgual.SetActive (true);

		//sheetigSpriteRenderer = instanceIgual.GetComponent<SpriteRenderer> ();
		//sheetigSpriteRenderer.sprite = sheetSprites[0];
		//sheetigSpriteRenderer.sortingOrder = 1;

		instanceIgual.GetComponent<SpriteRenderer> ().sprite = sheetSprites[0];
		instanceIgual.GetComponent<SpriteRenderer> ().sortingOrder = 1;

		// Se pinta en la pizarra
		GameObject.Find("pizarra_igual").GetComponent<SpriteRenderer>().sprite = igualPizarra;




	}


	public static void CambiaPizarra(bool valor){
		//Debug.Log ("GameController. CambiaPizarra");
		if (valor) {
			GameObject.Find("pizarra_op1").GetComponent<SpriteRenderer>().sprite = numerosPizarra[operando2 - 1];
			GameObject.Find("pizarra_op2").GetComponent<SpriteRenderer>().sprite = numerosPizarra[operando1 - 1];
		} else {
			GameObject.Find("pizarra_op2").GetComponent<SpriteRenderer>().sprite = numerosPizarra[resultado - 1];
			GameObject.Find("pizarra_res").GetComponent<SpriteRenderer>().sprite = numerosPizarra[operando2 - 1];
		}
	}





	// ------------------------------------------------------
	// Funcion que devuelve una posicion aleatoria valida para poner un papel
	// ------------------------------------------------------
	private static KeyValuePair<int, int> PosicionPapel(){
		//Debug.Log ("GameController. PosicionPapel");
		bool noOK;
		noOK = false;
		while (!noOK) {
			x = Random.Range (1, 7);
			y = Random.Range (1, 7);
			if (arrayBoard [y, x] == 2) {
				arrayBoard [y, x] = 3;
				noOK = true;
			}
		}
		return new KeyValuePair<int,int>(x, y);
	}

	// ------------------------------------------------------
	// Funcion que hace lo mismo pero sin actualizar el array
	// ------------------------------------------------------
	public static KeyValuePair<int, int> PosicionValida(){
		//Debug.Log ("GameController. PosicionValida");
		bool noOK;
		noOK = false;
		while (!noOK) {
			x = Random.Range (1, 7);
			y = Random.Range (1, 7);
			if (arrayBoard [y, x] == 2) {
				noOK = true;
			}
		}
		return new KeyValuePair<int,int>(x, y);
	}

	// ------------------------------------------------------
	// Funcion que devuelve una operacion valida
	// Salida: Suma true or false, operando1, operando2, resultado
	// -----------------------------------------------------
	private static void CalculaOperacion (out bool operacion, out int operando1, out int operando2, out int resultado){
		//Debug.Log ("GameController. CalculaOperacion");
		//vars auxiliares
		float azarTipoOperacion;
		float resultadoFloat;
		float operando1Float;

		//Decidir si la operacion que vamos a devolver es una suma o una resta
		azarTipoOperacion = Random.Range(1,3);
		operacion = azarTipoOperacion < 1.5 ? true : false;
		//Debug.Log (azarTipoOperacion);

		if (operacion){ //ES SUMA
			resultadoFloat = Random.Range (2,99);
			resultado = (int)resultadoFloat;
			operando1Float = Random.Range(1,resultado);
			operando1 = (int)operando1Float;
			operando2 = resultado - operando1;
		}else{ //Es resta
			resultadoFloat = Random.Range (1,98);
			resultado = (int)resultadoFloat;
			operando1Float = Random.Range(resultado+1, 99);
			operando1 = (int)operando1Float;
			operando2 = operando1 - resultado;
		}

	}


	//------------------------------------------------------
	// Funcion que calcula el valor de las coordenadas en pixeles
	// Entrada: coordenadas X e Y del tablero.
	// Salida: coordenadas en pixels exactos para dibujar tanto
	// los pupitres como las hojas de calculo
	// ----------------------------------------------------
	public static KeyValuePair<int, int> pospixels(int coordX, int coordY){
		//Debug.Log ("GameController. pospixels");
		//int pixelX;
		//int pixelY;

		switch (coordX) {
		case 0:
			pixelX = -96;
			break;
		case 1:
			pixelX = -80;
			break;
		case 2:
			pixelX = -64;
			break;
		case 3:
			pixelX = -48;
			break;
		case 4:
			pixelX = -32;
			break;
		case 5:
			pixelX = -16;
			break;
		case 6:
			pixelX = 0;
			break;
		case 7:
			pixelX = 16;
			break;
		default:
			pixelX = -96;
			break;
		}

		switch (coordY) {
		case 0:
			pixelY = 56;
			break;
		case 1:
			pixelY = 40;
			break;
		case 2:
			pixelY = 24;
			break;
		case 3:
			pixelY = 8;
			break;
		case 4:
			pixelY = -8;
			break;
		case 5:
			pixelY = -24;
			break;
		case 6:
			pixelY = -40;
			break;
		case 7:
			pixelY = -56;
			break;
		default:
			pixelY = 56;
			break;
		}

		return new KeyValuePair<int,int>(pixelX, pixelY);
	}
	

	// --------------------------------------
	// Funcion para limpiar el tablero de pupitres
	// Es llamada tanto al principio como cada vez
	// que el Nerd es comido (salvo si no le quedan vidas).
	// ---------------------------------------------- 
	public static void LimpiaBoard(){
		//Debug.Log ("GameController. LimpiaBoard");
		GameObject[] allObjects = GameObject.FindGameObjectsWithTag("DeskCopy");
		foreach(GameObject obj in allObjects) {
			Destroy(obj);
		}
	}


	// ----------------------------------------
	// Funcion que devuelve cual de las 4 esquinas 
	// es la mas cercana al Nerd. 
	// 0-Top left, 1-Top right, 2-Bottom right, 3-Bottom left
	// -------------------------------------------------
	public static int ClosestCorner(){
		//Debug.Log ("GameController. ClosestCorner");
		if (NerdTransform.localPosition.x < 0) {
			if (NerdTransform.localPosition.y > 0) {
				return 0;
			} else {
				return 3;
			}
		} else {
			if (NerdTransform.localPosition.y > 0) {
				return 1;
			} else {
				return 2;
			}
		}
	}


	public static void ColisionHoja(string nombre){

		//Debug.Log ("GameController. ColisionHoja");


		if (nombre == "PaperCopy_operando1") {

			if (calculo == 0) {
				AnimacionPuntos ("PaperCopy_operando1");
				//Marcador.ActualizaScore ();
				PasarEscoba ("PaperCopy_operando1");
				calculo = 1;
			} else if (calculo == 2 && operacion) {
				AnimacionPuntos ("PaperCopy_operando1");
				PasarEscoba ("PaperCopy_operando1");
				calculo = 3;
			}
		}else if(nombre == "PaperCopy_operando2"){
			if (calculo == 0 && operacion) {
				AnimacionPuntos ("PaperCopy_operando2");
				PasarEscoba ("PaperCopy_operando2");
				CambiaPizarra (true);
				calculo = 1;
			} else if (calculo == 2) {
				AnimacionPuntos ("PaperCopy_operando2");
				PasarEscoba ("PaperCopy_operando2");
				calculo = 3;
			}else if (calculo == 4 && !operacion) {
				AnimacionPuntos ("PaperCopy_operando2");
				PasarEscoba ("PaperCopy_operando2");
				Clock = GameObject.Find ("Clock");
				//RelojController = Clock.GetComponent<ClockController> ();
				ClockSpriteRenderer = Clock.GetComponent<SpriteRenderer>();
				if (RelojController.ClockNumber >= 2) {
					RelojController.ClockNumber -= 2;
					//tiempo += 2;
					RelojController.veces -= 2;
				} else if (RelojController.ClockNumber == 1) {
					RelojController.ClockNumber=0;
					//tiempo ++;
					RelojController.veces = 1;
				}
				if(RelojController.ClockNumber>=0) ClockSpriteRenderer.sprite = RelojController.clocks [RelojController.ClockNumber];
				calculo = 0;

				LimpiaBoard();
				Inicio();
			}
		}else if(nombre == "PaperCopy_operacion"){
			if (calculo == 1) {
				AnimacionPuntos ("PaperCopy_operacion");
				PasarEscoba ("PaperCopy_operacion");
				calculo = 2;
			}
		}else if(nombre == "PaperCopy_resultado"){
			if (calculo == 2 && !operacion) {
				AnimacionPuntos ("PaperCopy_resultado");
				PasarEscoba ("PaperCopy_resultado");
				calculo = 3;
				CambiaPizarra (false);
			} else if (calculo == 4) {
				AnimacionPuntos ("PaperCopy_resultado");
				PasarEscoba ("PaperCopy_resultado");
				Clock = GameObject.Find ("Clock");
				RelojController = Clock.GetComponent<ClockController> ();
				ClockSpriteRenderer = Clock.GetComponent<SpriteRenderer> ();
				if (RelojController.ClockNumber >= 2) {
					RelojController.ClockNumber -= 2;
					//tiempo += 2;
					RelojController.veces -= 2;
				} else if (RelojController.ClockNumber == 1) {
					RelojController.ClockNumber = 0;
					//tiempo++;
					RelojController.veces = 1;
				}
				if (RelojController.ClockNumber >= 0)
					ClockSpriteRenderer.sprite = RelojController.clocks [RelojController.ClockNumber];
				calculo = 0;

				LimpiaBoard();
				Inicio();
			}
		}else if(nombre == "PaperCopy_igual"){
			if (calculo == 3) {
				AnimacionPuntos ("PaperCopy_igual");
				PasarEscoba ("PaperCopy_igual");

				calculo = 4;
			}
		}
		Marcador.ActualizaScore ();
	}
}
