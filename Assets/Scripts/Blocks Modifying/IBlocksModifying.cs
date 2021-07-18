using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public abstract class BlocksModifying
{
    abstract public void ModifyBlock(ref Block block, int blockNumber);

    static public List<BlocksModifying> GetModifiers()
    {
        List<BlocksModifying> objects = new List<BlocksModifying>();
        foreach (Type type in
            Assembly.GetAssembly(typeof(BlocksModifying)).GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BlocksModifying))))
        {
            objects.Add((BlocksModifying)Activator.CreateInstance(type));
        }
        return objects;
    }
}
