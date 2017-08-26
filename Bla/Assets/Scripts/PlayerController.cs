using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Atom atom;
    GameObject shootDirection;
	// Use this for initialization
	void Start () {
        atom = GetComponent<Atom>();
        atom.init();
        shootDirection = createShootDirection();
	}

    private bool fire = false;
    // Update is called once per frame
    void FixedUpdate() {
        atom.move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }

    void Update() {
        Vector2 input = new Vector2(Input.GetAxis("HorizontalView"), Input.GetAxis("VerticalView"));

        if (Mathf.Abs(input.x) < 0.3f && Mathf.Abs(input.y) < 0.3f) {
            shootDirection.GetComponent<LineRenderer>().widthMultiplier = 0;
        } else {
            shootDirection.GetComponent<LineRenderer>().widthMultiplier = 0.1f;
            shootDirection.transform.localEulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, input));
        }

        if (!fire && Input.GetAxis("Fire") > 0.5f) {
            //Fire
            fire = true;
            atom.shoot(input);
        }

        if (Input.GetAxis("Fire") < 0.5f) {
            fire = false;
        }
    }

    private GameObject createShootDirection() {
        GameObject lineObject = new GameObject("Shoot Direction");
        lineObject.transform.SetParent(transform);
        lineObject.transform.localScale = new Vector2(1,1);
        lineObject.transform.localPosition = new Vector3(0,0,10);
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(new Vector3[] {new Vector3(0,1,-1), new Vector3(0,2,-1)});
        lineRenderer.material = Resources.Load<Material>("ShootDirection");

        return lineObject;
    }
}
