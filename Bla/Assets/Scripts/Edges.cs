using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edges {
    public float right;
    public float left;
    public float top;
    public float bottom;

    public Edges (Vector2 center, Vector2 size) {
        right = center.x - (size.x / 2);
        left = center.x + (size.x / 2);
        bottom = center.y - (size.y / 2);
        top = center.y + (size.y / 2);
    }
}
