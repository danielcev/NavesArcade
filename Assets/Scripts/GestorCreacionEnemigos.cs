using UnityEngine;
using System.Collections;

//Qué cosas pueden pasar
public enum tipoEvento { wave1, wave2, wave3, waveBoss, waveBossTransformable, wavepropio, mina, waveEsparciador, wait, finalNivel };

[System.Serializable]
public class evento {

	public tipoEvento elTipo; // Qué tipo de evento es este

	public Vector3 posIni = new Vector3(19, 0, 0); //Donde pasará el evento
	public Vector3 posIniBoss = new Vector3 (21.83f, 0, 0);

	public int cuantos = 4; //Cuantos habrá

	public float siguiente; //Tiempo para el siguiente evento

}

public class GestorCreacionEnemigos : MonoBehaviour {

	public evento[] losEventos; //Array con los eventos del nivel

	public int currentEvent = 0; //Variable que me indica qué evento está en curso

	public GameObject Enemy1; //Tipos de enemigo normales
	public GameObject Enemy2; //Tipos de enemigo normales
	public GameObject Boss;
	public GameObject triggerFinal;
	public GameObject mina;
	public GameObject EnemyEsparciador;
	public GameObject enemyPropio;
	public GameObject BossTransformable;


	// Use this for initialization
	void Start () {
	
		currentEvent = -1;
		Invoke ("GestionarEvento", 2.0f);
		//GestionarEvento ();

	}

	void GestionarEvento(){

		currentEvent++;

		if (currentEvent >= losEventos.Length) {

			return; //Ya se pasó todo el array
 
		}
			
		//Guardo qué tipo de eventos es el que toca
		tipoEvento tipoActual = losEventos [currentEvent].elTipo;

		//Evaluar cada caso
		switch(losEventos[currentEvent].elTipo){

		case tipoEvento.wave1:

			Debug.Log ("Hacer wave1");
			Wave1 ();

			ManagerLevel.instancia.ReducirOleada ();

			break;

		case tipoEvento.waveEsparciador:

			Debug.Log ("Hacer waveEsparciador");
			waveEsparciador ();

			ManagerLevel.instancia.ReducirOleada ();

			break;

		case tipoEvento.wave2:
			
			Debug.Log ("Hacer wave2");
			StartCoroutine (Wave2());

			ManagerLevel.instancia.ReducirOleada ();
		
			break;

		case tipoEvento.wave3:

			Debug.Log ("Hacer wave3");
			Wave3 ();

			ManagerLevel.instancia.ReducirOleada ();

			break;

		case tipoEvento.waveBoss:

			Debug.Log ("Hacer waveBoss");
			WaveBoss ();

			ManagerLevel.instancia.ReducirOleada ();

			break;

		case tipoEvento.waveBossTransformable:

			Debug.Log ("Hacer waveBossTransformable");
			WaveBossTransformable ();

			ManagerLevel.instancia.ReducirOleada ();

			break;

		case tipoEvento.wavepropio:

			Debug.Log ("Hacer wavePropio");
			WavePropio ();

			ManagerLevel.instancia.ReducirOleada ();

			break;

		case tipoEvento.mina:

			Debug.Log ("Hacer mina");
			Mina ();

			ManagerLevel.instancia.ReducirOleada ();

			break;

		case tipoEvento.wait:
			
			Debug.Log ("Hacer wait");
			StartCoroutine (Wait());

			break;

		case tipoEvento.finalNivel:

			Debug.Log ("Final Nivel");
			FinalNivel ();

			break;

		}

		//El ciclo se hace solo en casos que no sean el WAIT
		if (losEventos [currentEvent].elTipo != tipoEvento.wait) {

			//Gestionar el siguiente evento cuando toque
			float espera = losEventos [currentEvent].siguiente;
			Invoke ("GestionarEvento", espera);

		}

	}

