using UnityEngine;
using System.Collections;

public class GodPowerFire : GodPower {


    public bool canUsePowerOnMap()
    {
        return false;
    }

    public bool canUsePowerOnShrine()
    {
        return true;
    }

    public void usePowerOnMap()
    {
        //do nothing
    }

    public void usePowerOnShrine(Shrine s)
    {
        Debug.Log("Using fire power on Shrine!");
    }
}
