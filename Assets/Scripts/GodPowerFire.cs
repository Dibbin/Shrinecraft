﻿using UnityEngine;
using System.Collections;

<<<<<<< HEAD

=======
>>>>>>> origin/master
public class GodPowerFire : GodPower {


    public GameObject fire;
    bool isBurning=false;
    Shrine curShrine;
    public float delay;
    Vector3 shrineLoc;
  public  int cycles = 3;

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
<<<<<<< HEAD
        shrineLoc = s.transform.position;
        curShrine = s;
        burner();
    }

    public void burner()   //controls the killing when fire attack is used. 
    {
        if (isBurning == false)
        {
           
            Instantiate(fire, shrineLoc, Quaternion.identity);
            
        }
       int totalPop = curShrine.followers;
        totalPop -= 2;
        curShrine.followers = totalPop;
        isBurning = true;
        if (cycles != 0)
        {
            Invoke("burner", delay);
        }


    }

=======
    }
>>>>>>> origin/master
}
