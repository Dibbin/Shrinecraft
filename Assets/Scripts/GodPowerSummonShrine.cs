using UnityEngine;
using System.Collections;

public class GodPowerSummonShrine : GodPower
{

    public float energyCost = 20;

    public float getEnergyCost()
    {
        return energyCost;
    }

    public bool canUsePowerOnMap()
    {
        return true;
    }

    public bool canUsePowerOnShrine()
    {
        return false;
    }

    public void usePowerOnMap()
    {
        //do nothing
        Debug.Log("Using summon shrine power on map!");
    }

    public void usePowerOnShrine(Shrine s)
    {
        //do nothing
    }
}
