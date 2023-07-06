using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    private const string LevelNumber = "LevelNumber";
    private const string SnakeSize = "SnakeSize";

    public static void SaveLevelNubmer(int currentLevel)
    {
        PlayerPrefs.SetInt(LevelNumber, currentLevel);
    }

    public static int LoadLevelNubmer()
    {
        return PlayerPrefs.GetInt(LevelNumber, 1);
    }

    public static void SaveSnakeSize(int snakeSize)
    {
        PlayerPrefs.SetInt(SnakeSize, snakeSize);
    }

    public static int LoadSnakeSize(Snake snake)
    {
        return PlayerPrefs.GetInt(SnakeSize, snake.DefaultTailSize);
    }
}
