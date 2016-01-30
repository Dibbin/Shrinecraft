using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GodPowerButton : MonoBehaviour {

    public string buttonId = "Fire";
    public Color selectedColor = Color.red;
    private PlayerInputManager playerInput;

    void Start()
    {
        playerInput = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerInputManager>();
    }

    public void handleMouseClick()
    {
        Debug.Log(string.Format( buttonId + " button pushed!", buttonId));
        playerInput.setCurrentPower(this);
    }

    public void highlight()
    {
        gameObject.GetComponent<Image>().color = selectedColor;
    }

    public void clearHighlight()
    {
        gameObject.GetComponent<Image>().color = Color.white;
    }
}
