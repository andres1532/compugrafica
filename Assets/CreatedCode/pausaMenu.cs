using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pausaMenu : Menu {
	public Text reanudarText;
	public Text reiniciarText, salirText; //salida y reinicio del menu

	// Use this for initialization
	void Start () {
		maxOpcion = 3;
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
//		reanudarText = GameObject.Find ("reanudarText");
//		reiniciarText = GameObject.Find ("reiniciarText");
//		salirText = GameObject.Find ("salirText");

		if (!pause) {
			this.gameObject.SetActive (false);
		}
		pausar ();
		if (pause) {
			menuPausa ();
		}
	}	
	void pausar(){
		base.pausar ();
		pause = true;
	}
	void menuPausa(){
		base.opcionActual ();
		cambiarColor ();
		if (Input.GetKey (KeyCode.Return) || Input.GetKey(KeyCode.JoystickButton2)) {
			if (opcion == 1) {
				despausar ();
			} else if (opcion == 2) {
				base.reiniciar ();
			} else if (opcion == 3) {
				base.salir ();
			}
		}
	}
	void despausar(){
		pause = false;
		base.despausar ();
	}
	void cambiarColor(){
		if (opcion == 1) {
			reanudarText.color = Color.red;
			reiniciarText.color = Color.white;
			salirText.color = Color.white;
		} else if (opcion == 2) {
			reanudarText.color = Color.white;
			reiniciarText.color = Color.red;
			salirText.color = Color.white;
		} else if (opcion == 3) {
			reanudarText.color = Color.white;
			reiniciarText.color = Color.white;

			salirText.color = Color.red;
		} else {
		}
	}
}
