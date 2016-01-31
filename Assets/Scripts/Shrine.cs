using UnityEngine;
using UnityEngine.UI;

public class Shrine : MonoBehaviour {
    //set these after construction
    public Level level = null;
    public God god = null;
    public int followers = 1;
    public GameObject fire;
    public bool isBurning = false;

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
        Invoke("ReproduceFollowers", reproductionRate);
        playerInput = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerInputManager>();
    }
	
    void Update () {

    }

    //let the level know this shrine is gone
    void OnDestroy() {
        level.RemoveShrine(this);
    }
    int cycles = 5;
    float delay = 2.0f;
    public void burner()   //controls the killing when fire attack is used. 
    {
        if (isBurning == false)
        {

             Object.Instantiate(fire, this.transform.position, Quaternion.Euler(90,0,0));
            

        }
        int totalPop = this.followers;
        totalPop -= 2;
        this.followers = totalPop;
        isBurning = true;
        if (cycles != 0)
        {
            cycles--;
            Invoke("burner", delay);
        }
       else {
           
        }
    }

        void OnMouseDown()
    {
        Debug.Log("Shrine clicked!");
        playerInput.handleShrineClick(this);
    }
}
