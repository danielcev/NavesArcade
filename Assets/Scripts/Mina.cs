using UnityEngine;
using System.Collections;

public class Mina : MonoBehaviour {

	private Color colororiginal;

	private float tiempoExplosion;
	public float radio;

	public ParticleSystem explosion;

	// Use this for initialization
	void Start () {

		colororiginal = this.gameObject.GetComponent<SpriteRenderer> ().material.color;

		InvokeRepeating("CambiarRojo", 1.0f, 1.0f);

		tiempoExplosion = Random.Range (1.0f, 4.0f);

		Invoke ("Explosion", tiempoExplosion);
	
	}


	void OnTriggerEnter (Collider c) {

		if (c.transform.tag == "Player" || c.transform.tag== "Bala") {

			Explosion();
		}

	}

	void CambiarRojo(){
	
		this.gameObject.GetComponent<SpriteRenderer> ().material.color = Color.red;

		Invoke ("QuitarRojo", 0.5f);
	
	}

	void QuitarRojo(){

		this.gameObject.GetComponent<SpriteRenderer> ().material.color = colororiginal;

	}

	public void Explosion (){

		Collider[] hitCollider = Physics.OverlapSphere (this.transform.position, radio);

		ParticleSystem nuevaExplosion = Instantiate (explosion);
		nuevaExplosion.transform.position = this.transform.position;

		for (int i = 0; i < hitCollider.Length; i++) {

			if(hitCollider[i].tag == "Player"){

				ManagerLevel.instancia.QuitarVida ();
			}
		}

		Destroy (this.gameObject);
	}
}
