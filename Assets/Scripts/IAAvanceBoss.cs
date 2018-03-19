using UnityEngine;
using System.Collections;

public class IAAvanceBoss : MonoBehaviour {

	public float vel = 2;

	private bool avanzar = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (avanzar) {

			this.transform.position += Vector3.left * Time.deltaTime * vel;

		} else {

			this.transform.position += Vector3.right * Time.deltaTime * vel;

		}

		if (this.transform.position.x <= 10.0f) {

			avanzar = false;

		}

		if (this.transform.position.x >= 19.0f) {

			avanzar = true;

		}


	}
}
