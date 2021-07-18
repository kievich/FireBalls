using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTwist : BlocksModifying
{
    override public void ModifyBlock(ref Block block, int blockNumber)
    {
        float twistDegree = 3;

        block.transform.rotation *= Quaternion.Euler(0, twistDegree * blockNumber, 0); ;

    }
}
