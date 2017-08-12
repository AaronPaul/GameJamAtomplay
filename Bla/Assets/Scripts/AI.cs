using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    private Atom atom;

	// Use this for initialization
	void Start () {
        atom = GetComponent<Atom>();

        nextShootTime = Time.time + Random.Range(3f, 30f);
        nextPostionTime = Time.time;
        nextSpeedTime = Time.time;
	}


    private float nextPostionTime;
    private float nextShootTime;
    private float nextSpeedTime;

    private float speed;
    private Vector2 posToGo;

    // Update is called once per frame
    void FixedUpdate() {
        if (Time.time > nextPostionTime || Vector2.Distance((Vector2)transform.position, posToGo) < 0.2f) {
            posToGo = new Vector2(Random.Range(MasterHandler.playArea.edges.left, MasterHandler.playArea.edges.right), Random.Range(MasterHandler.playArea.edges.bottom, MasterHandler.playArea.edges.top));
            nextPostionTime = Time.time + Random.Range(1f, 6f);
        }

        if(Time.time > nextShootTime) {
            //Shoot
            nextShootTime = Time.time + Random.Range(3f,30f);
        }

        if (Time.time > nextSpeedTime) {
            speed = Random.Range(0.1f, 1f);
            nextSpeedTime = Time.time + Random.Range(0.5f, 4f);
        }

        atom.move(Vector2.ClampMagnitude(posToGo - (Vector2) transform.position, speed));
	}
}
