using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager Instance { get; private set; }

    [Header("Sliders")]
    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;

    public Image brightnessOverlay;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
        sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);

        // Restaurar valores guardados
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }

    private void OnMasterVolumeChanged(float value)
    {
        //Debug.Log("Master Volume (demo): " + value);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    private void OnSFXVolumeChanged(float value)
    {
        //Debug.Log("SFX Volume (demo): " + value);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    private void OnMusicVolumeChanged(float value)
    {
        //Debug.Log("Music Volume (demo): " + value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
}

