using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadCreditsAfterDelay : MonoBehaviour {


    public float delay = 10.0f;

    public void changeScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }


    // Use this for initialization
    void Start()
    {
        this.Invoke("changeScene", delay);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
