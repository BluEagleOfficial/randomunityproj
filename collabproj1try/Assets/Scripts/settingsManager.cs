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
    [SerializeField] private AudioMixer mixer;
    public Resolution resolution;
    UniversalRenderPipelineAsset[] renderAssets;

    public bool vsync;
    public bool fullscreen = true;
    public bool motionBlur;
    // [Tooltip("enable to show hp numbers on healthbar")] public bool showNumbers;

    // public int musicVolume;
    public int Volume = 100;
    public int fpsLimit = 60;
    public int graphicsQuality;
    public int sensitivity;
    public int fov;
    public int resolutionScale;

    // UI
    public TMP_Dropdown resolutionDropdown;

    public Toggle vsyncToggle;
    public Toggle fullscreenToggle;
    public Toggle motionBlurToggle;
    public Toggle showNumbersToggle;

    // public Slider musicVolume;
    public Slider VolumeSlider;
    public TMP_InputField fpsLimitInput;
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
        if(Input.GetKeyDown(KeyCode.F11))
        {
            fullscreenToggle.isOn = !fullscreenToggle.isOn;
            changeFullscreen();
        }
    }

    public void changeVolume()
    {
        Volume = (int)Volume.value;

        mixer.SetFloat("Master", Volume);
    }

    public void changeVsync()
    {
        vsync = vsyncToggle;
        Debug.Log("vsync is "  + vsync);
    }

    public void changeFullscreen()
    {
        fullscreen = fullscreenToggle;
        if(fullscreen)
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        else
            Screen.fullScreenMode = FullScreenMode.Windowed;
        Debug.Log("game is "  + fullscreen);
    }

    public void changeMotionBlur()
    {
        motionBlur = motionBlurToggle;
        Debug.Log("motionBlur is "  + motionBlur);
    }

    public void changeFpsLimit()
    {
        fpsLimit = int.Parse(fpsLimitInput.text);
        Debug.Log("fps limit is "  + fpsLimit);
    }

    public void changeSensitivity()
    {
        sensitivity = (int)sensitivitySlider.value;
        Debug.Log("sensitivity is "  + sensitivity);
    }

    public void changeFov()
    {
        fov = (int)fovSlider.value;
        Debug.Log("field of view is "  + fov);
    }

    public void changeResolutionScale()
    {
        resolutionScale = (int)resolutionScaleSlider.value;
        Mathf.Clamp(resolutionScale, 25, 200);

        foreach(UniversalRenderPipelineAsset asset in renderAssets)
        {
            asset.renderScale = resolutionScale / 100;
        }
        
        Debug.Log("resolution scale is "  + resolutionScale);
    }

    public void changeGraphicsQuality()
    {
        graphicsQuality = graphicsQualityDropdown.value;
        QualitySettings.SetQualityLevel(graphicsQuality);
    }
}
