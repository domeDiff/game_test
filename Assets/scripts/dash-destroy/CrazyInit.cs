using CrazyGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrazyInit : MonoBehaviour
{
    
    [SerializeField] private string nextSceneName = "dash-destroy_main_menu";

    // true only when the SDK can actually be used
    public static bool SdkReady => CrazySDK.IsAvailable && CrazySDK.IsInitialized;

    private void Start()
    {
        if (!CrazySDK.IsAvailable || CrazySDK.IsInitialized)
        {
            LoadNext();   // SDK missing (e.g. Basic Launch) or already initialized
            return;
        }

        CrazySDK.Init(LoadNext);
    }

    private void LoadNext()
    {
        SceneManager.LoadScene(nextSceneName);
    }

}
