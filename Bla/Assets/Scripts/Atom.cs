using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour {
	public int protons = 5;
	public int electrons;
	public float stability;
	private float maxStability;
    public float radius;

    private Rigidbody rb2D;
    bool initialized = false;

    public void init() {
        rb2D = GetComponent<Rigidbody>();
        electrons = protons;
        maxStability = 1 - 0.03f * protons;

        //Set atom sprite
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Elements.getElementName(protons));

        //set atom size
        transform.localScale = new Vector2(1 + 0.2f * protons, 1 + 0.2f * protons);
        //Update collider
        radius = (1 + 0.2f * protons) / 4;
        GetComponent<SphereCollider>().radius = radius;
        initialized = true;
    }

	void Update () {
        if(!initialized) {
            return;
        }
        //Update stability
        if (protons == electrons) {
            stability = Mathf.Clamp(stability + (0.5f * (1f * Time.deltaTime)), 0, maxStability);
        } else {
            stability = Mathf.Clamp(stability - (0.5f * ((1f + 0.4f * Mathf.Abs(protons - electrons))) * Time.deltaTime), 0, maxStability);
        }

        if (stability == 0) {
            if(GetComponent<PlayerController>() == null) {
                Destroy(gameObject);
            }
        }
	}

    public void move(Vector2 direction) {
        //Decrease movespeed with scale
        Vector3 newPos = rb2D.transform.position + ((Vector3)direction * 0.6f);
        newPos = new Vector2(Mathf.Clamp(newPos.x, MasterHandler.playArea.edges.left, MasterHandler.playArea.edges.right), Mathf.Clamp(newPos.y, MasterHandler.playArea.edges.bottom, MasterHandler.playArea.edges.top));
        rb2D.MovePosition(newPos);
    }

    public GameObject electronPrefab;
    public void shoot(Vector2 direction) {
        if (direction != Vector2.zero && electrons > 0) {
            electrons--;
            GameObject electron = Instantiate(electronPrefab);
            electron.transform.position = (Vector2)(transform.position + (Vector3.Normalize(direction) * ((radius * 2f) + 0.25f)));
            electron.GetComponent<Electron>().init(direction);
        }
    }
}
