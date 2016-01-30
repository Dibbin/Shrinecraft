using UnityEngine;
using UnityEngine.UI;

public class God : MonoBehaviour {
    public Level level;
    public float energyPerFollowerPerSecond = 1.0f;
    public int followers
    {
        get
        {
            int count = 0;
            foreach(Shrine s in level.GetShrinesByGod(this))
            {
                count += s.followers;
            }
            return count;
        }
    }
    public Slider slider;
    public float energy
    {
        get { return slider.value; }
        set { slider.value = value; }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //regain energy depending on number of followers
        energy += followers * energyPerFollowerPerSecond * Time.deltaTime;
    }
}
