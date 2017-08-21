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
            atoms[i] = Instantiate(prefab, new Vector3(-10000, -10000), Quaternion.identity);
            Atom atom = atoms[i].GetComponent<Atom>();
            int protons = Random.Range(1, 10);
            if(protons == 9) {
                protons = 99;
            }
            //do {
                atoms[i].transform.position = new Vector2(Random.Range(MasterHandler.playArea.edges.left, MasterHandler.playArea.edges.right), Random.Range(MasterHandler.playArea.edges.bottom, MasterHandler.playArea.edges.top));
            //} while (Vector3.Distance(atoms[i].transform.position, player.transform.position) < 4);
            atom.init(protons);
        }
	}
	
	void Update () {
		
	}
}
