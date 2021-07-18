using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{

    [SerializeField] private GameObject _buildPoint;
    [SerializeField] private Material[] _materials = new Material[2];
    [SerializeField] private GameObject _blockCluster;

    private float _blockHeight;

    public Queue<Block> Build(BuildData buildData)
    {
        FindBlockHeight(buildData.BlockTemplate);

        Queue<Block> blocks = new Queue<Block>();
        Vector3 currentSpawnPosition = _buildPoint.transform.position;

        for (int i = 0; i < buildData.Size; i++)
        {
            Block block = SpawnBlock(buildData.BlockTemplate, currentSpawnPosition);
            currentSpawnPosition = GetTopPoint(block);
            block.SetMaterial(GetMaterialByNumber(i));
            buildData.BlockModifier.ModifyBlock(ref block, i);
            blocks.Enqueue(block);
        }

        return blocks;
    }

    public float GetBlockHeight()
    {
        return _blockHeight;
    }

    private void FindBlockHeight(Block blockTemplate)
    {
        _blockHeight = blockTemplate.GetComponent<MeshFilter>().sharedMesh.bounds.size.y * blockTemplate.transform.localScale.y;
    }

    private Block SpawnBlock(Block blockTemplate, Vector3 spawnpoint)
    {
        return Instantiate(blockTemplate, spawnpoint + new Vector3(0, _blockHeight / 2f, 0), Quaternion.identity, _blockCluster.transform);
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
