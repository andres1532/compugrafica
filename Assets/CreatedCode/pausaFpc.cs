using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausaFpc : MonoBehaviour {
	// Use this for initialization
	public bool loose = false;
	private bool pausa;
	private GameObject variables;
	void Start () {
		variables = GameObject.Find ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		pausa = variables.GetComponent<variableContainer> ().getVarPausa();
		if ((Input.GetKeyDown (KeyCode.P) || Input.GetKey(KeyCode.JoystickButton7)) && !loose) {
			pausa = true;
			variables.GetComponent<variableContainer> ().pausar ();

		}
	}
}
