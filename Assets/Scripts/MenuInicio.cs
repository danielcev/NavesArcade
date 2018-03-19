using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour {

	public Button btnContinuar;
	public Dropdown listaDificultad;
	public Toggle toggleIronMan;

	// Use this for initialization
	void Start () {

		//Obtenemos hasta donde está desbloqueado el juego
		int lastLevel = PlayerPrefs.GetInt ("Desbloqueado");


		//El botón pertenece a un nivel que aún no se ha desbloqueado
		if (lastLevel == 0) {

			btnContinuar.interactable = false; //El botón no se puede pulsar

		}

		string dificultadAlmacenada = PlayerPrefs.GetString ("Dificultad");

		switch (dificultadAlmacenada) {

		case null:

			listaDificultad.value = 0;

			break;

		case "Fácil":

			listaDificultad.value = 0;

			break;

		case "Normal":

			listaDificultad.value = 1;

			break;

		case "Difícil":

			listaDificultad.value = 2;

			break;

		}
	
	}

	public void Nueva(){

		//Desbloquamos el primer nivel
		PlayerPrefs.SetInt ("Desbloqueado", 1);

		SeleccionarDificultad ();

		ModoIronMan ();

		PlayerPrefs.SetInt ("Puntuacion", 0);

		SceneManager.LoadScene ("SelectLv");
	
	}

	public void Continuar(){

		int vidas = PlayerPrefs.GetInt ("Vidas");
		PlayerPrefs.SetInt ("Vidas", vidas);
	
		//Cargar escena de selección de nivel
		SceneManager.LoadScene ("SelectLv");
		
	}

	public void SeleccionarDificultad(){

		switch (listaDificultad.value) {

		case 0: 

			PlayerPrefs.SetString ("Dificultad", "Fácil");
			PlayerPrefs.SetInt ("Vidas", 9);

			break;

		case 1: 

			PlayerPrefs.SetString ("Dificultad", "Normal");
			PlayerPrefs.SetInt ("Vidas", 8);

			break;

		case 2: 

			PlayerPrefs.SetString ("Dificultad", "Difícil");
			PlayerPrefs.SetInt ("Vidas", 7);

			break;

		}

	}

	public void ModoIronMan(){

		if (toggleIronMan.isOn) {
		
			PlayerPrefs.SetInt ("IronMan", 1);
		
		} else {
		
			PlayerPrefs.SetInt ("IronMan", 0);
		
		}

	}

	public void Salir(){

		Application.Quit();

	}
}
