using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonClicked(Button b) {
		SenseTextController t = b.transform.GetChild (0).GetComponent<SenseTextController>();
		t.ShowHint ();
	}

}
