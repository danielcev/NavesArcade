using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossTransformable: MonoBehaviour {

	private int vidasTotales;
	public int vidas = 20;

	Scrollbar vidasBoss;

	public ParticleSystem explosion;

	private string dificultad;

	private Color colorOriginal;

	public GameObject balaExplosiva;
	public GameObject posDisparo;
	public GameObject imagenShoot;

	public GameObject rayo;

	private bool primeraFase = true;
	private bool segundaFase = false;
	private bool terceraFase = false;

	private Vector3 posAleatoria;


	void Start () {

		colorOriginal = this.transform.GetChild (0).transform.GetChild (0).GetComponent<Renderer> ().material.color;
		
		//Referencia del scrollbar de vidas del boss
		vidasBoss = GameObject.Find("Canvas").transform.Find("ScrollbarVidasBoss").GetComponent<Scrollbar>(); 

		vidasBoss.gameObject.SetActive (true);
		vidasBoss.size = 1.0f;

		dificultad = ManagerLevel.instancia.getDificultad ();

		switch (dificultad) {

		case "Fácil":

			vidas *= 4;

			break;

		case "Normal":

			vidas *= 5;

			break;

		case "Difícil":

			vidas *= 6;

			break;

		}

		vidasTotales = vidas;

		InvokeRepeating ("Disparar", 1.0f,4.0f);

	}
	

	void Update () {
	
	}

	public void QuitarVida(int vidasMenos){

		vidas -= vidasMenos;

		ColorRojo ();

		if (vidas <= vidasTotales / 1.5f) { //Si pasa a la segunda fase

			primeraFase = false;
			segundaFase = true;

		}

		if (vidas <= vidasTotales / 3) { //Si pasa a la tercera fase
		
			segundaFase = false;
			terceraFase = true;
		
		}

		vidasBoss.size = (float) vidas / vidasTotales;

		if (vidas <= 0) {

			DestruirNave ();

			vidasBoss.gameObject.SetActive (false);

		}
			
	}

	void DestruirNave(){

		switch (dificultad) {

		case "Fácil":

			ManagerLevel.instancia.SumarPuntos (100);

			break;

		case "Normal":

			ManagerLevel.instancia.SumarPuntos (200);

			break;

		case "Difícil":

			ManagerLevel.instancia.SumarPuntos (300);

			break;

		}

		ParticleSystem nuevaExplosion = Instantiate (explosion);
		nuevaExplosion.transform.position = this.transform.position;

		Destroy (this.gameObject);

	}


	void ColorRojo(){

		this.transform.GetChild (0).transform.GetChild (0).GetComponent<Renderer> ().material.color = Color.red;

		Invoke ("QuitarRojo", 0.5f);

	}

	void QuitarRojo(){


		this.transform.GetChild (0).transform.GetChild (0).GetComponent<Renderer> ().material.color = colorOriginal;
	}

	void Disparar(){
	
		if (primeraFase) {

			DispararBombaExplosiva ();

		}

		if (segundaFase) {

			RayosMortales ();

		}

		if (terceraFase) {
		
			this.gameObject.GetComponent<IABase3Transformable> ().enabled = false;
			this.gameObject.GetComponent<TeletransporteBoss> ().enabled = true;
		
		}
	
	}

	void DispararBombaExplosiva(){

		GameObject nuevaBalaExplosiva = Instantiate (balaExplosiva);
		nuevaBalaExplosiva.transform.position = posDisparo.transform.position;

		Rigidbody rgb = nuevaBalaExplosiva.GetComponent<Rigidbody> ();

		float valory = Random.Range (-1.01f,1.01f);
		Vector3 cambioy = new Vector3 (-1.0f, valory, 0.0f);

		rgb.AddForce (cambioy * 140.0f);

	}

	void RayosMortales(){

		float posXAleatoria = Random.Range (5.00f, 18.00f);
		float posYAleatoria = Random.Range (-3.67f, 2.92f);
	
		posAleatoria = new Vector3 (posXAleatoria, posYAleatoria, 0.0f);

		GameObject newImagenShoot = Instantiate (imagenShoot);
		newImagenShoot.transform.position = posAleatoria;

		Invoke ("LanzarRayo", 2.0f);

		Destroy (newImagenShoot, 4.0f);

	
	}

	void LanzarRayo(){

		GameObject newRayo = Instantiate (rayo);
		newRayo.transform.position = posAleatoria;

	}

	void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "Player") {

			ManagerLevel.instancia.QuitarVida ();

		}

	}

}
