using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour {
    public List<Shrine> shrines = new List<Shrine>();
    public List<God> gods = new List<God>();

    public void RemoveShrine(Shrine s) {
        shrines.Remove(s);
    }

    public void AddShrine(Shrine s) {
        shrines.Add(s);
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
