using UnityEngine;
using System.Collections;
using System.Text;
using UnityEditor;

public class GodPowerSummonShrine : GodPower
{

    public float energyCost = 20;

    private GameObject terrain = GameObject.Find("pPlane3");
    private Level level = GameObject.Find("LevelManager").GetComponent<Level>();
    private GameObject variableForPrefab = Resources.Load("prefabs/shrine") as GameObject;


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

    public void usePowerOnMap(Vector3 point, God godUsingPower)
    {
        //do nothing
        Debug.Log("Using summon shrine power on map!");
            
        var newShrineObj = (GameObject) Object.Instantiate(variableForPrefab, point, Quaternion.Euler(0, Random.Range(0, 360.0f), 0));
        var newShrine = newShrineObj.GetComponent<Shrine>();
        newShrine.god = godUsingPower;

        level.AddShrine(newShrine.GetComponent<Shrine>());
    }

    public void usePowerOnShrine(Shrine s, God godUsingPower)
    {
        //do nothing
    }
}
