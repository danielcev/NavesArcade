using UnityEngine;
using System.Collections;

public class DestruirParticulasChoque : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		Invoke("Destruir", 0.5f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Destruir(){

		Destroy (this.gameObject);

	}

}
