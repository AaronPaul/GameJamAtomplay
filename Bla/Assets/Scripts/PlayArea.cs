using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea {
    public Vector2 center;
    public Vector2 size;
    public Edges edges;

    public PlayArea(Vector2 _center, Vector2 _size) {
        center = _center;
        size = _size;
        edges = new Edges(center, size);
    }
}
