using UnityEngine;

public static class GameInfo
{
    private static float _lastTime = 0;
    private static float _bestTime = 0;

    public static float LastTime
    {
        get => _lastTime;
        set { _lastTime = value; PlayerPrefs.SetFloat("LastTime", value); PlayerPrefs.Save(); }
    }
    public static float BestTime
    {
        get => _bestTime;
        set { _bestTime = value; PlayerPrefs.SetFloat("BestTime", value); PlayerPrefs.Save(); }
    }

    public static void Load()
    {
        _bestTime = PlayerPrefs.GetFloat("BestTime", 0);
        _lastTime = PlayerPrefs.GetFloat("LastTime", 0);
    }
}
