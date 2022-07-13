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
    
    /// <summary>
    /// Loads the easy level.
    /// </summary>
    public void LoadEasyLevel()
    {
        SceneManager.LoadScene(_easyLevel);
    }

    /// <summary>
    /// Loads the medium level.
    /// </summary>
    public void LoadMediumLevel()
    {
        SceneManager.LoadScene(_mediumLevel);
    }
    
    /// <summary>
    /// Loads the hard level.
    /// </summary>
    public void LoadHardLevel()
    {
        SceneManager.LoadScene(_hardLevel);
    }
    
    /// <summary>
    /// Loads the very hard level.
    /// </summary>
    public void LoadVeryHardLevel()
    {
        SceneManager.LoadScene(_veryHardLevel);
    }
    
    /// <summary>
    /// Exits the game.
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
    
    /// <summary>
    /// Sets the volume.
    /// </summary>
    /// <param name="volume">Value of volume.</param>
    public void SetVolume(float volume) 
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    /// <summary>
    /// Sets the brightness.
    /// </summary>
    /// <param name="brightness">Value of the brightness.</param>
    public void SetBrightness(float brightness)
    {
        _brightnessLevel = brightness;
        brightnessTextValue.text = brightness.ToString("0.0");
    }
    
    /// <summary>
    /// Applies the changed settings.
    /// </summary>
    public void SettingsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", _brightnessLevel);
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    /// <summary>
    /// Displays the confirmation box.
    /// </summary>
    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
