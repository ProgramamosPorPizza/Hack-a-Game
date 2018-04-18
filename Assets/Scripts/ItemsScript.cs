using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsScript : MonoBehaviour {
    public int matches;

	// Use this for initialization
	void Start () {
        this.matches = 0;
	}

    public int getLista()
    {
        return this.matches;
    }
}
