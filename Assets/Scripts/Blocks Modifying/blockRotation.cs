using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotation : BlocksModifying
{
    override public void ModifyBlock(ref Block block, int blockNumber)
    {
        float rotateDegree = 45;
        if (blockNumber % 2 == 1)
            block.transform.rotation = Quaternion.Euler(block.transform.rotation.eulerAngles.x, block.transform.rotation.eulerAngles.y + rotateDegree, block.transform.rotation.eulerAngles.z); ;

    }
}
