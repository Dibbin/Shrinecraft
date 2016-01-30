using UnityEngine;

public class Shrine : MonoBehaviour {
    //set these after construction
    public Level level = null;
    public God god = null;
    public int followers = 1;
    public int maxFollowers
    {
        get
        {
            return (int)(Mathf.Min(food, water) * followersPerSupply);
        }
    }
    public float followersPerSupply = 2.0f;
    public float food = 0.0f;
    public float water = 0.0f;
    //need to handle maxfood, maxwater (resources in general)

    public float reproductionRate = 5.0f;

    void ReproduceFollowers()
    {
        if(followers < maxFollowers) followers++;

        Invoke("ReproduceFollowers", reproductionRate);
    }

    void Start ()
    {
        Invoke("ReproduceFollowers", reproductionRate);
    }
	
    void Update () {

    }

    //let the level know this shrine is gone
    void OnDestroy() {
        level.RemoveShrine(this);
    }
}
