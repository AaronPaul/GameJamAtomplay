using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothCamera : MonoBehaviour {
    Vector2 velocity = Vector2.zero;
	
	void FixedUpdate () {
        Vector3 newPos = Vector2.SmoothDamp(transform.position, MasterHandler.Player.transform.position, ref velocity, 0.05f, 100, Time.fixedDeltaTime);
        newPos.z = -10;
        transform.position = newPos;
	}
}
