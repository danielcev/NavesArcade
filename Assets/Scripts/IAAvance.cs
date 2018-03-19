using UnityEngine;
using System.Collections;

public class IAAvance : MonoBehaviour {

	public float vel = 2;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	

		this.transform.position += Vector3.left * Time.deltaTime * vel;
	
	}
		
}
