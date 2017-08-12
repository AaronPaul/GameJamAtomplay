using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomSpawner : MonoBehaviour {
    static int count = 10;
    private GameObject[] atoms;
    public GameObject prefab;
    private GameObject player;

    void Start () {
        player = GameObject.Find("Player");
        atoms = new GameObject[count];
        for (int i = 0; i < count; i++) {
            atoms[i] = Instantiate(prefab);
            Atom atom = atoms[i].GetComponent<Atom>();
            atom.protons = Random.Range(1, 10);
            if(atom.protons == 9) {
                atom.protons = 99;
            }
            do {
                atoms[i].transform.position = new Vector2(Random.Range(MasterHandler.playArea.edges.left, MasterHandler.playArea.edges.right), Random.Range(MasterHandler.playArea.edges.bottom, MasterHandler.playArea.edges.top));
            } while (Vector3.Distance(atoms[i].transform.position, player.transform.position) < 2);
            atom.init();
        }
	}
	
	void Update () {
		
	}
}
