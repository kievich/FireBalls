using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    private Queue<Block> _blocks = new Queue<Block>();
    [SerializeField] private GameObject _blockCluster;
    private float _blockHeight;

    public event Action<int> ScoreChanged;
    public event Action BlocksOver;
    public void BuildTower(BuildData buildData)
    {
        var towerBuilder = gameObject.GetComponent<TowerBuilder>();
        _blocks = towerBuilder.Build(buildData);
        _blockHeight = towerBuilder.GetBlockHeight();

        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }
        ScoreChanged?.Invoke(_blocks.Count);

    }


    private void OnBulletHit()
    {
        _blocks.Peek().BulletHit -= OnBulletHit;
        _blocks.Dequeue();
        _blockCluster.transform.DOMoveY(_blockCluster.transform.position.y - _blockHeight, 0.1f);
        ScoreChanged?.Invoke(_blocks.Count);

        if (_blocks.Count == 0)
            BlocksOver?.Invoke();


    }




}
