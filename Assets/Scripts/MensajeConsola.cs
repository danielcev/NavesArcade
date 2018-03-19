using UnityEngine;
using System.Collections;

public class MensajeConsola : MonoBehaviour {

	public string mensaje;

	void Awake(){
		Debug.Log (mensaje);
	}

	void Start () {
		
	}
		
	// Update is called once per frame
	void Update () {
	
	}
}
