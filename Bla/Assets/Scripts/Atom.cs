using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour {
	public int protons = 5;
	public int electrons;
	public float stability;
	private float maxStability;

    private Rigidbody2D rb2D;

    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        electrons = protons;
        maxStability = 1 - 0.03f * protons;

        //Set atom sprite

        //set atom size
	}

	void Update () {
        //Update stability
        if (protons == electrons) {
            stability = Mathf.Clamp(stability + (1f * Time.deltaTime), 0, maxStability);
        } else {
            stability = Mathf.Clamp(stability - ((1f + 0.4f * Mathf.Abs(protons - electrons)) * Time.deltaTime), 0, maxStability);
        }
	}

	public void move (Vector2 direction) {
        //Decrease movespeed with scale
        rb2D.MovePosition(rb2D.transform.position + (Vector3)direction);
    }

    public GameObject electronPrefab;
    public void shoot(Vector2 direction) {
        GameObject electron = Instantiate(electronPrefab);
        
    }
}
