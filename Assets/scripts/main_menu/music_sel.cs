using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class music_sel : MonoBehaviour
{
    public static music_sel instance;

    [Header("Dropdown")]
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private Slider volumeSlider;

    [Header("Music")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip song1;
    [SerializeField] private AudioClip song2;
    [SerializeField] private AudioClip song3;

    private const string MusicKey = "SelectedSong";
    public const string VolumeKey = "MusicVolume";

    private void Awake()
    {
        // Make sure only one music manager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        // Get saved song
        int savedSong = PlayerPrefs.GetInt(MusicKey, 0);

        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);

        audioSource.volume = savedVolume;

        //slider

        if(volumeSlider != null)
        {
            volumeSlider.SetValueWithoutNotify(savedVolume);
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }

        // Set dropdown to saved song
        dropdown.SetValueWithoutNotify(savedSong);

        // Listen for dropdown changes
        dropdown.onValueChanged.AddListener(ChangeSong);

        // Play saved song
        PlaySong(savedSong);
    }

    public void ChangeSong(int index)
    {
        // Save selected song
        PlayerPrefs.SetInt(MusicKey, index);
        PlayerPrefs.Save();

        // Play selected song
        PlaySong(index);
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;

        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.Save();
    }
    private void PlaySong(int index)
    {
        AudioClip selectedSong = null;

        switch (index)
        {
            case 0:
                selectedSong = song1;
                break;

            case 1:
                selectedSong = song2;
                break;

            case 2:
                selectedSong = song3;
                break;
        }

        if (selectedSong == null)
        {
            Debug.LogWarning("Music clip is missing!");
            return;
        }

        // Don't restart if the same song is already playing
        if (audioSource.clip == selectedSong && audioSource.isPlaying)
            return;

        audioSource.clip = selectedSong;
        audioSource.loop = true;
        audioSource.Play();
    }
}
