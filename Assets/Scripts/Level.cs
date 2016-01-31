using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    public List<Shrine> shrines = new List<Shrine>();
    public List<God> gods = new List<God>();
    private bool isOver = false;

    //remove a shrine
    public void RemoveShrine(Shrine s) {
        shrines.Remove(s);
        if (!isOver)
        {
            CheckForWin();
        }
    }

    //add a shrine
    public void AddShrine(Shrine s) {
        shrines.Add(s);
    }

    public List<Shrine> GetShrinesByGod(God g)
    {
        List<Shrine> filtered = new List<Shrine>();
        foreach(Shrine s in shrines)
        {
            if(s.god == g)
            {
                filtered.Add(s);
            }
        }
        return filtered;
    }
    
	public void CheckForWin() {
        List<Shrine> test;
        test = (GetShrinesByGod(gods[0]));

        if (test.Count <= 0){
            //you lose
            print("loser");
            isOver = true;
        }
        test = (GetShrinesByGod(gods[1]));
        if (test.Count <= 0)
        {
            //you win
            print("winner");
            HandleWin();
        }
    }

    public void HandleWin()
    {
        isOver = true;
        Invoke("ChangeToWinScene", 3.0f);
    }

    public void ChangeToWinScene()
    {
        print("loading scene WinScene");
        SceneManager.LoadScene("WinScene");
    }
}
