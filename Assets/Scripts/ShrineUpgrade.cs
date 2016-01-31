using UnityEngine;
using System.Collections;

public class ShrineUpgrade : MonoBehaviour {
    public Shrine parent;
    public Transform point1;
    public Transform point2;
    public GameObject bldg1;
    public GameObject bldg2;

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
            Instantiate(bldg1, point1.transform.position, Quaternion.Euler(0, 90, 0));

            iscreated1 = true;
        }
        if (parent.followers > 7 && iscreated2 == false)
        {
            Instantiate(bldg2, point2.transform.position, Quaternion.Euler(0, 90, 0));
            iscreated2 = true;
        }
        if (parent.followers < 0)
        {
            DestroyImmediate(bldg1);
            DestroyImmediate(bldg2);
            //Destroy(bldg1);
            //Destroy(bldg2);
            Destroy(this);

        }

    }
}
