using UnityEngine;
using System.Collections;

public class GodPowerButton : MonoBehaviour {

    public string buttonId = "Fire";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void handleMouseClick()
    {
        Debug.Log(string.Format( buttonId +" button pushed!", buttonId));
    }
}
