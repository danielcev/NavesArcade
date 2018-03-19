using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CargaNivelBarra : MonoBehaviour {

	private Scrollbar scrollbar;

	public Text textoCargando;

	// Use this for initialization
	void Start () {

		scrollbar = this.gameObject.GetComponent<Scrollbar> ();

		int numNivel = PlayerPrefs.GetInt ("numNivel");

		textoCargando.text = "Cargando Nivel " + numNivel + "...";


	
	}
	
	// Update is called once per frame
	void Update () {

		scrollbar.size += 0.01f;

		if (scrollbar.size == 1) {
		
			int numNivel = PlayerPrefs.GetInt ("numNivel");

			//Cargar el nivel indicado en la variable pública
			SceneManager.LoadScene ("Lev"+numNivel);
		}
	
	}
}
