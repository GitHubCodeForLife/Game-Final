using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioBgMixer;

    public AudioMixer audioEffectMixer;

    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public Toggle fullScreenToggle;
    public Dropdown graphicsDropdown;
    public Slider bgAudio;
    public Slider effectAudio;

    void Start()
    {
        //Audio 
        float bg;
        audioBgMixer.GetFloat("bg", out bg);
        bgAudio.value = bg;
        float effect;
        audioEffectMixer.GetFloat("effect", out effect);
        effectAudio.value = effect;

        //Setting Is Full Screen
        fullScreenToggle.isOn = Screen.fullScreen;
        //Debug.Log("Full Screen: "+Screen.fullScreen);
        //Setting Quality

        graphicsDropdown.value = QualitySettings.GetQualityLevel();
        //    Debug.Log("Current graphics value: " + QualitySettings.GetQualityLevel());
        //Setting Resolution
        resolutions = Screen.resolutions;

        int currentResolutionIndex = 0;
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {

            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width
            && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
//        Debug.Log("Current graphics value: " + QualitySettings.GetQualityLevel());

    }

    public void SetVolume(float volume)
    {
        audioBgMixer.SetFloat("bg", volume);
    }
    public void SetEffectVolume(float volume)
    {
        audioEffectMixer.SetFloat("effect", volume);
    }
}
