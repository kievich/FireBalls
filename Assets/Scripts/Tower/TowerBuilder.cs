using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _size;
    [SerializeField] private Block _blockTemplate;
    [SerializeField] private GameObject _buildPoint;
    [SerializeField] private Material[] _materials = new Material[2];

    private float _blockHeight;
    List<Block> blocks = new List<Block>();

    private void Start()
    {
        _blockHeight = _blockTemplate.GetComponent<MeshFilter>().sharedMesh.bounds.size.z;

        build();
    }

    private List<Block> build()
    {

        Transform currentBlock = _buildPoint.transform;
        for (int i = 0; i < _size; i++)
        {

            currentBlock = SpawnBlock(currentBlock).transform;
            currentBlock.GetComponent<MeshRenderer>().material = GetMaterialByNumber(i);

            currentBlock.rotation *= Quaternion.Euler(0, 0, i * 1f);
        }

        return null;
    }

    private Block SpawnBlock(Transform spawnpoint)
    {
        return Instantiate(_blockTemplate, spawnpoint.position + new Vector3(0, _blockHeight, 0), _blockTemplate.transform.rotation, transform);

    }

    private Material GetMaterialByNumber(int currentBlock)
    {
        if (currentBlock % 2 == 0)
            return _materials[0];
        else
            return _materials[1];
    }



}
