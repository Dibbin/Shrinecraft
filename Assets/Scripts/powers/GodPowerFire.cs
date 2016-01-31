using UnityEngine;
using System.Collections;

public class GodPowerFire :  MonoBehaviour, GodPower
{


    public GameObject fire;
    bool isBurning=false;
    Shrine curShrine;
    public float delay;
    Vector3 shrineLoc;
    public  int cycles = 3;
    public float energyCost = 30;

    public float getEnergyCost()
    {
        return energyCost;
    }
    public bool canUsePowerOnMap()
    {
        return false;
    }

    public bool canUsePowerOnShrine()
    {
        return true;
    }

    public void usePowerOnMap(Vector3 point, God godUsingPower)
    {
        //do nothing
    }

    public void usePowerOnShrine(Shrine s, God godUsingPower)
    {
        Debug.Log("Using fire power on Shrine!");
        s.cycles = 5;
        s.delay = 2.0f;
        s.burner();
        shrineLoc = s.transform.position;
        curShrine = s;
        // Object.Instantiate((Resources.Load("GodFire")).burner()) as GodPowerFire;
       // this.burner();
    }


   
}
