using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playMovie : MonoBehaviour {

    public bool loop = true;

	// Use this for initialization
	void Start () {

        MovieTexture movie = GetComponent<RawImage>().texture as MovieTexture;
        movie.loop = loop;

        if (movie.isPlaying)
        {
            movie.Pause();
        }
        else {
            movie.Play();
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
