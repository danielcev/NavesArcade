using UnityEngine;
using System.Collections;

public class BalaEnemiga : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Invoke ("Destruir", 3.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		Debug.Log ("Quito vida");


		if (other.gameObject.tag == "Player") {
		
			ManagerLevel.instancia.QuitarVida ();

			Destroy (this.gameObject);
		
		}
	
	}

	void Destruir(){

		Destroy (this.gameObject);

	}


}
