using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stability {
    ///SetStability
    ///color form blue to red
    ///if nearly full fade out
    ///
    /// 

    GameObject hudBackground;
    GameObject hudBar;
    RectTransform hudBackgroundTransform;
    RectTransform hudBarTransform;

    float maxStability;

    Gradient gradient;

    public Stability(GameObject atomObject, float _maxStability) {
        maxStability = _maxStability;
        //Create HUD elements
        GameObject prefab = Resources.Load<GameObject>("Prefabs/StabilityHUD");
        GameObject parent = GameObject.Find("Stability");

        hudBackground = GameObject.Instantiate(prefab);
        hudBackground.transform.SetParent(parent.transform);
        hudBar = hudBackground.transform.GetChild(0).gameObject;

        hudBackgroundTransform = hudBackground.GetComponent<RectTransform>();
        hudBarTransform = hudBar.GetComponent<RectTransform>();

        gradient = new Gradient();
        GradientColorKey[] colorKey = new GradientColorKey[2];
        GradientAlphaKey[] alphaKey = new GradientAlphaKey[2];

        ColorUtility.TryParseHtmlString("#FF0000FF", out colorKey[0].color);
        colorKey[0].time = 0;
        ColorUtility.TryParseHtmlString("#098FFFFF", out colorKey[1].color);
        colorKey[1].time = maxStability;

        alphaKey[0].alpha = 1;
        alphaKey[1].alpha = 1;
        alphaKey[0].time = 0;
        alphaKey[1].time = maxStability;

        gradient.SetKeys(colorKey, alphaKey);
    }

    public void setStability(float stability) {
        hudBarTransform.offsetMax = new Vector2(-46 + (stability / maxStability) * 44,-2);
        hudBar.GetComponent<Image>().color = gradient.Evaluate(stability);
    }

    public void updatePos(Vector2 playerPos) {
        hudBackgroundTransform.position = Camera.main.WorldToScreenPoint(playerPos) + new Vector3(0,30,0);
    }

    public void destroy() {
        GameObject.Destroy(hudBar);
        GameObject.Destroy(hudBackground);
    }
}

