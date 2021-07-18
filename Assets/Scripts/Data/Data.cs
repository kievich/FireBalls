using UnityEngine;

public static class Data
{
    public static int Level { get; private set; }

    static Data()
    {
        InitLevel();
    }

    static void InitLevel()
    {
        var key = "Level";
        var defaultValue = 1;

        if (!PlayerPrefs.HasKey(key))
            PlayerPrefs.SetInt(key, defaultValue);

        Level = PlayerPrefs.GetInt(key);

    }

    public static void SetNextLevel()
    {
        Level++;
        PlayerPrefs.SetInt("Level", Level);
    }

}
