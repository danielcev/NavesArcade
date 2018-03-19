using UnityEngine;
using System.Collections;

public class ItemPuntuacion : MonoBehaviour {

	public ParticleSystem particulasDestello;

	private string dificultad;

	// Use this for initialization
	void Start () {

		dificultad = ManagerLevel.instancia.getDificultad ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
	
		if (other.tag == "Player") {

			ParticleSystem nuevoDestello = Instantiate (particulasDestello);
			nuevoDestello.transform.position = this.transform.position;
		
			switch (dificultad) {

			case "Fácil":
				
				ManagerLevel.instancia.SumarPuntos (5);

				break;

			case "Normal":
				
				ManagerLevel.instancia.SumarPuntos (10);

				break;

			case "Difícil":
				
				ManagerLevel.instancia.SumarPuntos (15);

				break;

			}

			Destroy (this.transform.parent.gameObject);
		
		}
	
	}
}
