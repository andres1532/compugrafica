using UnityEngine;
using System.Collections;

public class ZonaSegura : SinPosicionDefinida
{
	private GameObject fpc, variables;
	private float sureRange = 10f;
    // Use this for initialization
	void Start(){
		base.Start ();
		variables = GameObject.Find ("GameController");
	}
    // Update is called once per frame
    void Update()
    {
    }
    void asegurar()
    {

    }
    void activar()
    {

    }
    void desactivar()
    {

    }
	public bool isInside(){
		fpc = GameObject.Find ("FPSController");
			float distance = Mathf.Sqrt(Mathf.Pow((fpc.transform.position.x - this.gameObject.transform.position.x),2f) + Mathf.Pow((fpc.transform.position.y - this.gameObject.transform.position.y),2f) + Mathf.Pow((fpc.transform.position.z - this.gameObject.transform.position.z),2f));
		if (distance <= sureRange) {
			return true;
		} 
		return false;
	}
}
