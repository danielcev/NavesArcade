using UnityEngine;
using System.Collections;

public class TeletransporteBoss : MonoBehaviour {

	public GameObject balaEnemiga;
	public GameObject posDisparo;
	public GameObject posDisparoFinal;

	public float fuerza = 30;

	public bool empezoCor = false;
	public bool terminoCor = false;

	public int cantRafaga = 4;
	public float tiempoRafaga;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("Aparecer", 1.5f, 1.5f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Aparecer(){
	
		float posx = Random.Range (7.5f, 19.0f);
		float posy = Random.Range (-3.91f, 3.56f);
		this.transform.position = new Vector3 (posx, posy, 0);

		Invoke ("Disparar", 0.1f);
	
	}
		
	void Disparar (){

		GameObject newBala = Instantiate (balaEnemiga);
		newBala.transform.position = posDisparo.transform.position;
		newBala.GetComponent<Rigidbody> ().AddForce (Vector3.up * fuerza, ForceMode.Impulse);
		Destroy (newBala, 3);

		Invoke ("DispararBala2", 0.3f);
	}

	void DispararBala2 (){

		GameObject newBala = Instantiate (balaEnemiga);
		newBala.transform.position = posDisparo.transform.position;
		newBala.GetComponent<Rigidbody> ().AddForce (posDisparoFinal.transform.right * fuerza, ForceMode.Impulse);
		Destroy (newBala, 3);

		Invoke ("DispararBala3", 0.3f);
	}

	void DispararBala3 (){

		GameObject newBala = Instantiate (balaEnemiga);
		newBala.transform.position = posDisparo.transform.position;
		newBala.GetComponent<Rigidbody> ().AddForce (Vector3.left * fuerza, ForceMode.Impulse);
		Destroy (newBala, 3);

		Invoke ("DispararBala4", 0.3f);
	}

	void DispararBala4(){

		GameObject newBala = Instantiate (balaEnemiga);
		newBala.transform.position = posDisparo.transform.position;
		newBala.GetComponent<Rigidbody> ().AddForce (posDisparoFinal.transform.up * fuerza, ForceMode.Impulse);
		Destroy (newBala, 3);

		Invoke ("DispararBala5", 0.3f);
	}

	void DispararBala5(){

		GameObject newBala = Instantiate (balaEnemiga);
		newBala.transform.position = posDisparo.transform.position;
		newBala.GetComponent<Rigidbody> ().AddForce (Vector3.down * fuerza, ForceMode.Impulse);
		Destroy (newBala, 3);
	}
}
