using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomtriggerScript : MonoBehaviour {
    Atom atomScript;
	// Use this for initialization
	void Start () {
        transform.GetComponent<Atom>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider Col)
    {
        if (Col.GetComponent<Electron>() != null)
        {
            atomScript.electrons++;
            print("yay");
        }
    }
}
