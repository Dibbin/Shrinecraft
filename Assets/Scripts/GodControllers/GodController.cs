using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GodController : MonoBehaviour {

    private God enemy;
    float energy;
    int choice;
    List<Shrine> shrines;
    private GameObject terrain;
    int followers;
    Vector3 randLoc;
    private Level level;
    private Dictionary<string, GodPower> godPowerDictionary;
    private God playerGod;
    void Start () {
        enemy = gameObject.GetComponent<God>();
        level = GameObject.Find("LevelManager").GetComponent<Level>();
        terrain = GameObject.Find("landscape_MAP");
        playerGod = GameObject.Find("Player1").GetComponent<God>();
        energy = enemy.energy;
        followers = enemy.followers;
        level = GameObject.Find("LevelManager").GetComponent<Level>();
        godPowerDictionary = new Dictionary<string, GodPower>()
        {
            { "Fire", new GodPowerFire()},
            { "SummonShrine", new GodPowerSummonShrine()}

        };

        setRandom();//changes its mind
        run();//runs what it wants to do, if it has energy.
    }
	void setRandom()
    {
        choice =  Random.Range(0,2);//set to length of dictionary
        Invoke("setRandom", 3.0f);
    }
    void runPower(int i)
    {
        GodPower thePower=null;
       
            switch (i)
            {
                case 0:
                    thePower = godPowerDictionary["Fire"];
                   
                    shrines = (level.GetShrinesByGod(playerGod));
                    int size = shrines.Count;
                    int sel = Random.Range(0, size);
                if (enemy.energy >= thePower.getEnergyCost()) 
                {
                    thePower.usePowerOnShrine(shrines[sel], enemy);
                    shrines[sel].burner();
                    enemy.energy -= thePower.getEnergyCost();
                }
                    break;

                case 1:
                    thePower = godPowerDictionary["SummonShrine"];
                   
                
                float x = Random.Range(867,2087);
                float y = Random.Range(0,500);
                float z = Random.Range(-2968,-215);
                randLoc = new Vector3(x, -744, z);
               
                print(x);
                if (enemy.energy >= thePower.getEnergyCost())
                {
                    
                   
                    thePower.usePowerOnMap(randLoc, enemy);
                     enemy.energy -= thePower.getEnergyCost();


                    
                }

                break;
                default:

                    break;
            }
        
    }
    void run()
    {
        
            runPower(choice);
        print("is shit broke?");
            Invoke("run", 2.0f);

        
    }
	
	void Update () {

        choice = Random.Range(0, 2);//set to length of dictionary



    }
}
