using UnityEngine;
using System.Collections;

public class ItemArma : MonoBehaviour {

	public ParticleSystem particulasDestello;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
	
		if (other.gameObject.tag == "Player") {

			ParticleSystem nuevoDestello = Instantiate (particulasDestello);
			nuevoDestello.transform.position = this.transform.position;

			Destroy (this.gameObject);
		
			Disparo disparo = other.GetComponent<Disparo> ();

			switch (this.gameObject.tag) {

			case "Metralleta":

				disparo.miArma = Disparo.tipDisp.metralleta;

				GestorArmaUI.instancia.setUIMetralleta ();

				break;

			case "Escopeta":

				disparo.miArma = Disparo.tipDisp.escopeta;

				GestorArmaUI.instancia.setUIEscopeta ();

				break;

			case "Bazooka":

				disparo.miArma = Disparo.tipDisp.bazoka;

				GestorArmaUI.instancia.setUIBazooka ();

				break;

			
			}

		}
	
	}
}
