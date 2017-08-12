using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronSpawner : MonoBehaviour {
    private float timeNextSpawn;

	// Use this for initialization
	void Start () {
        timeNextSpawn = Time.time;
	}

    public GameObject electronPrefab;
	void Update () {
        if (Time.time > timeNextSpawn) {
            GameObject electron = Instantiate(electronPrefab);
            switch (Random.Range(0, 4)) {
                case 0: //Top
                    electron.transform.position = new Vector2(Random.Range(MasterHandler.playArea.edges.left, MasterHandler.playArea.edges.right), MasterHandler.playArea.edges.top);
                    break;
                case 1: //Bottom
                    electron.transform.position = new Vector2(Random.Range(MasterHandler.playArea.edges.left, MasterHandler.playArea.edges.right), MasterHandler.playArea.edges.bottom);
                    break;
                case 2: //Left
                    electron.transform.position = new Vector2(MasterHandler.playArea.edges.left, Random.Range(MasterHandler.playArea.edges.bottom, MasterHandler.playArea.edges.top));
                    break;
                case 3: //Right
                    electron.transform.position = new Vector2(MasterHandler.playArea.edges.right, Random.Range(MasterHandler.playArea.edges.bottom, MasterHandler.playArea.edges.top));
                    break;
            }
            Vector2 direction = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward) * Vector3.right;
            electron.GetComponent<Electron>().init(direction);
            timeNextSpawn = Time.time + Random.Range(0.2f, 1f);
        }
	}
}
