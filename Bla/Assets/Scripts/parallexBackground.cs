using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallexBackground : MonoBehaviour {
    Transform player;
    void Start() {
        player = MasterHandler.Player.transform;
    }

    void FixedUpdate () {
        transform.position = player.position / 5 + new Vector3(0,0,1);
	}
}
