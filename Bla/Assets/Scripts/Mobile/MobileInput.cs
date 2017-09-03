using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MobileInput : MonoBehaviour {
    public Vector2 angle { get; private set; }
    public bool pressed { get; private set; }

    public float strength { get; private set; }

    public float size = 15;

    Vector2 cursorPosStart;
    public void mouseDown(BaseEventData data) {
        //Todo more accurate start
        PointerEventData pointerData = data as PointerEventData;
        transform.position = pointerData.position;
        transform.localPosition = Vector2.ClampMagnitude(transform.localPosition, size);
        pressed = true;
        angle = transform.localPosition / size;
        strength = angle.magnitude;
    }

    public void mouseUp() {
        transform.localPosition = Vector2.zero;
        pressed = false;
        angle = Vector2.zero;
        strength = 0;
    }
}