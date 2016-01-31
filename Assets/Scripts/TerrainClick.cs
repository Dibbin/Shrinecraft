using UnityEngine;
using System.Collections;

public class TerrainClick : MonoBehaviour {
    
    private PlayerInputManager playerInput;

    void Start()
    {
        playerInput = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerInputManager>();
    }

    void OnMouseDown()
    {
        Debug.Log("terrain clicked!");
        playerInput.handleTerrainClick();
    }



}
