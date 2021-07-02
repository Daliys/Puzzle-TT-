using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public enum TypeOfPuzzle
    {
        circle, triangle, square, hexagon, star, puzzle
    }
    public TypeOfPuzzle typeOfPuzzle;

    public void OnDrop(PointerEventData eventData)
    {
        //print("Ondrop");
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<DragDrop>().typeOfPuzzle == typeOfPuzzle)
            {

                eventData.pointerDrag.GetComponent<RectTransform>().anchorMax = GetComponent<RectTransform>().anchorMax;
                eventData.pointerDrag.GetComponent<RectTransform>().anchorMin = GetComponent<RectTransform>().anchorMin;
                eventData.pointerDrag.GetComponent<RectTransform>().offsetMin = GetComponent<RectTransform>().offsetMin;
                eventData.pointerDrag.GetComponent<RectTransform>().offsetMax = GetComponent<RectTransform>().offsetMax;

                eventData.pointerDrag.GetComponent<DragDrop>().enabled = false;
                eventData.pointerDrag.GetComponent<Animator>().SetTrigger("IsRight");

                GameData.instantiate.AddCollectedPuzzle();
            }
            else
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchorMax = GetComponent<RectTransform>().anchorMax;
                eventData.pointerDrag.GetComponent<RectTransform>().anchorMin = GetComponent<RectTransform>().anchorMin;

                Vector2 randOfset = new Vector2(Random.Range(-200, 200), Random.Range(-200, 200));

                eventData.pointerDrag.GetComponent<RectTransform>().offsetMin = new Vector2(GetComponent<RectTransform>().offsetMin.x + randOfset.x, GetComponent<RectTransform>().offsetMin.y + randOfset.y);
                eventData.pointerDrag.GetComponent<RectTransform>().offsetMax = new Vector2(GetComponent<RectTransform>().offsetMax.x + randOfset.x, GetComponent<RectTransform>().offsetMin.y + randOfset.y);

                eventData.pointerDrag.GetComponent<Animator>().SetTrigger("IsWrong");

            }
        }
    }

}
