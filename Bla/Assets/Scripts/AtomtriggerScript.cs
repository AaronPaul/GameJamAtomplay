﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomtriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider Col)
    {
        if (Col.GetComponent<Electron>() != null)
        {
            
        }
    }
}
