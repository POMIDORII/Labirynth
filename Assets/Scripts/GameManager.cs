using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager gameManager;
    public int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public int Points = 0;
    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;

        }
        if (timeToEnd < -0)
        {
            timeToEnd = 100;

        }

        InvokeRepeating("Stopper", 2, 1);
    }
    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + " s");

       

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if (endGame)
            Endgame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();

            }


        }
    }
    public void PauseGame()
    {
        Debug.LogWarning("Pause Game");
            Time.timeScale = 0f;
        gamePaused = true;

    }
    public void ResumeGame()
    {
        Debug.Log("Resume Game");
            Time.timeScale = 1f;
        gamePaused = false;

    }
    public void Endgame()
    {
        CancelInvoke("Stopper");
        if(win)
            Debug.Log("You win! Reload?");
        else
            Debug.Log("You lose! Reload?");

    }
    public void AddPoints(int point)
    {
        Points += point;
    }
    public void AddTime(int time)
    {
        timeToEnd += time;
    }
    public void FreezeTime(int freeze)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freeze, 1);


    }
  
    public void AddKey(KeyColor keyColor)
    {
        switch (keyColor)
            {
            case KeyColor.Red:
                redKey++;
                break;
            case KeyColor.Green:
                greenKey++;
                break;
            case KeyColor.Gold:
                goldKey++;
                break;
                

        }
    }
}
