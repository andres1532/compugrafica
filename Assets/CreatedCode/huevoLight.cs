using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huevoLight : Objetivo {
	private Light flashLight;
	private float secondsCounter = 0f;
	private bool encender = false;
	void Update (){
		if(escalax < 0.001f)
		{
			variables.GetComponent<variableContainer> ().destruirHuevoLight (this.gameObject);
		}
		base.Update();
		if (encender) {
			flashLight = GameObject.Find ("globalLight").GetComponent<Light> ();
			secondsCounter += Time.deltaTime*2;
			if (secondsCounter <= 0.5f) {
				onLight ();
			} else if (secondsCounter > 1f && secondsCounter < 1.5f) {
				onLight ();
			} else if (secondsCounter <= 1f && secondsCounter >= 0.5f) {
				offLight ();
			}
			else {
				offLight ();
				secondsCounter = 0f;
				encender = false;
			}
		}
	}
	void OnCollisionEnter(Collision collision)
	{

		if(primeraColission && collision.gameObject.name == "FPSController")
		{
			base.OnCollisionEnter(collision);
			flashear ();
		}


	}
	private void flashear(){
		encender = true;
		secondsCounter = 0f;
	}
	private void onLight(){
		flashLight.intensity = 1f;
	}
	private void offLight(){
		flashLight.intensity = 0f;
	}
}
