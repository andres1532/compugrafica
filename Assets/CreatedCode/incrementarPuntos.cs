using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class incrementarPuntos : MonoBehaviour {
	// Use this for initialization
	private GameObject variables;
	void Start () {
		variables = GameObject.Find ("GameController");
		this.gameObject.GetComponent<Text> ().text = "Ratones: 0";
	}
	
	// Update is called once per frame
	void Update () {
		aumentarPuntaje();
	}
	void aumentarPuntaje(){
		
		this.gameObject.GetComponent<Text> ().text = "Ratones: " + variables.GetComponent<variableContainer> ().getVarPuntos ().ToString();
	}

}
