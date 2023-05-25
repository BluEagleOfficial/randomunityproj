using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using TMPro;
using UnityEngine.UI;

public class settingsManager : MonoBehaviour
{
    [Header("Components")]
    private PlayerHud ph;
    [SerializeField] private AudioMixer soundMixer;
    [SerializeField] private AudioMixer musicMixer;
    public Resolution resolution;
    [SerializeField]
    UniversalRenderPipelineAsset[] renderAssets;

    [Space]
    [Header("Variables")]
    public bool vsync;
    public bool fullscreen = true;
    // public bool motionBlur;
    // [Tooltip("enable to show hp numbers on healthbar")] public bool showNumbers;
    public int SoundVolume = 100;
    public int MusicVolume = 100;
    public int fpsLimit = 60;
    public int graphicsQuality;
    public int sensitivity;
    public int fov;
    public int resolutionScale = 100;

    [Space]
    [Header("UI Elements")]
    public TMP_Dropdown resolutionDropdown;
    public Toggle vsyncToggle;
    public Toggle fullscreenToggle;
    // public Toggle motionBlurToggle;
    // public Toggle showNumbersToggle;
    public Slider soundSlider;
    public Slider musicSlider;
    public Slider fpsLimitSlider;
    public TMP_Dropdown graphicsQualityDropdown;
    public Slider resolutionScaleSlider;
    public Slider sensitivitySlider;
    public Slider fovSlider;

    [Space]
    [Header("Display Values")]
    [SerializeField] private TMP_Text soundText;
    [SerializeField] private TMP_Text musicText;
    [SerializeField] private TMP_Text fpsLimitText;
    [SerializeField] private TMP_Text resolutionScaleText;
    [SerializeField] private TMP_Text sensitivityText;
    [SerializeField] private TMP_Text fovText;

    void Start()
    {
        ph = PlayerHud.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            fullscreenToggle.isOn = !fullscreenToggle.isOn;
            changeFullscreen();
        }
    }

    public void changeAll()
    {
        changeFov();
        changeSoundVolume();
        changeFpsLimit();
        changeGraphicsQuality();
        changeMusicVolume();
        changeResolutionScale();
        changeSensitivity();
        changeVsync();
    }

    public void changeSoundVolume()
    {
        SoundVolume = (int)soundSlider.value;
        soundText.text = Mathf.Abs(SoundVolume * 5).ToString() + "%";
        soundMixer.SetFloat("Sound", SoundVolume);
        if(soundSlider.value <= -20)
            soundMixer.SetFloat("Sound", -80);
    }

    public void changeMusicVolume()
    {
        MusicVolume = (int)musicSlider.value;
        musicText.text = Mathf.Abs(musicSlider.value * 5).ToString() + "%";
        musicMixer.SetFloat("Music", MusicVolume);
        if(musicSlider.value <= -20)
            musicMixer.SetFloat("Music", -80);
    }

    public void changeVsync()
    {
        vsync = vsyncToggle.isOn;
        Debug.Log("vsync is " + vsync);
    }

    public void changeFullscreen()
    {
        fullscreen = fullscreenToggle.isOn;
        if (fullscreen)
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        else
            Screen.fullScreenMode = FullScreenMode.Windowed;
        Debug.Log("game fullscreen is " + fullscreen);
    }

    // public void changeMotionBlur()
    // {
    //     motionBlur = motionBlurToggle;
    //     Debug.Log("motionBlur is "  + motionBlur);
    // }

    public void changeFpsLimit()
    {
        fpsLimit = (int)fpsLimitSlider.value;
        fpsLimitText.text = (fpsLimitSlider.value).ToString() + " fps"; 
        // Mathf.Clamp(fpsLimit, 30, 240);
        Debug.Log("fps limit is " + fpsLimit);
        if(fpsLimitSlider.value >= 240)
            Debug.Log("unlimited fps");
            
    }

    public void changeSensitivity()
    {
        sensitivity = (int)sensitivitySlider.value;
        sensitivityText.text = sensitivitySlider.value.ToString();
        Debug.Log("sensitivity is " + sensitivity);
    }

    public void changeFov()
    {
        fov = (int)fovSlider.value;
        fovText.text = fovSlider.value.ToString();
        Debug.Log("field of view is " + fov);
    }

    public void changeResolutionScale()
    {
        resolutionScale = (int)resolutionScaleSlider.value;
        resolutionScaleText.text = (resolutionScaleSlider.value).ToString();
        // Mathf.Clamp(resolutionScale, 25, 200);

        foreach (UniversalRenderPipelineAsset asset in renderAssets)
        {
            asset.renderScale = (float)resolutionScale / 100;
        }

        Debug.Log("resolution scale is " + resolutionScale);
    }

    public void changeGraphicsQuality()
    {
        graphicsQuality = graphicsQualityDropdown.value;
        QualitySettings.SetQualityLevel(graphicsQuality);
    }

    public void changeScreenResolution()
    {
        // resolution = resolutionDropdown.value.ToString();
        // Screen.SetResolution(1920,1080,FullScreenMode.FullScreenWindow);
        Debug.Log("changed resolution to option nr. " + resolutionDropdown.value);
    }
}
