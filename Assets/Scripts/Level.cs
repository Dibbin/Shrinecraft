using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour {
    public List<Shrine> shrines = new List<Shrine>();
    public List<God> gods = new List<God>();

    //remove a shrine
    public void RemoveShrine(Shrine s) {
        shrines.Remove(s);
    }

    //add a shrine
    public void AddShrine(Shrine s) {
        shrines.Add(s);
    }

    public List<Shrine> GetShrinesByGod(God g)
    {
        List<Shrine> filtered = new List<Shrine>();
        foreach(Shrine s in shrines)
        {
            if(s.god == g)
            {
                filtered.Add(s);
            }
        }
        return filtered;
    }
    
	void Update () {
        List<Shrine> test;
        test = (GetShrinesByGod(gods[0]));

        if (test.Count <= 0){
            //you lose
            print("loser");
        }
        test = (GetShrinesByGod(gods[1]));
        if (test.Count <= 0)
        {
            //you win
            print("winner");
        }
    }
}
