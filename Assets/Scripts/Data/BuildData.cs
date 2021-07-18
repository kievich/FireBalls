
public class BuildData
{
    public int Size { get; private set; }
    public Block BlockTemplate { get; private set; }
    public BlocksModifying BlockModifier { get; private set; }

    public BuildData(int size, Block blockTemplate, BlocksModifying blockModifier)
    {
        Size = size;
        BlockTemplate = blockTemplate;
        BlockModifier = blockModifier;
    }

}
