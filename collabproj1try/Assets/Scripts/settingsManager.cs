using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using TMPro;
using UnityEngine.UI;

public class settingsManager : MonoBehaviour
{
    private PlayerHud ph;
    [SerializeField] private AudioMixer soundMixer;
    [SerializeField] private AudioMixer musicMixer;
    public Resolution resolution;
    [SerializeField]
    UniversalRenderPipelineAsset[] renderAssets;

    public bool vsync;
    public bool fullscreen = true;
    // public bool motionBlur;
    // [Tooltip("enable to show hp numbers on healthbar")] public bool showNumbers;

    // public int musicVolume;
    public int SoundVolume = 100;
    public int MusicVolume = 100;
    public int fpsLimit = 60;
    public int graphicsQuality;
    public int sensitivity;
    public int fov;
    public int resolutionScale = 100;

    // UI
    public TMP_Dropdown resolutionDropdown;

    public Toggle vsyncToggle;
    public Toggle fullscreenToggle;
    // public Toggle motionBlurToggle;
    // public Toggle showNumbersToggle;

    public Slider soundSlider;
    public Slider musicSlider;
    public Slider fpsLimitSlider;
    public TMP_Dropdown graphicsQualityDropdown;
    public Slider sensitivitySlider;
    public Slider fovSlider;
    public Slider resolutionScaleSlider;

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
        soundMixer.SetFloat("Sound", SoundVolume);
        if(soundSlider.value <= -20)
            soundMixer.SetFloat("Sound", -80);
    }

    public void changeMusicVolume()
    {
        MusicVolume = (int)musicSlider.value;
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
        fpsLimit = (int)fpsLimitSlider.value + 30; // as explained below, compensating
        Mathf.Clamp(fpsLimit, 30, 240);
        Debug.Log("fps limit is " + fpsLimit);
    }

    public void changeSensitivity()
    {
        sensitivity = (int)sensitivitySlider.value;
        Debug.Log("sensitivity is " + sensitivity);
    }

    public void changeFov()
    {
        fov = (int)fovSlider.value;
        Debug.Log("field of view is " + fov);
    }

    public void changeResolutionScale()
    {
        resolutionScale = (int)resolutionScaleSlider.value + 25; // since the min value of the slider is not equal to min scale value, compensating
        Mathf.Clamp(resolutionScale, 30, 200);

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
