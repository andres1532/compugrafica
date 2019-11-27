using UnityEngine;
using System.Collections;

public class Arbol : SinPosicionDefinida
{
    private GameObject arbol;
    // Use this for initialization
	void Start(){
		base.Start ();
		rotacionAleatoria ();
	}

    // Update is called once per frame
    void Update()
    {
    }
	void rotacionAleatoria()
	{
			float rot = UnityEngine.Random.Range (0f, 180f);
			this.transform.Rotate (0, 0, rot);		
	}
}
