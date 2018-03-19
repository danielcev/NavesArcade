using UnityEngine;
using System.Collections;

public class BalaExplosiva : MonoBehaviour {

	public ParticleSystem explosion;

	public float radio;

	void OnTriggerEnter(Collider other){
	
	
		if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss" || other.gameObject.tag == "Mina") {

			Explosion ();
		
		}

		if (other.gameObject.tag == "Escudo") {

			DestruirBala ();

		}
	
	}

	public void Explosion (){

		Collider[] hitCollider = Physics.OverlapSphere (this.transform.position, radio);

		ParticleSystem nuevaExplosion = Instantiate (explosion);
		nuevaExplosion.transform.position = this.transform.position;

		for (int i = 0; i < hitCollider.Length; i++) {

			if(hitCollider[i].tag == "Enemy1"){

				hitCollider [i].GetComponent<Enemy1> ().QuitarVida (1);
			}

			if(hitCollider[i].tag == "Boss"){

				Boss boss = hitCollider [i].GetComponent<Boss> ();

				if (boss != null) {
					boss.QuitarVida (1);
				
				} else {
				
					hitCollider [i].GetComponent<BossTransformable> ().QuitarVida(1);

				}
			}


		}

		DestruirBala ();
	}

	void DestruirBala(){

		Destroy (this.gameObject);

	}

}
