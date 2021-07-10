using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] float _animationDuraction;
    private void Start()
    {
        var OriginX = transform.rotation.eulerAngles.x;
        var OriginY = transform.rotation.eulerAngles.x;
        var OriginZ = transform.rotation.eulerAngles.z;

        transform.DORotate(new Vector3(OriginX, OriginY, 360f), _animationDuraction, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutBack);
    }
}
