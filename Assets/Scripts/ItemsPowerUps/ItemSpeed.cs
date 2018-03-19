using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemSpeed : MonoBehaviour {

	private Image imagenSpeed;

	public float tiempoSpeed;

	private GameObject nave;

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

			nave = other.gameObject;

			ActivarSpeed ();

			Destroy (this.gameObject);

		}

	}

	void ActivarSpeed(){

		nave.GetComponent<Control3> ().AumentarVelocidadPowerUp ();
		ManagerLevel.instancia.ActivarSpeedUI ();

	}

}
