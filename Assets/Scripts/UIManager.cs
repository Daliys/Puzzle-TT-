using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public LevelLoader levelLoader;
    public GameObject frameObj;
    public ParticleSystem confetti;

    public GameObject loadingPanel;
    public GameObject feedPanel;
    public GameObject corePanel;
    public GameObject finalPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    public void LoadingPanleOnClickPlayButton()
    {
        loadingPanel.SetActive(false);
        feedPanel.SetActive(true);
    }

    public void FeedPanelOnClickLevelButton(int numOfLevel)
    {
        
        feedPanel.SetActive(false);
        corePanel.SetActive(true);

        levelLoader.LoadLeavel(numOfLevel);
    }

    public void CorePanelOnClickBackButton()
    {
        corePanel.SetActive(false);
        feedPanel.SetActive(true);
        levelLoader.CleanLevel();
    }

    public void FinalPanelOnClickBackButton()
    {
        finalPanel.SetActive(false);
        feedPanel.SetActive(true);
        levelLoader.CleanLevel();
    }

    public void FinalPanelOnClickTryAgainButton()
    {
        finalPanel.SetActive(false);
        corePanel.SetActive(true);
        levelLoader.CleanLevel();
        levelLoader.LoadLeavel();
    }


    public void WinningAction()
    {
        levelLoader.level.transform.SetParent(frameObj.transform);
        RectTransform rectTransform = levelLoader.level.GetComponent<RectTransform>();

        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.offsetMin = new Vector2(0,0);
        rectTransform.offsetMax = new Vector2(0, 0);
       
        corePanel.SetActive(false);
        finalPanel.SetActive(true);

        StartCoroutine(PlayParticleSystem());
    }

    IEnumerator PlayParticleSystem()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        confetti.Play();
    }

}
