using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Atom atom;
	// Use this for initialization
	void Start () {
        atom = GetComponent<Atom>();
	}
	
	// Update is called once per frame
	void Update () {
        atom.move(new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

    }
}
