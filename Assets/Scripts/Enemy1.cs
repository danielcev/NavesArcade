using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {

	public int vidas;

	public ParticleSystem explosion;

	private string dificultad;

	private Color colorOriginal;

	// Use this for initialization
	void Start () {

		colorOriginal = this.transform.GetChild (0).transform.GetChild (9).GetComponent<Renderer> ().material.color;

		dificultad = ManagerLevel.instancia.getDificultad ();

		switch (dificultad) {

		case "Fácil":

			vidas = 1;

			break;

		case "Normal":

			vidas = 2;

			break;

		case "Difícil":

			vidas = 3;

			break;

		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void QuitarVida(int vidasMenos){

		vidas -= vidasMenos;

		ColorRojo ();

		if (vidas <= 0) {

			DestruirNave ();

		}

	}

	void DestruirNave(){

		ParticleSystem nuevaExplosion = Instantiate (explosion);
		nuevaExplosion.transform.position = this.transform.position;

		switch (dificultad) {

		case "Fácil":

			ManagerLevel.instancia.SumarPuntos (10);

			break;

		case "Normal":

			ManagerLevel.instancia.SumarPuntos (20);

			break;

		case "Difícil":

			ManagerLevel.instancia.SumarPuntos (30);

			break;

		}
			
		Destroy (this.gameObject);

	}

	void OnCollisionEnter(Collision other){
	
		if (other.gameObject.tag == "Player") {
		
			ManagerLevel.instancia.QuitarVida ();
		
		}
	
	}

	void ColorRojo(){
	
		this.transform.GetChild (0).transform.GetChild (9).GetComponent<Renderer> ().material.color = Color.red;

		Invoke ("QuitarRojo", 0.5f);
	
	}

	void QuitarRojo(){


		this.transform.GetChild (0).transform.GetChild (9).GetComponent<Renderer> ().material.color = colorOriginal;
	}
}
