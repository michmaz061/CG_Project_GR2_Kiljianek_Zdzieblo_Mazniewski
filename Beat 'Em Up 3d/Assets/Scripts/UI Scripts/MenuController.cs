using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("Sound Volume")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    
    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;
    
    [Header("Brightness")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTextValue = null;
    private float _brightnessLevel;
    
    [Header("Level Loading")]
    public string _easyLevel;
    public string _mediumLevel;
    public string _hardLevel;
    public string _veryHardLevel;
    
    public void LoadEasyLevel()
    {
        SceneManager.LoadScene(_easyLevel);
    }

    public void LoadMediumLevel()
    {
        SceneManager.LoadScene(_mediumLevel);
    }
    
    public void LoadHardLevel()
    {
        SceneManager.LoadScene(_hardLevel);
    }
    
    public void LoadVeryHardLevel()
    {
        SceneManager.LoadScene(_veryHardLevel);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    
    public void SetVolume(float volume) 
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void SetBrightness(float brightness)
    {
        _brightnessLevel = brightness;
        brightnessTextValue.text = brightness.ToString("0.0");
    }
    
    public void SettingsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", _brightnessLevel);
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
