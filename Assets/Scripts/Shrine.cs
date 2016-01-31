using UnityEngine;
using UnityEngine.UI;

public class Shrine : MonoBehaviour {
    //set these after construction
    private Level level;
    public God god = null;
    public int followers = 1;
    public ParticleSystem theFire;
    public GameObject self;
    public GameObject ruins;
    public AudioSource screamer;
    public ParticleSystem theBlood;
    public bool isBurning = false;
    public ShrineUpgrade su = null;

    public int maxFollowers
    {
        get
        {
            return (int)(Mathf.Min(food, water) * followersPerSupply);
        }
    }
    public float followersPerSupply = 2.0f;
    public float food = 4.0f;
    public float water = 4.0f;
    //need to handle maxfood, maxwater (resources in general)

    public float reproductionRate = 5.0f;

    private PlayerInputManager playerInput;

    void ReproduceFollowers()
    {
        if(followers < maxFollowers) followers++;

        Invoke("ReproduceFollowers", reproductionRate);
    }

    void Start ()
    {
        level = GameObject.Find("LevelManager").GetComponent<Level>();
        Invoke("ReproduceFollowers", reproductionRate);
        playerInput = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerInputManager>();
    }

    public void Kill(int n)
    {
        followers -= n;
        if (screamer) screamer.Play();
        if (theBlood) theBlood.Play();
    }
	
    void Update () {
        if (followers < 0)
        {
            Instantiate(ruins, transform.position, Quaternion.identity);
            followers = 0;
            Destroy(gameObject);
        }
    }

    //let the level know this shrine is gone
    void OnDestroy() {
        level.RemoveShrine(this);
        Destroy(su);
    }


    public int cycles = 5;
    public float delay = 2.0f;
    public void burner()   //controls the killing when fire attack is used. 
    {
       
        if (isBurning == false)
        {

           theFire.Stop();
           

        }
        theFire.Play();
        Kill(2);
        isBurning = true;
        if (cycles != 0)
        {
            cycles--;
            Invoke("burner", delay);
        }
       else {
           
            isBurning = false;
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Shrine clicked!");
        playerInput.handleShrineClick(this);
    }
}
