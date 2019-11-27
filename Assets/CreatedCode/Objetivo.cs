using UnityEngine;
using System.Collections;

public class Objetivo : SinPosicionDefinida
{
	protected float velocidad = 0.38f, escalax,escalay,escalaz;
    public bool destruir = false, primeraColission = true;
	protected GameObject variables, fpc;

    // Use this for initialization
    public void Start()
    {
		variables = GameObject.Find ("GameController");
        escalax = this.gameObject.transform.localScale.x;
        escalay = this.gameObject.transform.localScale.y;
        escalaz = this.gameObject.transform.localScale.z;
		base.Start();
    }
    // Update is called once per frame
    public void Update()
    {
        if (destruir)
        {
            escalax = escalax - (velocidad * Time.deltaTime);
            escalay = escalay - (velocidad * Time.deltaTime);
            escalaz = escalaz - ((velocidad*escalaz * Time.deltaTime)/escalax);
            this.gameObject.transform.localScale = new Vector3(escalax, escalay, escalaz);
        }
    }
	public void OnCollisionEnter(Collision collision){
		MeshCollider m = this.gameObject.GetComponent<MeshCollider> ();
		m.enabled = false;
		primeraColission = false;
		destruir = true;
		fpc = GameObject.Find ("FPSController");
		fpc.GetComponent<FPController> ().baccelerar = true;
	}


}
