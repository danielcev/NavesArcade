using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextoGameOver : MonoBehaviour {

	private Text textoGameOver;

	bool hacerGrande = true;

	// Use this for initialization
	void Start () {

		textoGameOver = this.gameObject.GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (hacerGrande) {

			HacerGrande ();
		
		} else {
		
			HacerPequeño ();
		
		}
			

		if(textoGameOver.fontSize <= 80){
		
			hacerGrande = true;
		
		}

		if (textoGameOver.fontSize >= 137) {
		
			hacerGrande = false;
		
		}
	
	}

	void HacerGrande(){

		textoGameOver.fontSize += 1;

	}

	void HacerPequeño(){
	
		textoGameOver.fontSize -= 1;
	
	}

}
