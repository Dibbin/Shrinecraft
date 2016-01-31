using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GodController : MonoBehaviour {

    public God enemy;
    float energy;
    int choice;
    int followers;
    Vector3 randLoc;
    public Level level;
    private Dictionary<string, GodPower> godPowerDictionary;
    private God playerGod;
    void Start () {
        playerGod = GameObject.Find("Player1").GetComponent<God>();
        energy = enemy.energy;
        followers = enemy.followers;
        level = GameObject.Find("LevelManager").GetComponent<Level>();
        godPowerDictionary = new Dictionary<string, GodPower>()
        {
            { "Fire", new GodPowerFire()},
            { "SummonShrine", new GodPowerSummonShrine()}

        };


    }
	void setRandom()
    {
        choice =  Random.Range(0,0);//set to length of dictionary

    }
    void runPower(int i)
    {
        GodPower thePower=null;
        switch (i)
        {
            case 0:
                 thePower = godPowerDictionary["Fire"];
                List<Shrine> shrines;
                shrines = (level.GetShrinesByGod(playerGod));
                int size = shrines.Count;
                int sel = Random.Range(0, size);
                thePower.usePowerOnShrine(shrines[sel], enemy);
                break;

            case 1:
                 thePower = godPowerDictionary["SummonShrine"];
                thePower.usePowerOnMap(randLoc, enemy);

                break;
            default:

                break;
        }
    }
    void run()
    {
        runPower(choice);
    }
	
	void Update () {
        Invoke("setRandom", 2.0f);//changes its mind
        Invoke("run", 2.0f);     //runs what it wants to do, if it has energy.



	}
}
