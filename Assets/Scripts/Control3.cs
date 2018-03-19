using UnityEngine;
using System.Collections;

public class Control3 : MonoBehaviour {

	public float vel = 10.0f;
	float limUp;
	float limDown;
	float limRight;
	float limLeft;

	//Las tres posiciones claves del avión
	public Vector3 rotNormal;
	public Vector3 rotIz;
	public Vector3 rotDer;
	public float velRot = 2.0f;

	//Componente camera que renderiza el juego
	public Camera cam;

	// Use this for initialization
	void Start () {

		Vector3 lim1 = cam.ScreenToWorldPoint (new Vector3(0,0,10));
		limDown = lim1.y + 1.2f;
		limLeft = lim1.x + 1.2f;

		Vector3 lim2 = cam.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 10));
		limRight = lim2.x - 0.1f;
		limUp = lim2.y - 1.2f;	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.W)) {

			this.transform.position += Vector3.up * vel * Time.deltaTime;

		}

		if (Input.GetKey (KeyCode.S)) {

			this.transform.position += Vector3.down * vel * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.A)) {

			this.transform.position += Vector3.left * vel * Time.deltaTime;

		}

		if (Input.GetKey (KeyCode.D)) {

			this.transform.position += Vector3.right * vel * Time.deltaTime;

		}

		ArreglarLimites ();
		RotarAvion ();
	}

	void ArreglarLimites(){

		Vector3 posArreglada = new Vector3 (
			Mathf.Clamp (this.transform.position.x, limLeft, limRight),
			Mathf.Clamp (this.transform.position.y, limDown, limUp),
			this.transform.position.z);

		this.transform.position = posArreglada;

	}

	void RotarAvion(){

		//Rotación final al que debe llegar la nave
		Quaternion rotDeseada;

		//Caso por defecto
		rotDeseada = Quaternion.Euler (rotNormal);

		if (Input.GetKey (KeyCode.W)) {

			rotDeseada = Quaternion.Euler(rotIz); //Método que traduce Vector 3 a Quaternion

		}

		if (Input.GetKey (KeyCode.S)) {

			rotDeseada = Quaternion.Euler(rotDer);

		}

		//Lerpear la rotación actual para la rotación deseada
		this.transform.rotation = Quaternion.Lerp (this.transform.rotation, rotDeseada, velRot * Time.deltaTime);

	}

	public void AumentarVelocidadPowerUp(){
	
		vel = 20.0f;

		Invoke ("DesactivarPowerUpVelocidad", 5.0f);
	
	}

	public void DesactivarPowerUpVelocidad(){

		vel = 10.0f;

	}
}
