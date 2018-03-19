using UnityEngine;
using System.Collections;

public class TriggerMuerte : MonoBehaviour {

	void OnTriggerEnter(Collider other){
	
		Destroy (other.gameObject);
	
	}
}
