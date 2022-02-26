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

        if (endGame)
        {
            return;
        }

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
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
    //void Stopper()
    //{
    //    timeToEnd --;
    //    if(endGame)
    //    {
    //        return;
    //    }
    //    if(timeToEnd <- 0)
    //    {
    //        timeToEnd = 0;
    //        endGame = true;
    //    }
    //    Debug.Log("Time" + timeToEnd + "s");
    //}
}
