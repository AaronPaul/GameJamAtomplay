using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronManager : MonoBehaviour
{
    Atom atom;
    List<GameObject> atomElectrons = new List<GameObject>();
    public GameObject electronPrefab;
    float distance = 5;
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
        float targetNumberOfElectrons = atom.electrons;
        float numberOfSpawnnedElectron = atomElectrons.Count;
        if (numberOfSpawnnedElectron == targetNumberOfElectrons)
        {
            return;
        }
        float angle = 360 / targetNumberOfElectrons;
        if (targetNumberOfElectrons > numberOfSpawnnedElectron)
        {
            if (numberOfSpawnnedElectron == 0)
            {
                for (int i = 0; i < atom.electrons; i++)
                {
                    GameObject electron = (GameObject)Instantiate(electronPrefab, transform.position, Quaternion.identity, transform);
                    var q = Quaternion.AngleAxis(angle * i, Vector3.forward);
                    Vector3 currentPos = transform.position;
                    electron.transform.position = currentPos + q * Vector3.right * distance;
                    electron.transform.localScale = electron.transform.localScale / atom.transform.localScale.x;
                    atomElectrons.Add(electron);
                }

            }
            else
            {
                float count = numberOfSpawnnedElectron - atomElectrons.Count;
                for (int i = 0; i < count; i++)
                {
                    GameObject electron = (GameObject)Instantiate(electronPrefab, transform.position, Quaternion.identity, transform);
                    var q = Quaternion.AngleAxis(angle * i, Vector3.forward);
                    Vector3 currentPos = transform.position;
                    electron.transform.position = currentPos + q * Vector3.right * distance;
                    electron.transform.localScale = electron.transform.localScale / atom.transform.localScale.x;
                    atomElectrons.Add(electron);
                }
            }
            
        }
        else
        {
            KillItem electronKill = atomElectrons[0].GetComponent<KillItem>();
            electronKill.KillObject();
            atomElectrons.Remove(atomElectrons[0]);
            for (int i = 0; i < targetNumberOfElectrons; i++)
            {
                var q = Quaternion.AngleAxis(angle * i, Vector3.forward);
                Vector3 currentPos = transform.position;
                atomElectrons[i].transform.position = currentPos + q * Vector3.right * distance;
            }
        }
        
    }
}
