using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variableContainer : MonoBehaviour {
	public string varDificultad = "facil";
	public bool varPausa = true, varMeta = false, varZonaSegura = false, varNieblaActiva = false, varLoose = false, inicio = false;
	public int varPuntos = 0, varHighScore;
	public float varSegundos = 0f, varTimeNiebla = 0f;
	public GameObject fpc, pauseMenu, dificultadMenu, perderMenu, interfaz;
	public GameObject niebla;
	private bool postCarga = false;

	public GameObject huevoLightPrefab, barrilPrefab, huevoTimePrefab,rataPrefab, arbolPrefab, zonaSeguraPrefab ;
	public GameObject huevoLightContainer, barrilesContainer , huevoTimeContainer, rataContainer, arbolContainer, zonaSeguraContainer;
	public LinkedList<GameObject> huevosLight, barriles, huevosTime, ratas, arboles, zonasSeguras;
	private int counterHuevosLight = 0, counterBarriles = 0, counterHuevosTime = 0, counterRatones=0, counterArboles = 0, counterZonasSeguras = 0;
	// Use this for initialization
	void Start () {
		huevosLight = new LinkedList<GameObject> ();
		arboles = new LinkedList<GameObject> ();
		barriles = new LinkedList<GameObject>();
		huevosTime = new LinkedList<GameObject> ();
		ratas = new LinkedList<GameObject> ();
		zonasSeguras = new LinkedList<GameObject> ();
		arrancar (); 

	}

	// Update is called once per frame
	void Update () {
		if (inicio) {
			
		//cargarPostCarga ();
		if((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton9) )&& !varPausa){pausar();}
		if (varDificultad == "alta") {
			instanciarBarril ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			endGame ();
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			fpc.SetActive (false);
			}
			interfaz.SetActive (true);
		}
		if(!varLoose){
			instanciarHuevoLight ();
			instanciarHuevoTiempo ();
			instanciarRatas ();
			if (varDificultad == "alta") {
				instanciarBarril ();
			}
			instanciarZonasSeguras ();
		}
		matarNiebla ();
		// destruirHuevoLight ();
	}
	void cargarPostCarga(){
	}
	public void setVarDificultad(string dificultad){
		varDificultad = dificultad;
	}
	public string getVarDificultad(){
		return varDificultad;
	}
	public bool getVarPausa(){
		return varPausa;
	}
	public bool getVarMeta(){
		return varMeta;
	}
	public bool getVarZonaSegura(){
		return varZonaSegura;
	}
	public bool getVarNieblaActiva(){
		return varNieblaActiva;
	}
	public float getVarTimeNiebla(){
		return varTimeNiebla;
	}
	public int getVarPuntos(){
		return varPuntos;
	}
	public int getVarHighScore(){
		return varHighScore;	
	}
	public void pausar(){
//		niebla.SetActive (false);
		varPausa = true;
		pauseMenu.SetActive (true);
	}
	public void despausar(){
		//niebla.SetActive (true);
		varPausa = false;
		fpc.SetActive (true);
	}
	public void arrancar(){
		dificultadMenu.SetActive (true);
		pauseMenu.SetActive (false);
		perderMenu.SetActive (false);
		fpc.SetActive (false);
		instanciarArboles ();
	}
	public void activarNiebla(){
		niebla.SetActive (true);
	}
	public void endGame(){
		varLoose = true;
		foreach (GameObject  zona in zonasSeguras) {
			Destroy (zona);
		}
		zonasSeguras.Clear ();
		foreach (GameObject  barril in barriles) {
			Destroy (barril);
		}
		barriles.Clear ();
		niebla.SetActive (false);
		fpc.SetActive (false);
		varPausa = true;
		perderMenu.SetActive (true);
	}
	public float getVarSegundos(){
		return varSegundos;
	}
	public void instanciarBarril(){
		while(barriles.Count < 40){
			GameObject nuevo =  Instantiate (barrilPrefab);
			nuevo.name = "barril" + counterBarriles;
			counterBarriles++;
			barriles.AddLast (nuevo);
			nuevo.transform.parent = barrilesContainer.transform;
		}
	}
	public void instanciarArboles(){
		while (arboles.Count < 50) {
			GameObject nuevo = Instantiate (arbolPrefab);
			nuevo.name = "arbol" + counterArboles;
			counterArboles++;
			arboles.AddLast (nuevo);
			nuevo.transform.parent = arbolContainer.transform;
		}
	}
	public void instanciarHuevoLight(){
		int cantidad;
		if (varDificultad == "facil") {
			cantidad = 15;
		} else if (varDificultad == "media") {
			cantidad = 12;
		} else {
			cantidad = 9;
		}
		while (huevosLight.Count < cantidad) {
			GameObject nuevo = Instantiate (huevoLightPrefab);
			nuevo.name = "huevoLight" + counterHuevosLight;
			counterHuevosLight++;
			huevosLight.AddLast (nuevo);
			nuevo.transform.parent = huevoLightContainer.transform;
		}
	}
	public void instanciarHuevoTiempo(){
		int cantidad;
		if (varDificultad == "facil") {
			cantidad = 15;
		} else if (varDificultad == "media") {
			cantidad = 12;
		} else {
			cantidad = 9;
		}
		while (huevosTime.Count < cantidad) {
			GameObject nuevo = Instantiate (huevoTimePrefab);
			nuevo.name = "huevoTime" + counterHuevosTime;
			counterHuevosTime++;
			huevosTime.AddLast (nuevo);
			nuevo.transform.parent = huevoTimeContainer.transform;
		}
	}
	public void instanciarRatas(){
		int cantidad;
		if (varDificultad == "facil") {
			cantidad = 15;
		} else if (varDificultad == "media") {
			cantidad = 12;
		} else {
			cantidad = 9;
		}
		while (ratas.Count < cantidad) {
			GameObject nuevo = Instantiate (rataPrefab);
			nuevo.name = "rata" + counterRatones;
			counterRatones++;
			ratas.AddLast (nuevo);
			nuevo.transform.parent = rataContainer.transform;
		}
	}
	public void instanciarZonasSeguras(){
		int cantidad;
		if (varDificultad == "facil") {
			cantidad = 15;
		} else if (varDificultad == "media") {
			cantidad = 12;
		} else {
			cantidad = 9;
		}
		while (zonasSeguras.Count < cantidad) {
			GameObject nuevo = Instantiate (zonaSeguraPrefab);
			nuevo.name = "zonaSegura" + counterZonasSeguras;
			counterZonasSeguras++;
			zonasSeguras.AddLast (nuevo);
			nuevo.transform.parent = zonaSeguraContainer.transform;
		}
	}
	public void destruirHuevoLight(GameObject destruir){
		GameObject hu = huevosLight.Find (destruir).Value;
		huevosLight.Remove (hu);
		Destroy (hu);
	}
	public void destruirHuevoTime(GameObject destruir){
		GameObject hu = huevosTime.Find (destruir).Value;
		huevosTime.Remove (hu);
		Destroy (hu);
	}
	public void destruirRatas(GameObject destruir){
		GameObject hu = ratas.Find (destruir).Value;
		ratas.Remove (hu);
		Destroy (hu);
	}
	void matarNiebla(){
		if (varNieblaActiva && !seguro()) {
			endGame ();
		}
	}
	public bool seguro(){
		foreach (GameObject zona in zonasSeguras) {
			if (zona.GetComponent<ZonaSegura> ().isInside ()) {
				if (zona.GetComponent<ZonaSegura> ().isInside ()) {
					print ("tr");
				}
			
				return true;
			}
			print ("fa");
		}
		return false;
	}
}
