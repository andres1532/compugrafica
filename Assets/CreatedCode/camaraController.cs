using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraController : MonoBehaviour {

	[SerializeField] private float velocidad = 20f;
	public GameObject fpc;
	private GameObject variables;
	// Use this for initialization
	void Start () {
		variables = GameObject.Find ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		if (!variables.GetComponent<variableContainer> ().getVarPausa ()) {
			rotarPadre ();
			rotarCamara ();
		}
	}
	void rotarCamara(){
		float vertical = Input.GetAxis ("Vertical2") * Time.deltaTime * velocidad;
		this.gameObject.transform.Rotate (vertical, 0, 0);
		float ang = this.gameObject.transform.eulerAngles.x;
		if (ang > 30f && ang < 275f) {
			this.gameObject.transform.Rotate (-vertical, 0, 0);
		}
	}
	void rotarPadre(){
		float horizontal = Input.GetAxis ("Horizontal2")*Time.deltaTime*velocidad;
		fpc.gameObject.transform.Rotate (0, horizontal, 0);
	}
}
