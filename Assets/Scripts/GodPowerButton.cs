using UnityEngine;
using System.Collections;

public class GodPowerButton : MonoBehaviour {

    public string buttonId = "Fire";

    public void handleMouseClick()
    {
        Debug.Log(string.Format( buttonId + " button pushed!", buttonId));
    }
}
