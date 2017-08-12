using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Atom atom;
	// Use this for initialization
	void Start () {
        atom = GetComponent<Atom>();
        atom.init();
	}

    private bool fire = false;
    // Update is called once per frame
    void FixedUpdate() {
        atom.move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        if (!fire && Input.GetAxis("Fire") > 0.5f) {
            //Fire
            fire = true;
            atom.shoot(new Vector2(Input.GetAxis("HorizontalView"), Input.GetAxis("VerticalView")));
        } 

        if (Input.GetAxis("Fire") < 0.5f) {
            fire = false;
        }
    }
}
