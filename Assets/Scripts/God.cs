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
    public Slider energySlider;
    public Text followersText;
    public float energy
    {
        get { return energySlider.value; }
        set { energySlider.value = value; }
    }

	void Start () {
	
	}
	
	
	void Update () {
        //regain energy depending on number of followers
        energy += followers * energyPerFollowerPerSecond * Time.deltaTime;
        followersText.text = followers.ToString();
    }
}