	void Wave1(){

		Vector3 pos = losEventos[currentEvent].posIni;

		for (int x = 0; x < losEventos[currentEvent].cuantos; x++) {

			GameObject nuevoEnemigo = Instantiate(Enemy1); //Crear un clon del enemigo
			nuevoEnemigo.transform.position = pos; //Cambiarle la posición
			pos += 2 * Vector3.down; //Cambiar el valor de la posición
		
		}
	}

	IEnumerator Wave2(){
		
		Vector3 pos = losEventos[currentEvent].posIni;

		for (int x = 0; x < losEventos[currentEvent].cuantos; x++) {

			GameObject nuevoEnemigo = Instantiate(Enemy1); //Crear un clon del enemigo
			nuevoEnemigo.transform.position = pos; //Cambiarle la posición

			yield return new WaitForSeconds (1.0f);

		}

	}

	void Wave3(){

		Vector3 pos = losEventos[currentEvent].posIni;

		for (int x = 0; x < losEventos[currentEvent].cuantos; x++) {

			GameObject nuevoEnemigo = Instantiate(Enemy2); //Crear un clon del enemigo
			nuevoEnemigo.transform.position = pos; //Cambiarle la posición
			pos += 2 * Vector3.down; //Cambiar el valor de la posición

		}
	}

	IEnumerator Wait(){

		//Detectar los enemigos de la escena
		GameObject[] losEnemigos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject boss = GameObject.FindGameObjectWithTag ("Boss");

		bool todosDestruidos = false;

		//Mientras no estén todos destruidos
		while (!todosDestruidos) {

			todosDestruidos = true;
			//Hacer el checking
			foreach(GameObject enemy in losEnemigos){

				if (enemy != null) { //El enemigo en cuestión No está destruido

					todosDestruidos = false;
				
				}

			}

			if (boss != null) {

				todosDestruidos = false;

			}

			yield return new WaitForSeconds (0.25f);

		}

		//Cuando termina la espera, volver a llamar al siguiente evento
		float espera = losEventos [currentEvent].siguiente;
		Invoke ("GestionarEvento", espera);

	}

	void WaveBoss(){

		Vector3 pos = losEventos[currentEvent].posIniBoss;

		GameObject nuevoEnemigo = Instantiate(Boss); //Crear un clon del enemigo
		nuevoEnemigo.transform.position = pos; //Cambiarle la posición
		pos += 2 * Vector3.down; //Cambiar el valor de la posición

	}

	void WaveBossTransformable(){

		Vector3 pos = losEventos[currentEvent].posIniBoss;

		GameObject nuevoEnemigo = Instantiate(BossTransformable); //Crear un clon del enemigo
		nuevoEnemigo.transform.position = pos; //Cambiarle la posición
		pos += 2 * Vector3.down; //Cambiar el valor de la posición

	}

	void FinalNivel(){

		Rigidbody rgb = triggerFinal.GetComponent<Rigidbody> ();

		rgb.AddForce (Vector3.left * 170.0f);



	}

	void Mina(){
	
		GameObject nuevaMina = Instantiate (mina);

		nuevaMina.transform.position = new Vector3(17.0f, -0.38f, 0.0f);

		Rigidbody rgb = nuevaMina.GetComponent<Rigidbody> ();

		rgb.AddForce (Vector3.left * 90.0f);
	
	}

	void waveEsparciador(){

		Vector3 pos = losEventos[currentEvent].posIni;

		for (int x = 0; x < losEventos[currentEvent].cuantos; x++) {

			GameObject nuevoEnemigo = Instantiate(EnemyEsparciador); //Crear un clon del enemigo
			nuevoEnemigo.transform.position = pos; //Cambiarle la posición
			pos += 2 * Vector3.down; //Cambiar el valor de la posición

		}

	}

	void WavePropio(){

		GameObject nuevoEnemigo = Instantiate(enemyPropio); 
		nuevoEnemigo.transform.position = new Vector3 (18.0f, 0.0f,0.0f); 

	}

	}
	
