using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
	
	protected int opcion =1; //opcion elegida
	protected int maxOpcion; //cantidadDeOpcionesMenu
	protected float bajando = 0f; // paraDarTiempoAlBajar
	protected bool pause; //lee si el juego esta en pausa
	protected GameObject variables; //variablesGlobales
//	protected LinkedList<GameObject> opciones; //recibeLasOpcionesPosilesDelMenu
	// Use this for initialization
	public void Start () {
		variables = GameObject.Find ("GameController");
	}

	// Update is called once per frame
	public void Update () {

	}
	public void reiniciar(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
	public void salir(){
		Application.Quit ();
	}
	public void opcionActual(){
		if (bajando == 0f) {
			if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetAxis ("Vertical") < 0) {
				opcion++;
				bajando = 0.2f;
				if (opcion > maxOpcion) {
					opcion = 1;
				}
			} else if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetAxis("Vertical") > 0) {
				opcion--;
				bajando = 0.2f;
				if (opcion < 1) {
					opcion = maxOpcion;
				}
			}
		} else if (bajando > 0f) {
			bajando -= Time.deltaTime;
		} else {
			bajando = 0f;
		}
	}
	public void cambiarColor(){
//		for (int i = 0; i < opciones.Count; i++) {
//			opciones.Find (i);

//		}

	}
	public void pausar(){
		variables.GetComponent<variableContainer> ().pausar ();
	}
	public void despausar(){
		opcion = 1;
		variables.GetComponent<variableContainer> ().despausar();
		this.gameObject.SetActive (false);
	}
}
