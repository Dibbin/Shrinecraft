using UnityEngine;
using System.Collections.Generic;

public class PlayerInputManager : MonoBehaviour {


    private GodPowerButton currentPower = null;
    private God playerGod;
    private GameObject terrain;
    private Dictionary<string, GodPower> godPowerDictionary;

    public void Start()
    {
        godPowerDictionary = new Dictionary<string, GodPower>()
        {
            { "Fire", new GodPowerFire()},
            { "SummonShrine", new GodPowerSummonShrine()},
            {"Sacrifice",new GodPowerSacrifice()  }
        };

        playerGod = GameObject.Find("Player1").GetComponent<God>();
        terrain = GameObject.Find("landscape_MAP");
    }


    public void setCurrentPower(GodPowerButton nextPower)
    {
        if (currentPower != nextPower)
        {
            if (currentPower)
            {
                currentPower.clearHighlight();
            }


            GodPower thePower = godPowerDictionary[nextPower.buttonId];
            var powerCost = thePower.getEnergyCost();

            if (playerGod.energy > powerCost) { 
                currentPower = nextPower;
                nextPower.highlight();
            }
        }
    }

    public void handleTerrainClick()
    {
        if (currentPower && godPowerDictionary[currentPower.buttonId].canUsePowerOnMap()){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (terrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                GodPower thePower = godPowerDictionary[currentPower.buttonId];
                thePower.usePowerOnMap(hit.point, playerGod);
                playerGod.energy -= thePower.getEnergyCost();

                clearCurrentPowerSelection();
            }
        }

    }

    public void handleShrineClick(Shrine shrine)
    {

        if (currentPower && godPowerDictionary[currentPower.buttonId].canUsePowerOnShrine())
        {
            GodPower thePower = godPowerDictionary[currentPower.buttonId];
            thePower.usePowerOnShrine(shrine, playerGod);
            playerGod.energy -= thePower.getEnergyCost();
            clearCurrentPowerSelection();
        }
        
    }

    private void clearCurrentPowerSelection()
    {
        if (currentPower)
        {

            currentPower.clearHighlight();
            currentPower = null;
        }
    }
    
}
