using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meta : MonoBehaviour {
	public GameObject fpc, winMenu, dificultadMenu, barriles;
	public bool win = false;
	public int cantidadRatones = 0;
	private float rangeWin = 5f;
	private GameObject variables;
	// Use this for initialization
	void Start () {
		variables = GameObject.Find ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		gano ();
	}
	void gano (){
		if (enRango () && getDificultad () == "facil") {
			ganar ();
		}else if(enRango() && cantidadRatones >= 10 && getDificultad()== "media"){
			ganar ();
		}else if(enRango() && cantidadRatones >= 10 && getDificultad() == "alta"){
			ganar ();
		}
	}
	public bool enRango(){
		float distance = Mathf.Sqrt(Mathf.Pow((fpc.transform.position.x - this.gameObject.transform.position.x),2f) + Mathf.Pow((fpc.transform.position.y - this.gameObject.transform.position.y),2f) + Mathf.Pow((fpc.transform.position.z - this.gameObject.transform.position.z),2f));
		if (distance <= rangeWin) {
			return true;
		} else {
			return false;
		}
	}
	public string getDificultad(){
		return variables.GetComponent<variableContainer> ().getVarDificultad();
	}
	public void ganar(){
		variables.GetComponent<variableContainer> ().endGame ();
		variables.GetComponent<variableContainer> ().varMeta = true;
	}
}
