using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class ManagerLevel : MonoBehaviour {

	public static ManagerLevel instancia;

	public int vidas = 9;
	public int puntuacion = 0;

	string dificultad;

	public Text textPuntuacion;

	public List<Image> corazonesVidas = new List<Image>();

	public Image imagenSpeed;
	public Image imagenInmune;
	public Image imagenMunicionExplosiva;
	public Image imagenMunicionPesada;

	public Text oleadasRestantes;

	private bool inmune = false;

	public float tiempoInmune = 10.0f;

	private int vidasmenos; //Número de vidas que se restan en función a la dificultad

	public bool canvasActivo = false;

	private int oleadas = 5;

	void Awake(){

		instancia = this;
		dificultad = PlayerPrefs.GetString ("Dificultad");

		imagenSpeed = GameObject.Find("Canvas").transform.Find("ImagenSpeed").GetComponent<Image>(); 
		imagenInmune = GameObject.Find("Canvas").transform.Find("ImagenInmune").GetComponent<Image>(); 
		imagenMunicionExplosiva = GameObject.Find("Canvas").transform.Find("ImagenMunicionExplosiva").GetComponent<Image>(); 
		imagenMunicionPesada = GameObject.Find("Canvas").transform.Find("ImagenMunicionPesada").GetComponent<Image>(); 

		vidas = PlayerPrefs.GetInt ("Vidas");

		if (vidas == 0) {
		
			vidas = 9;
		
		}

		switch(dificultad){

		case "Fácil":

			vidasmenos = 1;

			break;

		case "Normal":

			vidasmenos = 2;

			break;

		case "Difícil":

			vidasmenos = 3;

			break;


		}

		CargarPuntuacion ();

		ActualizarUIOleadas ();

		ActualizarUIVidas ();
	}

	public string getDificultad(){
	
		return dificultad;
	
	}

	public void QuitarVida(){

		if (!inmune) { //Solo recibe daño si la variable inmune está en false (no ha cogido el power up de invencibilidad)

			vidas -= vidasmenos;

			if (vidas == -1) { //Para evitar errores en el array del método ActualizarUIVidas
			
				vidas = 0;
			
			}

			ActualizarUIVidas ();

			GestorSonidos.instancia.SonarDañoPersonaje ();

			if (vidas <= 0) {

				//Si el modo ironMan no está activado
				if (PlayerPrefs.GetInt ("IronMan") == 0) {

					PlayerPrefs.SetInt ("Desbloqueado", PlayerPrefs.GetInt("Desbloqueado"));
				
					//Se guardan la puntuación y las vidas
					PlayerPrefs.SetInt ("Puntuacion", puntuacion);
					PlayerPrefs.SetInt ("Vidas", vidas);

					SceneManager.LoadScene ("Game Over");
				
				} else { //Si el modo ironMan está activado

					PlayerPrefs.SetInt ("Desbloqueado", 0);
					//La puntuación y las vidas se reestablecen
					PlayerPrefs.SetInt ("Puntuacion", 0);
					PlayerPrefs.SetInt ("Vidas", 9);

					SceneManager.LoadScene ("Game Over");

				}
					
			}
		
		}

	}

	public void RecuperarVida(){
	
		if(vidas <= 8)
		vidas++;

		ActualizarUIVidas ();


	}

	public void ActualizarUIVidas(){

		for (int i = 8; i > 0; i--) { //Reseteamos los corazones de vida de la UI

			corazonesVidas [i].enabled = true;

		}

		for (int i = 8; i >= vidas; i--) {

			corazonesVidas [i].enabled = false;

		}

	}

	public void ActualizarUIPuntuacion(){
	
		textPuntuacion.text = puntuacion.ToString();
	
	}

	public void SumarPuntos(int puntos){

		puntuacion += puntos;

		ActualizarUIPuntuacion ();

	}

	public void ActivarSpeedUI(){

		imagenSpeed.gameObject.SetActive (true);

		Invoke ("DesactivarSpeedUI", 5.0f);

	}

	public void DesactivarSpeedUI(){

		imagenSpeed.gameObject.SetActive (false);

	}

	public void ActivarInmune(){
	
		inmune = true;

		imagenInmune.gameObject.SetActive (true);

		Invoke ("DesactivarInmune", tiempoInmune);
	
	}

	public void DesactivarInmune(){

		imagenInmune.gameObject.SetActive (false);

		inmune = false;

	}

	public void ActivarUIMunicionExplosiva(){

		imagenMunicionExplosiva.gameObject.SetActive (true);

	}

	public void DesactivarUIMunicionExplosiva(){

		imagenMunicionExplosiva.gameObject.SetActive (false);

	}

	public void ActivarUIMunicionPesada(){
	
		imagenMunicionPesada.gameObject.SetActive (true);
	
	}

	public void DesactivarUIMunicionPesada(){

		imagenMunicionPesada.gameObject.SetActive (false);

	}

	public void ReducirOleada(){
	
		oleadas--;

		ActualizarUIOleadas ();
	
	}

	public void ActualizarUIOleadas(){
	
		oleadasRestantes.text = "Oleadas restantes: " + oleadas;
	
	}

	public void GuardarPuntuacion(){


		PlayerPrefs.SetInt ("Puntuacion", puntuacion);

	}

	public void CargarPuntuacion(){

		puntuacion = PlayerPrefs.GetInt ("Puntuacion");

		ActualizarUIPuntuacion ();
	}

}
