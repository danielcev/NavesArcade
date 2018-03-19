using UnityEngine;
using System.Collections;

public class ItemVida : MonoBehaviour {


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
		
			ManagerLevel.instancia.RecuperarVida ();

			Destroy (this.gameObject);
		
		}
	
	}
}
