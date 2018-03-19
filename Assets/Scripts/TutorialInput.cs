using UnityEngine;
using System.Collections;
[System.Serializable]
public class regla {
	public KeyCode kd;
	public float lim;
	public float cont;
	public string mensage;

	public KeyCode KdInconpatible;
	public string mensIncompatible;
}

public class TutorialInput : MonoBehaviour {

	public regla[] LasReglas;

	// Update is called once per frame
	void Update () {
		foreach (regla r in LasReglas) {
			if (Input.GetKey (r.kd)) {
				if (r.KdInconpatible != null && Input.GetKey (r.KdInconpatible)) {
					Debug.Log (r.mensIncompatible);
				}
			} else {
				r.cont += Time.deltaTime;
				if (r.cont > r.lim) {
					Debug.Log (r.mensage);
					r.cont = 0;
				}
			}
		}
	}
}
					
			

	
	// Update is called once per frame
	

