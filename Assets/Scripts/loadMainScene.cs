using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadMainScene : MonoBehaviour {

    public void changeScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void exitGame()
    {
        Application.Quit();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
