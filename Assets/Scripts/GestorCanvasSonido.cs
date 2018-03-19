using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GestorCanvasSonido : MonoBehaviour {

	public Canvas canvasSonido;
	private Slider sliderVolumen;
	private Toggle toggleVolumen;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActivarCanvasSonido(){

		Time.timeScale = 0;

		ManagerLevel.instancia.canvasActivo = true;

		canvasSonido.gameObject.SetActive (true);

	}

	public void CerrarCanvasSonido(){

		Time.timeScale = 1;

		ManagerLevel.instancia.canvasActivo = false;
	
		canvasSonido.gameObject.SetActive (false);
	
	}

	public void ModificarVolumen ()
	{
		sliderVolumen = GameObject.FindGameObjectWithTag ("SliderVolumen").GetComponent<Slider> ();
	
		float valor = sliderVolumen.value;

		GestorSonidos.instancia.SetearVolumen (valor);
	
	}

	public void VolumenOnOff(){

		toggleVolumen = GameObject.FindGameObjectWithTag ("ToggleVolumen").GetComponent<Toggle> ();

		if (toggleVolumen.isOn) {
		
			GestorSonidos.instancia.VolumenON ();
		
		} else {
		
			GestorSonidos.instancia.VolumenOFF ();
		
		}

	}

}
