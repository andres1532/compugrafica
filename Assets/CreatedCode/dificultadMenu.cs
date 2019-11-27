using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dificultadMenu : Menu {
	
	private string dificultad = "alta", menu = "inicio";
	private float timing = 0f;
	public GameObject iniPane, difiPane, confirPane, tutorialPane;
	private GameObject atuto,btuto,ctuto;
	private Text bajaText, mediaText, altaText;
	private Text inicioText, tutorialText, salirText;
	private Text texto;
	private int paneTuto = 1;
	// Use this for initialization
	void Start () {
		iniPane = GameObject.Find ("inicioElegir");
		difiPane = GameObject.Find ("dificultadElegir");
		difiPane.SetActive (false);
		confirPane = GameObject.Find ("confirmar");
		confirPane.SetActive (false);
		tutorialPane = GameObject.Find ("Tutorial");
		atuto = GameObject.Find ("interfazTuto");
		btuto = GameObject.Find ("movimientoJugadorTuto");
		ctuto = GameObject.Find ("funcionObjetos");
		tutorialPane.SetActive (false);
		base.Start ();
		maxOpcion = 3;
		opcion = 1;
	 	}

	// Update is called once per frame
	void Update () {
		if (menu == "inicio") {
			panelInicio ();
		} else if (menu == "dificultad") {
			panelDificultad ();
		} else if (menu == "confirmar") {
			panelConfirmar ();
		} else if (menu == "tutorial") {
			menuTutorial ();
		}else {
			}		

	}
	void menuDificultad(){
		base.opcionActual ();
		cambiarColor ();
		if (timing <= 0f) {
			if (Input.GetKey (KeyCode.Return) || Input.GetKey (KeyCode.JoystickButton2)) {
				if (opcion == 1) {
					dificultad = "facil";

				} else if (opcion == 2) {
					dificultad = "media";
				} else if (opcion == 3) {
					dificultad = "alta";
					//baja  = reanudar = 1
					//media =  reinicia = 2
					//alta = salir = 3
				}
				timing = 0.1f;
				menu = "confirmar";
				difiPane.SetActive (true);
				confirPane.SetActive (true);

			//variableDificultad ();
			//base.despausar ();
			//this.gameObject.SetActive (false);

		} else if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
			iniPane.SetActive (true);
			opcion = 1;
			menu = "inicio";
			difiPane.SetActive (false);	
			timing = 0.1f;
		}
		}
		else {
			timing -= Time.deltaTime;
		}
	}
	void menuInicio(){
		base.opcionActual ();
		cambiarColor ();
		if (timing <= 0f) {
		if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
			if (opcion == 1) {
				menu = "dificultad";
				difiPane.SetActive (true);
				iniPane.SetActive (false);
			} else if (opcion == 2) {
				menu = "tutorial";
				tutorialPane.SetActive (true);
				iniPane.SetActive (false);
			} else if (opcion == 3) {
				base.salir ();
			}
			timing = 0.1f;
		}
		}
		else {
			timing -= Time.deltaTime;
		}
	}
	void menuTutorial(){
			if (paneTuto == 1) {
				atuto.SetActive (true);
				btuto.SetActive (false);
				ctuto.SetActive (false);
			} else if (paneTuto == 2) {
				atuto.SetActive (false);
				btuto.SetActive (true);
				ctuto.SetActive (false);
			} else if (paneTuto == 3) {
				atuto.SetActive (false);
				btuto.SetActive (false);
				ctuto.SetActive (true);
			}
		if (timing <= 0f) {
			if (paneTuto == 1 && Input.GetKeyDown (KeyCode.JoystickButton2)) {
				paneTuto = 2;
				timing = 0.1f;
			} else if (paneTuto == 2 && Input.GetKeyDown (KeyCode.JoystickButton2)) {
				paneTuto = 3;
				timing = 0.1f;
			} else if (paneTuto == 3 && Input.GetKeyDown (KeyCode.JoystickButton2)) {
				paneTuto = 1;
				iniPane.SetActive (true);
				timing = 0.1f;
				menu = "inicio";
				tutorialPane.SetActive (false);
			} else if (paneTuto == 1 && Input.GetKeyDown (KeyCode.JoystickButton1)) {
				iniPane.SetActive (true);
				timing = 0.1f;
				menu = "inicio";
				tutorialPane.SetActive (false);
			} else if (paneTuto == 2 && Input.GetKeyDown (KeyCode.JoystickButton1)) {
				paneTuto = 1;
				timing = 0.1f;
			} else if (paneTuto == 3 && Input.GetKeyDown (KeyCode.JoystickButton1)) {
				paneTuto = 2;
				timing = 0.1f;
			} else {
			}
		} else {
			timing -= Time.deltaTime;
		}
	}
	void cambiarColor(){
		if (opcion == 1) {
			bajaText.color = Color.red;
			mediaText.color = Color.white;
			altaText.color = Color.white;
		} else if (opcion == 2) {
			bajaText.color = Color.white;
			mediaText.color = Color.red;
			altaText.color = Color.white;
		} else if (opcion == 3) {
			bajaText.color = Color.white;
			mediaText.color = Color.white;
			altaText.color = Color.red;
		} else {
		}
	}
	void variableDificultad(){
		variables.GetComponent<variableContainer> ().activarNiebla ();
		variables.GetComponent<variableContainer> ().inicio = true;
		variables.GetComponent<variableContainer> ().despausar ();
		variables.GetComponent<variableContainer> ().varDificultad = dificultad;
	}
	void panelInicio(){
		bajaText = GameObject.Find ("iniciarText").GetComponent<Text>();
		mediaText = GameObject.Find ("tutorialText").GetComponent<Text>();
		altaText = GameObject.Find ("salirInicioText").GetComponent<Text>();
		base.opcionActual ();
		menuInicio ();
	}
	void panelDificultad(){
		bajaText = GameObject.Find ("facilText").GetComponent<Text>();
		mediaText = GameObject.Find ("normalText").GetComponent<Text>();
		altaText = GameObject.Find ("dificilText").GetComponent<Text>();
		menuDificultad ();
	}
	void panelConfirmar(){
		bajaText = GameObject.Find ("texto").GetComponent<Text>();
		if (dificultad == "facil") {
			//explicacion facil
			bajaText.text = "Sin explosiones, cantidad de huevos 30.";
		} else if (dificultad == "media") {
			//explicacion media
			bajaText.text = "Menor tiempo, sin explosiones, menos ayudas, debes coger los 10 ratones para poder entrar a la meta";
		} else if (dificultad == "alta") {
			//explicacion alta
			bajaText.text = "Con barriles explosivos, menor cantidad de ayudas y debes coger un minimo de 10 ratones para ganar\t";
		} else {
		}
		if (timing <= 0f) {
		if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
			variableDificultad ();
			this.gameObject.SetActive (false);
		} else if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
			menu = "dificultad";
			confirPane.SetActive (false);
			difiPane.SetActive (true);
			timing = 0.1f;
		}
	}
		else {
			timing -= Time.deltaTime;
		}	
	
	}
}
