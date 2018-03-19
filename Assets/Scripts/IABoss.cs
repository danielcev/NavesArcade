using UnityEngine;
using System.Collections;

public class IABoss : MonoBehaviour {

	public enum Fases {disp,esp,mover};

	public Fases estadoIA;  //Fase actual

	//Variables para caso Mover
	public float contMov = 0;
	public float limMov = 3;

	//Variables para caso Disp
	public bool empezoCor = false;
	public bool terminoCor = false;

	public GameObject balaEnemiga;
	public float tiempoRafaga;
	public float tiempoEspera;

	public GameObject jugador;
	public GameObject puntoDisparo;
	public float fuerza = 40;

	public int cantRafaga = 4;

	// Use this for initialization
	void Start () {
		estadoIA = Fases.mover;
	}

	// Update is called once per frame
	void Update () {

		//Gestionar las transiciones
		switch (estadoIA) {
		case Fases.disp:
			TransDisp ();
			break;
		case Fases.esp:
			TransEsp ();
			break;
		case Fases.mover:
			TransMover ();
			break;
		}

		//Ejecutar las fases
		switch (estadoIA) {
		case Fases.disp:
			StartCoroutine("EjecutarDisp");
			break;
		case Fases.esp:
			EjecutarEsp();
			break;
		case Fases.mover:
			EjecutarMover();
			break;
		}

	}

	void TransDisp()
	{
		if (empezoCor && terminoCor) {
			estadoIA = Fases.mover;
			empezoCor = false;
			terminoCor = false;
		}
	}
	void TransEsp()
	{
	}
	void TransMover()
	{
		//Chequeamos llegar al limite
		if (contMov > limMov) {
			estadoIA = Fases.disp; //Cambio de fase
			//Reiniciamos los valores del mov
			contMov = 0;
		}
	}

	IEnumerator EjecutarDisp()
	{
		//SEMAFORO: evita que entren varias veces en la corrutina
		if (!empezoCor) {

			empezoCor = true;

			Vector3 dir = (jugador.transform.position - puntoDisparo.transform.position).normalized;
			for (int x = 0; x < cantRafaga; x++) {
				CreaDisp (puntoDisparo.transform.position, dir, fuerza);
				yield return new WaitForSeconds (tiempoRafaga);
			}
			terminoCor = true;
		}
	}
	void EjecutarEsp()
	{
	}
	void EjecutarMover()
	{
		this.transform.Translate (0, Mathf.Cos (Time.time)*Time.deltaTime,0);
		contMov += Time.deltaTime;
	}



	void CreaDisp (Vector3 pos, Vector3 dir, float f)
	{
		GameObject newBala = Instantiate (balaEnemiga);
		newBala.transform.position = pos;
		newBala.GetComponent<Rigidbody> ().AddForce (dir * f, ForceMode.Impulse);
		Destroy (newBala, 3);
	}
}
	
