using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using TMPro;
using UnityEngine.UI;
using System;

public class settingsManager : MonoBehaviour
{
    [Header("Components")]
    private PlayerHud ph;
    private CameraRotate camRot;
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
    public int graphicsQuality = 2;
    public int sensitivity = 100;
    public int fov = 60;
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
        camRot = Camera.main.GetComponentInParent<CameraRotate>();
        TimeSpan timeSpan = TimeSpan.FromSeconds(70);
        string timeString = timeSpan.ToString("mm\\:ss"); // Output: 01:10
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            fullscreenToggle.isOn = !fullscreenToggle.isOn;
            changeFullscreen();
        }
        updateAll();
        if(!MenuManager.gamePaused)
            this.gameObject.SetActive(false);
    }
    void updateAll(){
        changeGraphicsQuality();
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
        soundText.text = Mathf.Abs((-SoundVolume * 5) - 100).ToString() + "%";
        soundMixer.SetFloat("Sound", SoundVolume);
        if(soundSlider.value <= -20)
            soundMixer.SetFloat("Sound", -80);
    }

    public void changeMusicVolume()
    {
        MusicVolume = (int)musicSlider.value;
        musicText.text = MathF.Abs((-MusicVolume * 5) - 100).ToString() + "%";
        musicMixer.SetFloat("Music", MusicVolume);
        if(musicSlider.value <= -20)
            musicMixer.SetFloat("Music", -80);
    }

    public void changeVsync()
    {
        vsync = vsyncToggle.isOn;
        if(vsync)
            QualitySettings.vSyncCount = 2;
        else
            QualitySettings.vSyncCount = 0;
    }

    public void changeFullscreen()
    {
        fullscreen = fullscreenToggle.isOn;
        if (fullscreen)
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        else
            Screen.fullScreenMode = FullScreenMode.Windowed;
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
        Application.targetFrameRate = fpsLimit;
        if(fpsLimitSlider.value >= 240)
            Application.targetFrameRate = -1;
            
    }

    public void changeSensitivity()
    {
        sensitivity = (int)sensitivitySlider.value;
        sensitivityText.text = sensitivitySlider.value.ToString();
        camRot.sensitivity = sensitivity;
    }

    public void changeFov()
    {
        fov = (int)fovSlider.value;
        fovText.text = fovSlider.value.ToString();
        Camera.main.fieldOfView = fov;
    }

    public void changeResolutionScale()
    {
        resolutionScale = (int)resolutionScaleSlider.value;
        resolutionScaleText.text = (resolutionScaleSlider.value).ToString();

        foreach (UniversalRenderPipelineAsset asset in renderAssets)
        {
            asset.renderScale = (float)resolutionScale / 100;
        }
    }

    public void changeGraphicsQuality()
    {
        graphicsQuality = graphicsQualityDropdown.value;
        // graphicsQualityDropdown.captionText.text = graphicsQualityDropdown.itemText.text;
        QualitySettings.SetQualityLevel(graphicsQuality);
    }

    public void changeScreenResolution()
    {
        // resolution = resolutionDropdown.value.ToString();
        // Screen.SetResolution(1920,1080,FullScreenMode.FullScreenWindow);
        // Debug.Log("changed resolution to option nr. " + resolutionDropdown.value);
    }
}
