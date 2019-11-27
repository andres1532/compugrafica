using UnityEngine;
using System.Collections;

public class Raton : Objetivo
{
    public GameObject puntajeObject;
	public float speed = 5f, counterGiro = 0f;
	private bool inPared = false;
	void Update(){
		if (!variables.GetComponent<variableContainer> ().getVarPausa()) {
		if(escalax < 0.001f)
		{
			variables.GetComponent<variableContainer> ().destruirRatas (this.gameObject);
		}
		base.Update ();
		mover ();
		}
	}
	void OnCollisionEnter(Collision collision){
		if (primeraColission && collision.gameObject.name == "FPSController") {
			base.OnCollisionEnter (collision);
			variables.GetComponent<variableContainer> ().varPuntos++;
		}
			}
	public void mover(){
		if (!inPared) {
			float desplazamiento = speed * Time.deltaTime;
			float rotacionAleatoria = UnityEngine.Random.Range (0f, 360f);
			while (rotacionAleatoria > 5f && rotacionAleatoria < 355f) {
				rotacionAleatoria = UnityEngine.Random.Range (0f, 360f);
			}
			this.gameObject.transform.Rotate (0, rotacionAleatoria, 0);
			this.gameObject.transform.Translate (0,0,desplazamiento);
			bool inRio = dentroDelRio (this.gameObject.transform.position.x, this.gameObject.transform.position.z);
			bool inMapX = this.gameObject.transform.position.x > 66f && this.gameObject.transform.position.x < 430f;
			bool inMapZ = this.gameObject.transform.position.z > 59f && this.gameObject.transform.position.z < 415f;
			if (inRio || !inMapZ || !inMapX) {
				this.gameObject.transform.Translate (0,0,-desplazamiento);
				inPared = true;
			}
		}
		if (inPared) {
			girar ();
		}
	}
	public void girar(){
		counterGiro += Time.deltaTime;
		if (counterGiro >= 0f && counterGiro <= 1f) {
			float rotar = 180f * Time.deltaTime;
			this.gameObject.transform.Rotate (0, rotar, 0);				
		} else if (counterGiro > 1f && counterGiro < 1.5f) {
			float desplazamiento = speed * Time.deltaTime;
			this.gameObject.transform.Translate (0, 0, desplazamiento);
		} else {
			inPared = false;
			counterGiro = 0f;
		}
	}

}
