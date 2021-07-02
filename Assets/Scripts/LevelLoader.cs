using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public int numOfLoadingLevel;
    [SerializeField]
    public GameObject[] levels;
    public GameObject level;

    public PuzzleScroller puzzleScroller;

    public void LoadLeavel(int numOfLoadingLevel)
    {
        this.numOfLoadingLevel = numOfLoadingLevel;
        level = Instantiate(levels[numOfLoadingLevel], transform);
        GameData.puzzlesToWin = level.transform.childCount;
        puzzleScroller.LoadPuzzles();
    }

    public void LoadLeavel()
    {
        level = Instantiate(levels[numOfLoadingLevel], transform);
        GameData.puzzlesToWin = level.transform.childCount;
        puzzleScroller.LoadPuzzles();
    }

    public void CleanLevel()
    {
        GameData.instantiate.CleanDataOfLevel();
        puzzleScroller.CleanLevel();
        Destroy(level);
        GameData.puzzlesToWin = 0;
    }

}
