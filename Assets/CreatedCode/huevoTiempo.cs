using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huevoTiempo:Objetivo
{
	void Update(){
		if(escalax < 0.001f)
		{
			variables.GetComponent<variableContainer> ().destruirHuevoTime (this.gameObject);
		}
		base.Update ();
	}	// Use this for initialization
	// Update is called once per frame
	void OnCollisionEnter(Collision collision)
	{

		if(primeraColission && collision.gameObject.name == "FPSController")
		{
			base.OnCollisionEnter(collision);
			variables.GetComponent<variableContainer>().varSegundos -= 10f;
		}

	}

}
