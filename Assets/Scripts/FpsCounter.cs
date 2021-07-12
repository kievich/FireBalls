using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text _textMeshPro;
    private float timeFromLastDisplay;
    private int framesPassed = 0;
    private float fpsTotal = 0f;
    private void Update()
    {

        float fps = 1 / Time.unscaledDeltaTime;
        fpsTotal += fps;
        framesPassed++;

        if (timeFromLastDisplay > 0.5f)
        {

            _textMeshPro.text = "FPS: " + Math.Round(fps, 0) + "\nAVG: " + Math.Round(fpsTotal / framesPassed, 2);
            timeFromLastDisplay = 0;
        }
        else
        {
            timeFromLastDisplay += Time.deltaTime;
        }
    }
}
