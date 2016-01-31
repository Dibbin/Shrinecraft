using UnityEngine;
using System.Collections.Generic;

public class PlayerInputManager : MonoBehaviour {


    private GodPowerButton currentPower = null;
    private God playerGod;

    private Dictionary<string, GodPower> godPowerDictionary;

    public void Start()
    {
        godPowerDictionary = new Dictionary<string, GodPower>()
        {
            { "Fire", new GodPowerFire()},
            { "SummonShrine", new GodPowerSummonShrine()}
        };

        playerGod = GameObject.Find("Player1").GetComponent<God>();
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
            GodPower thePower = godPowerDictionary[currentPower.buttonId];
            thePower.usePowerOnMap();
            playerGod.energy -= thePower.getEnergyCost();
            
        }

        clearCurrentPowerSelection();
    }

    public void handleShrineClick(Shrine shrine)
    {

        if (currentPower && godPowerDictionary[currentPower.buttonId].canUsePowerOnShrine())
        {
            GodPower thePower = godPowerDictionary[currentPower.buttonId];
            thePower.usePowerOnShrine(shrine);
            playerGod.energy -= thePower.getEnergyCost();
        }
        
        clearCurrentPowerSelection();
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
