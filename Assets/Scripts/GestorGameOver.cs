using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GestorGameOver : MonoBehaviour {

	public AudioSource musicaGameOver;

	// Use this for initialization
	void Start () {

		musicaGameOver.Play ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CargarMenu(){

		SceneManager.LoadScene ("Menu");

	}
}
