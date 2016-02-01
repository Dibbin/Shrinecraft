using UnityEngine;
using System.Collections;
using System;

public class GodPowerRain : GodPower
{
    public bool canUsePowerOnMap()
    {
        return false;
    }

    public bool canUsePowerOnShrine()
    {
        return true;
    }

    public float getEnergyCost()
    {
        return 8.0f;
    }

    public void usePowerOnMap(Vector3 point, God godUsingPower)
    {
        //nop;
    }

    public void usePowerOnShrine(Shrine s, God user)
    {
        s.food += 1;
        s.water += 1;   
    }
}
