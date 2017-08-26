using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour {
	private int protons = 5;
	private int electrons;
	public float stability;
	private float maxStability;
    public float radius;

    private Rigidbody2D rb2D;
    bool initialized = false;

    private ElectronRotator rotator;

    public void init(int _protons = 5) {
        protons = _protons;
        electrons = protons;
        rb2D = GetComponent<Rigidbody2D>();
        rotator = gameObject.AddComponent<ElectronRotator>();
        maxStability = 1 - 0.03f * protons;

        //Set atom sprite
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Elements.getElementName(protons));

        //set atom size
        transform.localScale = new Vector2(1 + 0.2f * protons, 1 + 0.2f * protons);
        //Update collider
        radius = 0.25f;
        GetComponent<CircleCollider2D>().radius = radius;
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
        Debug.Log(direction);
        //Decrease movespeed with scale
        Vector3 newPos = rb2D.transform.position + ((Vector3)direction * 0.6f);
        newPos = new Vector2(Mathf.Clamp(newPos.x, MasterHandler.playArea.edges.left, MasterHandler.playArea.edges.right), Mathf.Clamp(newPos.y, MasterHandler.playArea.edges.bottom, MasterHandler.playArea.edges.top));
        Debug.Log(newPos);
        Debug.Log(rb2D.transform.position);
        rb2D.MovePosition(newPos);
    }

    public GameObject electronPrefab;
    public void shoot(Vector2 direction) {
        if (direction != Vector2.zero && electrons > 0) {
            removeElectron();
            GameObject electron = Instantiate(electronPrefab);
            electron.transform.position = (Vector2)(transform.position + (Vector3.Normalize(direction) * ((1 + 0.2f * protons) / 2 + 0.3f)));
            electron.GetComponent<Electron>().init(direction);
        }
    }

    public void addElectron() {
        electrons++;
        rotator.updateElectrons();
    }

    public void removeElectron() {
        electrons--;
        rotator.updateElectrons();
    }

    public int electronCount() {
        return electrons;
    }
}
