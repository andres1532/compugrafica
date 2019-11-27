using UnityEngine;
using System.Collections;
using System;

public class Barril : SinPosicionDefinida
{
	private Light luzBarril;
	private GameObject fpc;
	private float rangeDie = 12f;
	private float timeDisable = 1f, timerCounter = 0;
	private bool isActive = false;
	// Use this for initialization
    void Start()
    {
			luzBarril = this.gameObject.transform.Find ("Area Light").GetComponent<Light> ();
			base.Start ();
			luzBarril.intensity = 0;
			darVarlor ();
    }

    // Update is called once per frame
    void Update()
    {
		if(!variables.GetComponent<variableContainer>().getVarPausa()){
			autoActive ();
		}
    }
    void activar()
    {
		luzBarril.intensity = 2f;
		luzBarril.color = Color.green;
		isActive = true;
		if (timeDisable <= 0f) {
			desactivar ();
		} else {
			timeDisable -= Time.deltaTime;
		}
		fpc = GameObject.Find("FPSController");
		float distance = Mathf.Sqrt(Mathf.Pow((fpc.transform.position.x - this.gameObject.transform.position.x),2f) + Mathf.Pow((fpc.transform.position.y - this.gameObject.transform.position.y),2f) + Mathf.Pow((fpc.transform.position.z - this.gameObject.transform.position.z),2f));
		if (distance <= rangeDie && !variables.GetComponent<variableContainer>().getVarZonaSegura()) {
			variables.GetComponent<variableContainer> ().endGame ();
		}
    }
    void avisar()
    {

    }
	void darVarlor (){
		timerCounter = UnityEngine.Random.Range(5.0f,10.0f);
	}
    void desactivar()
    {
		luzBarril.intensity = 0f;
		isActive = false;
		timeDisable = 1f;
		darVarlor ();
    }
	void autoActive(){
		if (timerCounter <= 0f || isActive) {
			activar ();
		}else {
			timerCounter -= Time.deltaTime;	
		}
		if (timerCounter > 0f && timerCounter < 1f && !isActive) {
			luzBarril.intensity = 0.5f;
			luzBarril.color = Color.yellow;
		}
	}
}
