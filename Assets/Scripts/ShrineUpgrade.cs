using UnityEngine;
using System.Collections;

public class ShrineUpgrade : MonoBehaviour {
    public Shrine parent;
    public Transform point1;
    public Transform point2;
    public GameObject bldg1;
    public GameObject bldg2;
    private GameObject copy1 = null;
    private GameObject copy2 = null;

    bool iscreated1 = false;
    bool iscreated2 = false;

	// Use this for initialization
	void Start () {
	



	}

    // Update is called once per frame
    void Update()
    {
        if (parent.followers > 5 && iscreated1 == false)
        {
            copy1 = Instantiate(bldg1, point1.transform.position, Quaternion.Euler(0, 90, 0)) as GameObject;

            iscreated1 = true;
        }
        if (parent.followers > 7 && iscreated2 == false)
        {
            copy2 = Instantiate(bldg2, point2.transform.position, Quaternion.Euler(0, 90, 0)) as GameObject;
            iscreated2 = true;
        }

    }

    void OnDestroy()
    {

        if (copy1) Destroy(copy1);
        if (copy2) Destroy(copy2);
    }
}
