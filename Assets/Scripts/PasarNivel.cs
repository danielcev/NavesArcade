using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PasarNivel : MonoBehaviour {

	public int siguienteNivel = 1;

	// Use this for initialization
	void Start () {

		this.GetComponent<Renderer> ().material.color = Color.red;
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Player") {

			if (siguienteNivel == 5) {
			
				SceneManager.LoadScene ("Victoria");
			
			} else {
			
				//Obtener el último nivel desbloqueado
				int lastLevel = PlayerPrefs.GetInt("SelectLv");

				//Comprobar que el nuevo nivel no es inferior al máximo de progreso en el juego
				if (siguienteNivel > lastLevel) {

					PlayerPrefs.SetInt ("Desbloqueado", siguienteNivel);

				}

				int vidas = ManagerLevel.instancia.vidas;

				PlayerPrefs.SetInt ("Vidas", vidas);

				ManagerLevel.instancia.GuardarPuntuacion ();

				PlayerPrefs.SetInt ("numNivel",siguienteNivel);

				SceneManager.LoadScene ("Carga");


			}
		
		}
	
	}
}
