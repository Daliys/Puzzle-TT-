using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PuzzleScroller : MonoBehaviour, IPointerExitHandler, IDropHandler
{
    public GameObject puzzleContex;
    public LevelLoader levelLoader;
    [SerializeField]
    public GameObject[] puzzleItemPrefabs;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.transform.parent == puzzleContex.transform)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().ReturnToStartPosition();
        }
        else if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<DragDrop>() != null)
        {
            eventData.pointerDrag.gameObject.transform.SetParent(puzzleContex.transform);
            Canvas.ForceUpdateCanvases();
            transform.GetComponent<ScrollRect>().horizontalNormalizedPosition = 0;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<DragDrop>() != null)
        {
            eventData.pointerDrag.gameObject.transform.SetParent(levelLoader.level.transform);
        }
    }
   
    public void LoadPuzzles()
    {
        for (int i = 0; i < levelLoader.level.transform.childCount; i++)
        {
            // конечно правильнее было бы делать это через пул объектов и подгружать при запуске игры, но на разработку уйдет немного больше времени + наверное мне это не особо зачтется в тестовом задании
            Instantiate(GetPuzzleItem(levelLoader.level.transform.GetChild(i).GetComponent<ItemSlot>()), puzzleContex.transform);
        }
        Canvas.ForceUpdateCanvases();
        transform.GetComponent<ScrollRect>().horizontalNormalizedPosition = 0;
    }

    public void CleanLevel()
    {
        for (int i = 0; i < puzzleContex.transform.childCount; i++)
        {
            // конечно правильнее было бы делать это через пул объектов и подгружать при запуске игры, но на разработку уйдет немного больше времени + наверное мне это не особо зачтется в тестовом задании
            Destroy(puzzleContex.transform.GetChild(i).gameObject);
        }
    }


    private GameObject GetPuzzleItem(ItemSlot itemSlot)
    {
        foreach (var item in puzzleItemPrefabs)
        {
            if (item.GetComponent<DragDrop>().typeOfPuzzle == itemSlot.typeOfPuzzle) return item;
        }

        return null;
    }

}
