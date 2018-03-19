using UnityEngine;
using System.Collections;

public class BackGroundOffset : MonoBehaviour {

	private Renderer rdr;

	private float contOffset = 0;
	public float velOffset = 1f;

	public Texture laTextura;

	// Use this for initialization
	void Start () {

		rdr = this.GetComponent<Renderer> ();

		rdr.material.SetTexture ("_MainTex", laTextura);
	}
	
	// Update is called once per frame
	void Update () {
		contOffset += velOffset * Time.deltaTime;

		rdr.material.SetTextureOffset ("_MainTex", new Vector2(contOffset, 0.0f));

	}
}
