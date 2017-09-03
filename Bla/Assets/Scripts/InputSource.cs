using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InputSource {
    Vector2 moveAxis();

    Vector2 shootAxis();

    bool shoot();
}

public class inputKeyboard : InputSource {
    public Vector2 moveAxis() {
        return Vector2.ClampMagnitude(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), 1f);
    }

    public Vector2 shootAxis() {
        //Else get mouse input
        return (Input.mousePosition - Camera.main.WorldToScreenPoint(MasterHandler.Player.transform.position)).normalized;
    }

    public bool shoot() {
        return (Input.GetAxisRaw("Fire") == 1 || Input.GetMouseButtonDown(0));
    }
}

public class inputJoystick : InputSource {
    public Vector2 moveAxis() {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public Vector2 shootAxis() {
        return new Vector2(Input.GetAxis("HorizontalView"), Input.GetAxis("VerticalView"));
    }

    public bool shoot() {
        return Input.GetAxis("Fire") > 0.5f;
    }
}

public class inputMobile : InputSource {
    private MobileInput leftStick;
    private MobileInput rightStick;

    public inputMobile() {
        GameObject mobileInput = GameObject.Find("MobileInput");
        if (mobileInput == null || mobileInput.GetComponentsInChildren<MobileInput>().Length != 2) {
            Debug.LogError("Error with mobile input. No joysitcks found");
            return;
        }

        leftStick = mobileInput.GetComponentsInChildren<MobileInput>()[0];
        rightStick = mobileInput.GetComponentsInChildren<MobileInput>()[1];
    }

    public Vector2 moveAxis() {
        return leftStick.angle;
    }

    public Vector2 shootAxis() {
        return rightStick.angle;
    }

    public bool shoot() {
        return rightStick.strength > 0.5f;
    }
}
