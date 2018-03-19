using UnityEngine;
using System.Collections;

public class IABase : MonoBehaviour {

	public GameObject balaEnemiga;
	public float tiempoRafaga;
	public float tiempoEspera;

	public GameObject jugador;
	public GameObject puntoDisparo;
	public float fuerza = 40;

	public int cantRafaga = 4;

	// Use this for initialization
	void Start () {
		StartCoroutine ("ComportamientoBase");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ComportamientoBase()
	{
		Vector3 dir = Vector3.zero;
		while (true) {
			//La rafaga//
			//Actualizar la direccion
			dir = (jugador.transform.position-puntoDisparo.transform.position).normalized;
			for (int x = 0; x < cantRafaga; x++) {
				CreaDisp (puntoDisparo.transform.position, dir, fuerza);
				yield return new WaitForSeconds (tiempoRafaga);
			}
			//FIN de la rafaga//

			//ESPERAR
			yield return new WaitForSeconds (tiempoEspera);
		}
	}


	void CreaDisp (Vector3 pos, Vector3 dir, float f)
	{
		GameObject newBala = Instantiate (balaEnemiga);
		newBala.transform.position = pos;
		newBala.GetComponent<Rigidbody> ().AddForce (dir * f, ForceMode.Impulse);
		Destroy (newBala, 3);
	}
}
