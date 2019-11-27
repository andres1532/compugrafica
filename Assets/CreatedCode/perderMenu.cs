using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class perderMenu : Menu {

	public Text reiniciarText, salirText, highScore, score; //salida y reinicio del menu
	private int vs = 5, vr = 500 , tiempoEsperado = 600, valorMeta = 5000, mouses, vhighScore;
	public bool meta;
	private bool calculado = false;
	// Use this for initialization
	void Start () {
		base.Start();
		maxOpcion = 2;
	}
	// Update is called once per frame
	void Update () {
		looseMenu ();		
	}
	void looseMenu(){
		opcionActual ();
		if (!calculado) {
			cambiarPuntaje ();
			calculado = true;
		}
		cambiarColor ();
		if (Input.GetKey (KeyCode.Return) || Input.GetKey(KeyCode.JoystickButton2)) {
			if (opcion == 1) {
				base.reiniciar ();
			} else if (opcion == 2) {
				base.salir ();
			}
		}
	}

	void cambiarColor(){
		if (opcion == 1) {
			reiniciarText.color = Color.red;
			salirText.color = Color.white;
		} else if (opcion == 2) {
			reiniciarText.color = Color.white;
			salirText.color = Color.red;
		} else {
		}
	}
	void cambiarPuntaje(){
		score.text = "Tu puntaje es: " + obtenerPuntaje ().ToString ();
	}
	int obtenerPuntaje(){
		mouses = variables.GetComponent<variableContainer> ().getVarPuntos ();
		int time = (int)variables.GetComponent<variableContainer>().getVarSegundos();
		int puntajeFinal = vs*(tiempoEsperado - time) + mouses * vr;
		if (variables.GetComponent<variableContainer>().getVarMeta()) {
			puntajeFinal += valorMeta;
		}
		return puntajeFinal;
	}
	void highScoreCompare(){
		if (vhighScore < obtenerPuntaje()) {
			vhighScore = obtenerPuntaje ();
		}
		highScore.text = vhighScore.ToString ();
	}
	void leerGameObjets(){
		
	}

}
