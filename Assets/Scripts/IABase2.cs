using UnityEngine;
using System.Collections;

public class IABase2 : MonoBehaviour {

	public GameObject balaEnemiga;
	public float tiempoRafaga;
	public float tiempoEspera;

	public GameObject jugador;
	public GameObject puntoDisparo;
	public float fuerza = 40;

	public int cantRafaga = 4;

	private Rigidbody rgb;

	public float vellerp = 2.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine ("Atacar");
		rgb = this.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

	}

	//ataque tipo rafagas
	IEnumerator Atacar (){
		
		Vector3 dir = Vector3.zero;

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
		
		StartCoroutine ("Esperar");

	}
	IEnumerator Esperar (){
		yield return new WaitForSeconds (tiempoEspera);
		StartCoroutine ("Mover");
	}
	IEnumerator Mover (){
		float velX = Random.Range (5f, 5f);
		float velY = Random.Range (5f, 5f);

		rgb.velocity = new Vector3 (velX, velY, 0);
		yield return new WaitForSeconds (2);
		rgb.velocity = Vector3.zero;

		StartCoroutine ("Atacar");

	}

	IEnumerator Mover2(){
	
		float tiempoIni = Time.time; //Guardo el momento inicial

		float velX = Random.Range (5f, 5f);
		float velY = Random.Range (5f, 5f);

		while(Time.time < tiempoIni + 2){
		
			this.transform.Translate (new Vector3(velX,velY,0)*Time.fixedDeltaTime);

			yield return new WaitForFixedUpdate ();
		}

		StartCoroutine ("Atacar");

	}

	IEnumerator Mover3(){

		//Calculamos la posición de destino
		float posX = Random.Range (-10f, 10f);
		float posY = Random.Range (-6f,6f);
		Vector3 destino = new Vector3 (posX, posY);

		while (Vector3.Distance (this.transform.position, destino) > 0.1f) {

			this.transform.position = Vector3.Lerp (this.transform.position, destino, vellerp * Time.fixedDeltaTime);
			yield return new WaitForFixedUpdate ();
		}

		StartCoroutine ("Atacar");

	}


	void CreaDisp (Vector3 pos, Vector3 dir, float f){
		
		GameObject newBala = Instantiate (balaEnemiga);
		newBala.transform.position = pos;
		newBala.GetComponent<Rigidbody> ().AddForce (dir * f, ForceMode.Impulse);
		Destroy (newBala, 3);

	}
}
