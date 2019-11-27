using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class incrementarTiempo : MonoBehaviour {
	private float secondsCounter;
	private float sec = 0f, min = 0f, hour = 0f;
	public bool pausado = false;
	private GameObject variables;
	// Use this for initialization
	void Start () {
		variables = GameObject.Find ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		if (!variables.GetComponent<variableContainer> ().getVarPausa()) {
			cambiarTiempo ();
		}
	}
	void cambiarTiempo(){
		variables.GetComponent<variableContainer> ().varSegundos += Time.deltaTime;
		secondsCounter = variables.GetComponent<variableContainer>().getVarSegundos();
		sec = Mathf.Floor( secondsCounter % 60f);
		min = Mathf.Floor( secondsCounter/60 % 60f);
		hour = Mathf.Floor (secondsCounter / 3600 % 60f);
	//	min %= 60;
	//	hour %= 60;
		if (secondsCounter < 0) {
			min++;
			hour++;
		}
		string resultadoText = acomodar();
		this.gameObject.GetComponent<Text> ().text = resultadoText;
	}
	public string acomodar(){
		string ssec, smin, shour;
		ssec = agregarCero (sec);
		smin = agregarCero (min);
		shour = agregarCero (hour);
		if (secondsCounter < 0) {
			shour = "-" + shour;
		}
		return shour + ":" + smin + ":" + ssec;

	}
	public string agregarCero(float time){
		if (time < 0f) {
			time *= -1f;
		}
		if (time >= 0f && time < 10f) {
			return "0" + time.ToString ();
		} else {
			return time.ToString ();
		}
	}
	public int getSeconds(){
		return (int)secondsCounter;
	}
}
