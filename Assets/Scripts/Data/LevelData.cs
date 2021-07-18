
public class LevelData
{
    public BuildData BuildData { get; private set; }
    public ColorTheme Theme { get; private set; }

    public LevelData(BuildData buildData, ColorTheme theme)
    {
        BuildData = buildData;
        Theme = theme;
    }


}
