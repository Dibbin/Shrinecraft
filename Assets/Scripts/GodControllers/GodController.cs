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
            { "SummonShrine", new GodPowerSummonShrine()},
            {"Sacrifice",new GodPowerSacrifice()  }

        };

        setRandom();//changes its mind
        run();//runs what it wants to do, if it has energy.
    }
	void setRandom()
    {
        choice =  Random.Range(0,3);//set to length of dictionary
        Invoke("setRandom", 5.0f);
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
                    int sel = Random.Range(0, size-1);
                if (enemy.energy >= thePower.getEnergyCost()) 
                {
                    thePower.usePowerOnShrine(shrines[sel], enemy);
                    shrines[sel].burner();
                    enemy.energy -= thePower.getEnergyCost();
                }
                    break;

                case 1:
                    thePower = godPowerDictionary["SummonShrine"];


               
                if (enemy.energy >= thePower.getEnergyCost())
                {


                    print("trying to place shrine on map CPU");

                    var locationFound = false;

                    RaycastHit hit;
                    Ray ray;
                    int count = 0;
                    while (!locationFound && count++ < 20)
                    {
                        Vector3 fakeMousePoint = new Vector3(Random.Range(10, Screen.width - 10), Random.Range(10, Screen.height - 10), 0);
                        

                        ray = Camera.main.ScreenPointToRay(fakeMousePoint);
                        if (terrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
                        {
                            thePower.usePowerOnMap(hit.point, enemy);
                            enemy.energy -= thePower.getEnergyCost();
                            print("placing shrine on map CPU");
                            locationFound = true;
                            break;
                        }
                    }



                }

                break;

            case 2:
                thePower = godPowerDictionary["Sacrifice"];
                print("kill");
                shrines = (level.GetShrinesByGod(enemy));
                size = shrines.Count;
                sel = Random.Range(0, size-1);
                if (enemy.energy >= thePower.getEnergyCost())
                {
                    thePower.usePowerOnShrine(shrines[sel], enemy);
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

       // choice = Random.Range(0, 2);//set to length of dictionary
       //didnt want it to change so frequnetly, otherwise he will use the cheaper option more frequently


    }
}
