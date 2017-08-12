using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronManager : MonoBehaviour
{
    public int numberOfElectrons = 0;
    Atom atom;
	// Use this for initialization
	void Start ()
    {
        atom = transform.parent.GetComponent<Atom>();
        if(atom == null)
        {
            Debug.Log("Atom script not found in Parent Object. Make Certain that the parent Object is the Atom", gameObject);
        }
        numberOfElectrons = atom.electrons;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (numberOfElectrons != atom.electrons)
        {
            
        }
	}
}
