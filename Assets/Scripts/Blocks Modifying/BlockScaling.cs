using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScaling : BlocksModifying
{
    override public void ModifyBlock(ref Block block, int blockNumber)
    {
        float scaleFactor = 0.9f;
        if (blockNumber % 2 == 1)
            block.transform.localScale = new Vector3(block.transform.localScale.x * scaleFactor, block.transform.localScale.y, block.transform.localScale.z * scaleFactor);

    }

}
