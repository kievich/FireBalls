using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tower : MonoBehaviour
{
    private Queue<Block> _blocks = new Queue<Block>();
    [SerializeField] private GameObject _blockCluster;
    private float _blockHeight;
    private void Start()
    {
        var towerBuilder = gameObject.GetComponent<TowerBuilder>();
        _blocks = towerBuilder.Build();
        _blockHeight = towerBuilder.GetBlockHeight();

        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }

    }

    private void OnBulletHit()
    {
        _blocks.Peek().BulletHit -= OnBulletHit;
        _blocks.Dequeue();

        //foreach (Block currentBlock in _blocks)
        //{
        //    currentBlock.transform.Translate(new Vector3(0, -_blockHeight, 0));
        //}
        //transform.Translate(new Vector3(0, -_blockHeight, 0));
        _blockCluster.transform.DOMoveY(_blockCluster.transform.position.y - _blockHeight, 0.1f);


    }




}
