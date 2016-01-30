using UnityEngine;
using System.Collections.Generic;

public class Shrine : MonoBehaviour {
    //set these after construction
    public Level level = null;
    public God god = null;
    //these are only used internally
    protected float nextEvent = 0.0f;
    protected List<ShrineEvent> events = new List<ShrineEvent>();

    //add an event to a shrine's queue
    public void PushEvent(ShrineEvent e)
    {
        //fire immediate events immediately
        if (e.delay <= 0.0f)
        {
            e.Doit(this);
            return;
        }

        //reuse the delay as an actual time when it should happen
        e.delay += Time.time;

        //insert the event in correct order
        for(int i = 0; i < events.Count; i++)
        {
            //insert the item here if it has to occur sooner than the one after it
            if(e.delay < events[i].delay)
            {
                events.Insert(i, e);
                if (i == 0) nextEvent = e.delay;
                return; //completely done at this point
            }
        }

        //if this event was after everything else, append it
        events.Add(e);
    }
	
    //run any events that need running
	void Update () {
        //if we have events to run and the soonest needs doing
        if (events.Count > 0 && nextEvent <= Time.time)
        {
            //get the soonest event
            ShrineEvent ev = events[0];
            //remove the soonest event from our list
            events.RemoveAt(0);
            //do the soonest event
            ev.Doit(this);
            //promote the next event and see if it also needs doing
            if(events.Count > 0)
            {
                ShrineEvent nxt = events[0];
                nextEvent = nxt.delay;
                //recurse to see if multiple events need doing
                Update();
            }
        }
	}

    //let the level know this shrine is gone
    void OnDestroy() {
        level.RemoveShrine(this);
    }
}
