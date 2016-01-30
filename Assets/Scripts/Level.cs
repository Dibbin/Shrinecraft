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

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
