using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GestorArmaUI : MonoBehaviour {

	public Image imagenArma;

	public Sprite bala;
	public Sprite metralleta;
	public Sprite escopeta;
	public Sprite bazooka;

	public static GestorArmaUI instancia;

	void Awake(){

		instancia = this;

	}

	// Use this for initialization
	void Start () {

		imagenArma.sprite = bala;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setUIMetralleta(){
	
		imagenArma.sprite = metralleta;
	
	}

	public void setUIBala(){

		imagenArma.sprite = bala;

	}

	public void setUIEscopeta(){

		imagenArma.sprite = escopeta;

	}

	public void setUIBazooka(){

		imagenArma.sprite = bazooka;

	}
}
