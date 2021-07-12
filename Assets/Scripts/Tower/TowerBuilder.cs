using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _size;
    [SerializeField] private Block _blockTemplate;
    [SerializeField] private GameObject _buildPoint;
    [SerializeField] private Material[] _materials = new Material[2];
    [SerializeField] private GameObject _blockCluster;
    private IBlocksModifying _blockModifier = new BlockScaling();

    private float _blockHeight;

    private void Awake()
    {
        _blockHeight = _blockTemplate.GetComponent<MeshFilter>().sharedMesh.bounds.size.y * _blockTemplate.transform.localScale.y;
    }

    public Queue<Block> Build()
    {
        Queue<Block> blocks = new Queue<Block>();
        Vector3 currentSpawnPosition = _buildPoint.transform.position;

        for (int i = 0; i < _size; i++)
        {
            Block block = SpawnBlock(currentSpawnPosition);
            currentSpawnPosition = GetTopPoint(block);
            block.SetMaterial(GetMaterialByNumber(i));
            _blockModifier.ModifyBlock(ref block, i);
            blocks.Enqueue(block);
        }

        return blocks;
    }

    public float GetBlockHeight()
    {
        return _blockHeight;
    }

    private Block SpawnBlock(Vector3 spawnpoint)
    {
        return Instantiate(_blockTemplate, spawnpoint + new Vector3(0, _blockHeight / 2f, 0), Quaternion.identity, _blockCluster.transform);
    }

    private Material GetMaterialByNumber(int currentBlock)
    {
        if (currentBlock % 2 == 1)
            return _materials[0];
        else
            return _materials[1];
    }
    private Vector3 GetTopPoint(Block block)
    {
        return block.transform.position + new Vector3(0, _blockHeight / 2f, 0);

    }




}
