using CrazyGames;
using UnityEngine;

public class DDHighScore : MonoBehaviour
{
    private const string HighScoreKey = "dd_highscore";

    public static int HighScore {  get; private set; }

  //  private static bool sdkReady;
    //private static bool initStarted;
    private bool saved;

    //private void Start()
    //{
    //  //  if(sdkReady)
    //    //{
    //    //    LoadHighScore();
    //    //}

    //    else if (!initStarted)
    //    {
    //        initStarted = true;
    //        CrazySDK.Init(() =>
    //        {
    //         //   sdkReady = true;
    //            LoadHighScore();
    //        });

    //    }
    //}

    private void LoadHighScore()
    {
      //  HighScore = CrazySDK.Data.GetInt(HighScoreKey, 0);
    }

    private void Update()
    {
        var wm = DDWorldManager.Instance;
        if (wm == null || saved) return;

        if (!wm.IsAlive)
        {
            saved = true;
            int finalScore = Mathf.FloorToInt(wm.Score);

            if(finalScore > HighScore)
            {
                HighScore = finalScore;
               // CrazySDK.Data.SetInt(HighScoreKey, HighScore);
            }

            Debug.Log("High Score: " + HighScore);
        }
    }
}
