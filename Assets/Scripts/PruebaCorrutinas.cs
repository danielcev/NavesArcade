using UnityEngine;
using System.Collections;

public class PruebaCorrutinas : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine ("EjemploTiempos");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator EjemploTiempos(){

		Debug.Log ("Empieza la corrutina " + Time.time);
		Debug.Log ("Esperamos al siguiente frame " + Time.time);
		yield return null;
		Debug.Log ("FINALIZADO: Esperamos al siguiente frame " + Time.time);
		Debug.Log ("Esperamos 2 segundos");
		yield return new WaitForSeconds (2);
		Debug.Log ("FINALIZADO: Esperamos 2 segundos " + Time.time);
		Debug.Log ("Esperamos al siguiente fixedupdate " + Time.time);
		yield return new WaitForFixedUpdate ();
		Debug.Log ("FINALIZADO: Esperamos al siguiente fixedupdate " + Time.time);

	}

}
