using UnityEngine;

public class DDHighScore : MonoBehaviour
{
    private const string HighScoreKey = "dd_highscore";

    public static int HighScore { get; private set; }

    private bool saved;

    private void Start()
    {
        HighScore = Load();
    }

    private void Update()
    {
        var wm = DDWorldManager.Instance;
        if (wm == null || saved || wm.IsAlive) return;

        saved = true;
        int finalScore = Mathf.FloorToInt(wm.Score);

        if (finalScore > HighScore)
        {
            if (HighScore > 0) DDCrazyGames.HappyTime();   // no confetti on the first run
            HighScore = finalScore;
            Save(HighScore);
        }
    }

    private static int Load()
    {
        return CrazyInit.SdkReady
            ? CrazyGames.CrazySDK.Data.GetInt(HighScoreKey, 0)
            : PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    private static void Save(int value)
    {
        if (CrazyInit.SdkReady)
        {
            CrazyGames.CrazySDK.Data.SetInt(HighScoreKey, value);
        }
        else
        {
            PlayerPrefs.SetInt(HighScoreKey, value);
            PlayerPrefs.Save();
        }
    }
}