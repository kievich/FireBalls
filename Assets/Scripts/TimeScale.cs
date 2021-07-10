using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{

    [SerializeField] private float _scale = 1;

    private void Start()
    {
        Time.timeScale = _scale;

    }
}
