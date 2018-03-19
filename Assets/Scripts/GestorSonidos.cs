using UnityEngine;
using System.Collections;

public class GestorSonidos : MonoBehaviour {

	public AudioSource musicaJuego;
	public AudioSource disparo;
	public AudioSource dañoPersonaje;
	public AudioSource dañoEnemigo;

	public static GestorSonidos instancia;


	void Awake(){

		instancia = this;

	}

	void Start() {
		
		musicaJuego.Play ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SonarDisparo(){

		disparo.Play ();

	}

	public void SonarDañoPersonaje(){
	
		dañoPersonaje.Play ();
	
	}

	public void SonarDañoEnemigo(){

		dañoEnemigo.Play ();

	}

	public void SetearVolumen(float valor){

		musicaJuego.volume = valor;
		disparo.volume = valor;
		dañoPersonaje.volume = valor;
		dañoEnemigo.volume = valor;


	}

	public void VolumenON(){
	
		musicaJuego.mute = false;
		disparo.mute = false;
		dañoPersonaje.mute = false;
		dañoEnemigo.mute = false;

	}

	public void VolumenOFF(){

		musicaJuego.mute = true;
		disparo.mute = true;
		dañoPersonaje.mute = true;
		dañoEnemigo.mute = true;
	}


}
