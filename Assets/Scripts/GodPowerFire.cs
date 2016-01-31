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

    public void usePowerOnMap()
    {
        //do nothing
    }

    public void usePowerOnShrine(Shrine s)
    {
        Debug.Log("Using fire power on Shrine!");
        s.burner();
        shrineLoc = s.transform.position;
        curShrine = s;
        // Object.Instantiate((Resources.Load("GodFire")).burner()) as GodPowerFire;
       // this.burner();
    }


    /*
    public void burner()   //controls the killing when fire attack is used. 
    {
        if (isBurning == false)
        {
           
          // Object.Instantiate(Resources.Load("fire"), shrineLoc, Quaternion.identity);
            
        }
       int totalPop = curShrine.followers;
        totalPop -= 2;
        curShrine.followers = totalPop;
        isBurning = true;
        if (cycles != 0)
        {
            cycles--;
            Invoke("burner", delay);
        }
        else
        {
            Destroy(this);
        }
        


    }
    */
}
