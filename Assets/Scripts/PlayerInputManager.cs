using UnityEngine;
using System.Collections.Generic;

public class PlayerInputManager : MonoBehaviour {


    private GodPowerButton currentPower = null;

    private Dictionary<string, GodPower> godPowerDictionary;

    public void Start()
    {
        godPowerDictionary = new Dictionary<string, GodPower>()
        {
            { "Fire", new GodPowerFire()}
        };
    }


    public void setCurrentPower(GodPowerButton nextPower)
    {
        if (currentPower != nextPower)
        {
            if (currentPower)
            {
                currentPower.clearHighlight();
            }
            currentPower = nextPower;
            nextPower.highlight();
        }
    }

    public void handleTerrainClick()
    {
        if (currentPower && godPowerDictionary[currentPower.buttonId].canUsePowerOnMap()){
            godPowerDictionary[currentPower.buttonId].usePowerOnMap();
        }

        clearCurrentPowerSelection();
    }

    public void handleShrineClick(Shrine shrine)
    {

        if (currentPower && godPowerDictionary[currentPower.buttonId].canUsePowerOnShrine())
        {
            godPowerDictionary[currentPower.buttonId].usePowerOnShrine(shrine);
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
