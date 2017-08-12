﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronManager : MonoBehaviour
{
    Atom atom;
    List<GameObject> atomElectrons = new List<GameObject>();
    public GameObject electronPrefab;
    float distance = 10;
	// Use this for initialization
	void Start ()
    {
        atom = transform.parent.GetComponent<Atom>();
        if(atom == null)
        {
            Debug.Log("Atom script not found in Parent Object. Make Certain that the parent Object is the Atom", gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        float numberOfSpawnnedElectron = atomElectrons.Count;
        if (numberOfSpawnnedElectron == atom.electrons)
        {
            return;
        }
        float angle = 360 / numberOfSpawnnedElectron;
        if (atom.electrons > numberOfSpawnnedElectron)
        {
            if (numberOfSpawnnedElectron == 0)
            {
                print(atomElectrons.Count);
                for (int i = 0; i < atomElectrons.Count; i++)
                {
                    GameObject electron = (GameObject)Instantiate(electronPrefab, transform.position, Quaternion.identity, transform);
                    var q = Quaternion.AngleAxis(angle, Vector3.forward);
                    Vector3 currentPos = transform.position;
                    electron.transform.position = currentPos + q * Vector3.right * distance;
                    atomElectrons.Add(electron);
                }
            }
            else
            {
                float count = numberOfSpawnnedElectron - atomElectrons.Count;
                for (int i = 0; i < count; i++)
                {
                    GameObject electron = (GameObject)Instantiate(electronPrefab, transform.position, Quaternion.identity, transform);
                    atomElectrons.Add(electron);
                }
            }
            
        }
        else
        {
            atomElectrons.Remove(atomElectrons[0]);

        }
    }
}