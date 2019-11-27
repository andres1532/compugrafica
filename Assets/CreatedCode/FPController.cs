using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private float velocidad = 5f, acceleracion = 7.5f;
	private float timeJump = 1f, timeSpeed = 0f;
	private bool onAir = false, bfrenar = false;
	public bool baccelerar = false;
	private GameObject variables;
	void Start () {
		variables = GameObject.Find ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		if (!variables.GetComponent<variableContainer> ().getVarPausa ()) {
			mover ();
			jump ();
			accelerar ();
			frenar ();
		}
	}
	void mover(){
		float vertical = Input.GetAxis ("Vertical")*Time.deltaTime*velocidad;
		float horizontal = Input.GetAxis ("Horizontal")*Time.deltaTime*velocidad;

		this.gameObject.transform.Translate (horizontal, 0, vertical);
		}

	void jump(){
		if(Input.GetKeyDown(KeyCode.JoystickButton1) && !onAir && this.gameObject.transform.position.y < 13){
			onAir = true;
		}
		if (onAir) {
			timeJump -= Time.deltaTime;
			if (timeJump > 0f && timeJump < 1f) {
				float salto = Time.deltaTime * velocidad/2;
				this.gameObject.transform.Translate (0, salto, 0);
			} else {
				timeJump = 1f;
				onAir = false;
			}
		}
	}
	public void accelerar(){
		if (baccelerar && timeSpeed < 0.5f) {
			timeSpeed += Time.deltaTime;
			velocidad = 4f*acceleracion * timeSpeed + 5f;
		} else if (timeSpeed >= 0.5f && baccelerar) {
			timeSpeed = 0f;
			baccelerar = false;
			bfrenar = true;
		}
	}
	public void frenar(){
		if (bfrenar && timeSpeed < 1f) {
			timeSpeed += Time.deltaTime;
			velocidad = -2f*acceleracion * timeSpeed + 20f;
		} else if (timeSpeed >= 1f && bfrenar) {
			velocidad = 5f;
			timeSpeed = 0f;
			bfrenar = false;
		}
	} 
}
