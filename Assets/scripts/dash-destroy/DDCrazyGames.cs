using CrazyGames;
using UnityEngine;

public static class DDCrazyGames
{
    private static bool Ready => CrazySDK.IsAvailable && CrazySDK.IsInitialized;

    public static void GameplayStart() { if (Ready) CrazySDK.Game.GameplayStart(); }
    public static void GameplayStop() { if (Ready) CrazySDK.Game.GameplayStop(); }
    public static void HappyTime() { if (Ready) CrazySDK.Game.HappyTime(); }
}
