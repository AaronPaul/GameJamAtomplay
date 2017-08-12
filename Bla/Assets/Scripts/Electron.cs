using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : MonoBehaviour
{
    public float velocity = 1f;
    public Vector3 direction = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}

    public void init(Vector2 direction) {

    }
	
	// Update is called once per frame
	void Update () {
        if (direction == Vector3.zero)
        {
            return;
        }
        Vector3 targetdirection = transform.position + direction;
        transform.position = Vector3.Lerp(transform.position, targetdirection, velocity * Time.deltaTime);
		//Move to direction
	}
}
