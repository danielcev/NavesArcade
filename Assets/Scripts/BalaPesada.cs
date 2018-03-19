using UnityEngine;
using System.Collections;

public class BalaPesada : MonoBehaviour {

	public ParticleSystem particulasChoque;

	// Use this for initialization
	void Start () {

		Invoke ("DestruirBala", 3.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Enemy") {

			Enemy1 enemy1 = other.gameObject.GetComponent<Enemy1> ();

			if (enemy1 != null) {

				enemy1.QuitarVida (2);

				GenerarParticulas ();
				GestorSonidos.instancia.SonarDañoEnemigo ();

			} else {

				Mina mina = other.gameObject.GetComponent<Mina> ();
				mina.Explosion ();

				GenerarParticulas ();
			}

			DestruirBala ();


		}


		if (other.gameObject.tag == "Boss") {

			Boss boss = other.gameObject.GetComponent<Boss> ();

			if (boss != null) {

				boss.QuitarVida (2);
			} else {

				BossTransformable bossTransformable = other.gameObject.GetComponent<BossTransformable> ();
				bossTransformable.QuitarVida (2);

			}

			DestruirBala ();

			GenerarParticulas ();

			GestorSonidos.instancia.SonarDañoEnemigo ();
		}

		if (other.gameObject.tag == "Escudo") {

			DestruirBala ();

			GenerarParticulas ();

		}


	}

	void DestruirBala(){

		Destroy (this.gameObject);

	}

	void GenerarParticulas(){

		ParticleSystem nuevasParticulas = Instantiate (particulasChoque);
		nuevasParticulas.transform.position = this.transform.position;
	}
}
