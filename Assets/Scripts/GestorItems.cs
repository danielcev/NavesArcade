using UnityEngine;
using System.Collections;

public class GestorItems : MonoBehaviour {

	public float velItems = 250.0f;

	//items armas
	public GameObject itemMetralleta;
	public GameObject itemEscopeta;
	public GameObject itemBazooka;
	public float tiempoAparicionArmas = 5.0f;

	//items puntos
	public GameObject itemPuntuacion;
	public float tiempoAparicionPuntos = 5.0f;

	//power ups
	public GameObject itemVida;
	public GameObject itemSpeed;
	public GameObject itemInmune;
	public GameObject itemMunicionExplosiva;
	public GameObject itemMunicionPesada;
	public float tiempoAparicicionPowerUps = 5.0f;

	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("GenerarItemArmas", tiempoAparicionArmas, tiempoAparicionArmas);
		InvokeRepeating ("GenerarItemPuntos", tiempoAparicionPuntos, tiempoAparicionPuntos);
		InvokeRepeating ("GenerarPowerUps", tiempoAparicicionPowerUps, tiempoAparicicionPowerUps);
	}


	void GenerarItemPuntos(){

		GameObject item = Instantiate(itemPuntuacion);

		item.transform.position = new Vector3 (23.0f, Random.Range (-0.49f, -8.87f), 0.0f);

		Rigidbody rgb = item.gameObject.GetComponent<Rigidbody> ();
		rgb.AddForce (Vector3.left * velItems);

	}

	void GenerarItemArmas(){

		GameObject item;

		int aleatorio = Random.Range (1, 4);

		switch (aleatorio) {

		case 1:
			
			item = Instantiate (itemMetralleta);

			break;

		case 2:
			
			item = Instantiate (itemEscopeta);

			break;

		case 3:
			
			item = Instantiate (itemBazooka);

			break;

		default:
			
			item = Instantiate (itemMetralleta);

			break;

		}
			

		item.transform.position = new Vector3 (23.0f, Random.Range (3.83f, -4.14f), 0.0f);

		Rigidbody rgb = item.gameObject.GetComponent<Rigidbody> ();
		rgb.AddForce (Vector3.left * velItems);

	}

	void GenerarPowerUps(){
	
		GameObject powerup;

		int aleatorio = Random.Range (1, 6);

		switch (aleatorio) {

		case 1:

			powerup = Instantiate (itemVida);

			break;

		case 2:

			powerup = Instantiate (itemSpeed);

			break;

		case 3:

			powerup = Instantiate (itemInmune);

			break;

		case 4:

			powerup = Instantiate (itemMunicionExplosiva);

			break;

		case 5:

			powerup = Instantiate (itemMunicionPesada);

			break;

		default:

			powerup = Instantiate (itemVida);

			break;

		}

		powerup.transform.position = new Vector3 (23.0f, Random.Range (-0.49f, -8.87f), 0.0f);

		Rigidbody rgb = powerup.gameObject.GetComponent<Rigidbody> ();
		rgb.AddForce (Vector3.left * velItems);
	
	}

}
