using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class cambioLuz : MonoBehaviour {
	private Light it;
	private GameObject p1,p2,p3;
	private GameObject variables;
	private float secondsCounter = 0;
//    public GameObject player;
    // Use this for initialization
    void Start () {
		p1 = GameObject.Find ("Ahogado1");
		p2 = GameObject.Find ("Ahogado2");
		p3 = GameObject.Find ("Ahogado3");
		p1.SetActive (false);
		p2.SetActive (false);
		p3.SetActive (false);
		variables = GameObject.Find ("GameController");
		it = this.gameObject.GetComponent<Light>();
		cambioLuzAltura ();
	}

    // Update is called once per frame
    void Update()
    {
		if (!variables.GetComponent<variableContainer> ().getVarPausa ()) {
			cambioLuzAltura ();
		}
    }
	void cambioLuzAltura(){
		if (it.transform.position.y > 13)
		{
			it.color = Color.white;
			if (secondsCounter > 0) {
				secondsCounter -= Time.deltaTime;
			} else if (secondsCounter > 5) {
				secondsCounter = 5;
			}
		}
		else
		{
			it.color = Color.blue;
			secondsCounter += Time.deltaTime;
		}
		activarCaras ();
	}
	void activarCaras(){
		if (secondsCounter > 1f) {
			p1.SetActive (true);	
		} else {
			p1.SetActive (false);
		}
		if (secondsCounter > 3f) {
			p2.SetActive (true);
		} else {
			p2.SetActive (false);
		}
		if (secondsCounter > 5f) {
			p3.SetActive (true);
		} else {
			p3.SetActive (false);
		}
		if (secondsCounter > 7f) {
			variables.GetComponent<variableContainer> ().endGame ();
		}
	}
}
