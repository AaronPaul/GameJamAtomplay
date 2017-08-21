using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronRotator : MonoBehaviour {
    Atom atom;
    GameObject rotator;
    GameObject electronPrefab;

    public void Awake() {
        atom = GetComponent<Atom>();
        rotator = new GameObject();
        rotator.name = "RotationParent";
        rotator.transform.SetParent(atom.transform);
        rotator.transform.localPosition = new Vector2(0,0);
        electronPrefab = Resources.Load<GameObject>("Prefabs/ElectronRotate");
        updateElectrons();
    }

    public void Update() {
        rotator.transform.Rotate(Vector3.forward, 180 * Time.deltaTime);
    }

    public void updateElectrons() {
        int childCount = rotator.transform.childCount;
        int electronCount = atom.electronCount();
        
        if (electronCount < childCount) {
            for (int i = 0; i < childCount - electronCount; i++) {
                GameObject child = rotator.transform.GetChild(i).gameObject;
                child.transform.SetParent(null);
                Destroy(child);
            }
        } else if (electronCount > childCount) {
            for(int i = 0; i < electronCount - childCount; i++) {
                GameObject electron = Instantiate(electronPrefab);
                electron.transform.SetParent(rotator.transform);
            }
        }

        //Update positions
        if(electronCount > 0) {
            float space = 360 / electronCount;
            Debug.Log(space);
            for (int i = 0; i < electronCount; i++) {
                rotator.transform.GetChild(i).transform.localPosition = new Vector2(Mathf.Cos(Mathf.Deg2Rad * space * i), Mathf.Sin(Mathf.Deg2Rad * space * i));
            }
        }
    }
}
