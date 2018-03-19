using UnityEngine;
using System.Collections;

public class DestruirParticulas : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Invoke("Destruir", 3.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Destruir(){
	
		Destroy (this.gameObject);
	
	}
}
