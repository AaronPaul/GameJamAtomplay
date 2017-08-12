using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronRotation : MonoBehaviour {
    Atom parentAtom;
    // Use this for initialization
    void Start() {
        parentAtom = transform.parent.GetComponent<Atom>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int electronnumber = parentAtom.electrons;
        if (electronnumber == 0)
        {
            return;
        }
        float angle = 360 / electronnumber; 
        transform.Rotate(Vector3.forward,angle * Time.deltaTime);
    }
}
