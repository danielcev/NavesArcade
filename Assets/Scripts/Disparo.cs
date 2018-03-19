using UnityEngine;
using System.Collections;



public class Disparo : MonoBehaviour {

	public enum tipDisp{ bala, metralleta, escopeta, bazoka };

	public GameObject balaNormal;
	public GameObject balaExplosiva;
	public GameObject balaPesada;

	private bool municionExplosiva = false;
	private bool municionPesada = false;

	public Transform posDisparo;

	public int cantRafaga = 4; // Cuantas balas disparará por pulsación
	public int contRafaga = 0; // Cuantas balas ha disparado en la ráfaga
	public float tiempoRafaga = 0.1f; // Tiempo entre las balas en la ráfaga

	public float forceBala = 20.0f;

	public tipDisp miArma;

	private int contadorBalasExplosivas = 0;
	private int contadorMunicionPesada = 0;

	public int numeroBalasExplosivas = 8;
	public int numeroMunicionPesada = 8;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (!ManagerLevel.instancia.canvasActivo) {

			if (Input.GetKeyDown (KeyCode.Mouse0)) {

				GestorSonidos.instancia.SonarDisparo ();

				if (!municionExplosiva && !municionPesada) { //Si la munición explosiva no está activada
			
					switch (miArma) {

					case tipDisp.bala:
						Mod1 ();
						break;

					case tipDisp.metralleta:
						Mod2 ();
						break;

					case tipDisp.escopeta:
						Mod3 ();
						break;

					case tipDisp.bazoka: 
						Mod4 ();
						break;
					}

				} else {

					if (municionExplosiva) {

						Mod1Explosiva ();

						contadorBalasExplosivas++;

						if (contadorBalasExplosivas >= numeroBalasExplosivas) {

							DesactivarMunicionExplosiva ();

						}
				
					} else { // Por defecto, si munición pesada está activada
				
						Mod1Pesada ();	

						contadorMunicionPesada++;

						if (contadorMunicionPesada >= numeroMunicionPesada) {
					
							DesactivarMunicionPesada ();
					
						}
				
					}
					
				}
				
			}

		}
	}

	void Mod1(){
		CreaDisp (this.transform.position, this.transform.right, forceBala);
	}

	void Mod1Explosiva(){

		CreaDispExplosivo (this.transform.position, this.transform.right, forceBala);

	}

	void Mod1Pesada(){

		CreaDispPesada (this.transform.position, this.transform.right, forceBala);

	}

	//Triple angular
	void Mod2(){
		CreaDisp (this.transform.position, this.transform.right, forceBala);
		CreaDisp (this.transform.position, this.transform.right + this.transform.up/2, forceBala);
		CreaDisp (this.transform.position, this.transform.right - this.transform.up/2, forceBala);
	}

	//Escopeta
	void Mod3(){
		for (int x = 0; x < 3; x++) {
		
			Vector3 cambio = this.transform.up * Random.Range (-1f, 1f);
			CreaDisp (this.transform.position, (this.transform.right + cambio).normalized, forceBala);
		
		}
	}

	void Mod4(){

		//Si ya se han disparado todas las balas de la ráfaga, se termina
		if (contRafaga >= cantRafaga) {
			contRafaga = 0;	
			return;
		}

		CreaDisp(this.transform.position, this.transform.right, forceBala);
		Invoke("Mod4", tiempoRafaga);
		contRafaga++; //Actualizar las balas disparadas
	}

	void CreaDisp(Vector3 pos, Vector3 dir, float f){

		GameObject newBala = Instantiate (balaNormal);
		newBala.transform.position = posDisparo.position;
		newBala.GetComponent<Rigidbody> ().AddForce (dir * f, ForceMode.Impulse);

		Destroy (newBala, 5);
	}

	void CreaDispExplosivo(Vector3 pos, Vector3 dir, float f){
	
		GameObject newBala = Instantiate (balaExplosiva);
		newBala.transform.position = posDisparo.position;
		newBala.GetComponent<Rigidbody> ().AddForce (dir * f, ForceMode.Impulse);

		Destroy (newBala, 5);
	
	}

	void CreaDispPesada(Vector3 pos, Vector3 dir, float f){

		GameObject newBala = Instantiate (balaPesada);
		newBala.transform.position = posDisparo.position;
		newBala.GetComponent<Rigidbody> ().AddForce (dir * f, ForceMode.Impulse);

		Destroy (newBala, 5);

	}

	void OnTriggerEnter(Collider c){

		Destroy (c.gameObject);

		switch (c.gameObject.tag) {
			
			case "item2":
				miArma = tipDisp.metralleta;
				break;

			case "item3":
				miArma = tipDisp.escopeta;
				break;

			case "item4":
				miArma = tipDisp.bazoka;
				break;
			
		}
	}

	public void ActivarMunicionExplosiva(){

		municionExplosiva = true;

		ManagerLevel.instancia.ActivarUIMunicionExplosiva ();

	}

	public void DesactivarMunicionExplosiva(){

		municionExplosiva = false;

		contadorBalasExplosivas = 0;

		ManagerLevel.instancia.DesactivarUIMunicionExplosiva ();

	}

	public void ActivarMunicionPesada(){

		municionPesada = true;

		ManagerLevel.instancia.ActivarUIMunicionPesada ();

	}

	public void DesactivarMunicionPesada(){

		municionPesada = false;

		contadorMunicionPesada = 0;

		ManagerLevel.instancia.DesactivarUIMunicionPesada ();

	}

}
