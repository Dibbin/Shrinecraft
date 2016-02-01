using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadTitleAfterDelay : MonoBehaviour {

    public float delay = 10.0f;

    public void changeScene()
    {
        SceneManager.LoadScene("TitleMenu");
    }


    // Use this for initialization
    void Start () {
        this.Invoke("changeScene", delay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
