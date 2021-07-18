using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] float _animationDuraction;
    private void Start()
    {
        transform.DORotate(new Vector3(0, 360f, 0), _animationDuraction, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }
}
