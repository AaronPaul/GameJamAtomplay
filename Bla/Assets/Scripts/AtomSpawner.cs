using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomSpawner : MonoBehaviour {
    static int count = 10;
    private GameObject[] atoms;
    public GameObject prefab;

    void Start () {
        atoms = new GameObject[count];
        for (int i = 0; i < count; i++) {
            atoms[i] = Instantiate(prefab);
            Atom atom = atoms[i].GetComponent<Atom>();
            atom.protons = Random.Range(1, 9);
        }
	}
	
	void Update () {
		
	}
}
