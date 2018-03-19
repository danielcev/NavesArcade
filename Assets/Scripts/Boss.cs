using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

	private int vidasTotales;
	public int vidas = 20;

	Scrollbar vidasBoss;

	public ParticleSystem particulasReactor;
	public ParticleSystem explosion;

	public GameObject escudo;

	private string dificultad;

	private Color colorOriginal;

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

			vidas *= 8;

			break;

		case "Difícil":

			vidas *= 10;

			break;

		}

		vidasTotales = vidas;
	}
	

	void Update () {
	
	}

	public void QuitarVida(int vidasMenos){

		vidas -= vidasMenos;

		ColorRojo ();

		if (vidas <= vidasTotales / 4) { //Si la vida es menos de un cuarto

			particulasReactor.gameObject.SetActive (true);

			this.GetComponent<IABase3> ().cantRafaga = 8;

			InvokeRepeating ("ActivarEscudo", 6.0f, 6.0f);

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

	void ActivarEscudo(){

		escudo.SetActive (true);

		Invoke ("DesactivarEscudo", 3.0f);

	}

	void DesactivarEscudo(){

		escudo.SetActive (false);

	}

	void ColorRojo(){

		this.transform.GetChild (0).transform.GetChild (0).GetComponent<Renderer> ().material.color = Color.red;

		Invoke ("QuitarRojo", 0.5f);

	}

	void QuitarRojo(){


		this.transform.GetChild (0).transform.GetChild (0).GetComponent<Renderer> ().material.color = colorOriginal;
	}

	void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "Player") {

			ManagerLevel.instancia.QuitarVida ();

		}

	}

}
