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
            electron.transform.position = new Vector2(100,100);
            Vector2 direction = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward) * Vector3.right;
            electron.GetComponent<Electron>().init(direction);
            timeNextSpawn = Time.time;
        }
	}
}
