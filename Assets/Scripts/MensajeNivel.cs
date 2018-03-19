using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MensajeNivel : MonoBehaviour {

	public Image sistemaVidas;

	// Use this for initialization
	void Start () {

		Rigidbody rgd = this.GetComponent<Rigidbody> ();
		rgd.AddForce (Vector3.left * 500);

		Invoke ("Destruir", 4.0f);
	
	}
	

	void Destruir(){

		Destroy (this.gameObject);

	}
		
}
