using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler 
{
    RectTransform recTransform;
    CanvasGroup canvasGroup;
    public ItemSlot.TypeOfPuzzle typeOfPuzzle;
    private Vector2 startAnchoredPosition;

    private void Start()
    {
        recTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        startAnchoredPosition = recTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        recTransform.anchoredPosition += eventData.delta / GameData.canvasScaleFactor; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void ReturnToStartPosition()
    {
        recTransform.anchoredPosition = startAnchoredPosition;
    }


}
