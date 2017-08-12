using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Elements {
    public static string getElementName(int id) {
        if(System.Enum.IsDefined(typeof(Element), id)) {
            return ((Element)id).ToString();
        } else {
            return "";
        }
    }
}

public enum Element {
    Wasserstoff = 1,
    Helium = 2,
    Lithium = 3,
    Beryllium = 4
}
