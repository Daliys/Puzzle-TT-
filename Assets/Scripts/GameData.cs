using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public Canvas canvas;

    public static float canvasScaleFactor;

    void Start()
    {
        canvasScaleFactor = canvas.scaleFactor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
