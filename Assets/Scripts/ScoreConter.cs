using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreConter : MonoBehaviour
{
    [SerializeField] TMP_Text _textMeshPro;
    [SerializeField] Tower _tower;


    private void OnEnable()
    {
        _tower.ScoreChanged += onScoreChanged;
    }

    private void OnDisable()
    {
        _tower.ScoreChanged -= onScoreChanged;
    }


    private void onScoreChanged(int value)
    {
        _textMeshPro.text = value.ToString();
    }
}

