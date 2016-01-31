using UnityEngine;
using System.Collections;
using System;

public class GodPowerSacrifice : MonoBehaviour, GodPower {
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
        return 10.0f;
    }

    public void usePowerOnMap(Vector3 point, God godUsingPower)
    {
        //nop;
    }

    public void usePowerOnShrine(Shrine s, God user)
    {
        s.followers--;
        user.energy += 5;
        if(s.screamer) s.screamer.Play();
    }
}
