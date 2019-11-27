using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class niebla : MonoBehaviour {
	[SerializeField]private float timeCounter, activeTime = 5f;
	private Light luz;
	private Text timerNiebla;
	private GameObject variables;
	// Use this for initialization
	void Start () {
		timerNiebla = this.gameObject.GetComponent<Text> ();
		luz = GameObject.Find ("globalLight").GetComponent<Light> ();
		variables = GameObject.Find ("GameController");
		darTime ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!variables.GetComponent<variableContainer> ().getVarPausa ()) {
			contar ();
		}

	}
	void darTime (){
		timeCounter = UnityEngine.Random.Range (30f, 45f);
		timerNiebla.text = convertirFormato(timeCounter);
	}
	void contar(){
		if (timeCounter > 0f) {
			timeCounter -= Time.deltaTime;
			variables.GetComponent<variableContainer> ().varTimeNiebla = timeCounter;
			timerNiebla.text = convertirFormato(timeCounter);
			timerNiebla.color = Color.white;
		} else if (timeCounter <= 0f && activeTime > 0f) {
			luz.color = Color.green;
			luz.intensity = 0.1f;
			variables.GetComponent<variableContainer> ().varNieblaActiva = true;
			activeTime -= Time.deltaTime;
			timerNiebla.text = convertirFormato(activeTime);
			timerNiebla.color = Color.red;
		} else {
			luz.intensity = 0f;
			luz.color = Color.white;
			darTime ();
			activeTime = 5f;
			variables.GetComponent<variableContainer> ().varNieblaActiva = false;
		}
	}
	public string convertirFormato(float time){
		float sec = Mathf.Floor( time % 60f);
		float min = Mathf.Floor( time/60 % 60f);
		float hour = Mathf.Floor (time / 3600 % 60f);
		if (time < 0) {
			min++;
			hour++;
		}
		string resultadoText = acomodar(sec,min,hour, time);
		return resultadoText;
	}
	public string acomodar(float sec, float min, float hour, float time){
		string ssec, smin, shour;
		ssec = agregarCero (sec);
		smin = agregarCero (min);
		shour = agregarCero (hour);
		if (time < 0) {
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
}
