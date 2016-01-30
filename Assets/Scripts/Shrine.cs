using UnityEngine;
using System.Collections.Generic;

public class Shrine : MonoBehaviour {
    public God god;
    protected float nextEvent;
    protected Queue<ShrineEvent> events;

    public void PushEvent(ShrineEvent e)
    {

    }

	// Use this for initialization
	void Start () {
        nextEvent = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
