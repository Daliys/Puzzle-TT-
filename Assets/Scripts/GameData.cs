using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public Canvas canvas;
    public UIManager uiManager;

    public static GameData instantiate;

    public static float canvasScaleFactor;
    public static int puzzlesToWin;
    public int currentCollectedPuzzles;

    void Start()
    {
        if (instantiate == null) instantiate = this;
        else Destroy(gameObject);

        canvasScaleFactor = canvas.scaleFactor;
    }

  

    public void AddCollectedPuzzle()
    {
        currentCollectedPuzzles++;
        if(currentCollectedPuzzles == puzzlesToWin)
        {
            uiManager.WinningAction();
        }
    }

    public void CleanDataOfLevel()
    {
        currentCollectedPuzzles = 0;
    }

}
