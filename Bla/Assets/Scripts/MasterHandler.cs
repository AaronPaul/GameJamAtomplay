using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MasterHandler : MonoBehaviour {
    public static PlayArea playArea;
    public static GameObject Player;

    public void Start() {
        Player = GameObject.Find("Player");
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        playArea = new PlayArea(new Vector2(0, 0), new Vector2(collider.bounds.size.x, collider.bounds.size.y));
    }
}
