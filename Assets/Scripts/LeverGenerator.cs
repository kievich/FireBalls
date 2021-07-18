using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LeverGenerator : MonoBehaviour
{
    [SerializeField] private ThemeList _themeList;
    [SerializeField] private MaterialList _materialList;
    [SerializeField] private BlockList _blockList;

    [SerializeField] private int DefaultNumberOfBlock;
    [SerializeField] private int NumberOfLevelToEnlargeBlock;
    private System.Random random;

    private void Awake()
    {
        int currentLevel = Data.Level;
        random = GetRandom(currentLevel.ToString());
        var buildData = GetBuildData(currentLevel);
        var levelData = GetLevelData(buildData);
        ApplyColorTheme(levelData.Theme);
        FindObjectOfType<Tower>().BuildTower(buildData);

    }

    private BuildData GetBuildData(int level)
    {
        int size = DefaultNumberOfBlock + level / NumberOfLevelToEnlargeBlock;
        Block template = _blockList.Blocks[random.Next() % _blockList.Blocks.Length];
        var ModifiersList = BlocksModifying.GetModifiers();
        BlocksModifying modifier = ModifiersList[random.Next() % ModifiersList.Count];

        return new BuildData(size, template, modifier);
    }

    private LevelData GetLevelData(BuildData buildData)
    {
        ColorTheme theme = _themeList.Themes[random.Next() % _themeList.Themes.Length];
        return new LevelData(buildData, theme);
    }

    private void ApplyColorTheme(ColorTheme theme)
    {
        _materialList.Block1.color = theme.BlockColor1;
        _materialList.Block2.color = theme.BlockColor2;
        _materialList.Obstacles.color = theme.ObstaclesColors;
    }

    private static System.Random GetRandom(string seed)
    {
        using var algo = SHA1.Create();
        var hash = BitConverter.ToInt32(algo.ComputeHash(System.Text.Encoding.UTF8.GetBytes(seed)), 0);
        return new System.Random(hash);
    }

}
