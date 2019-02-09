using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Start()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("BGM", defaultValue: 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFX", defaultValue: 1f);
    }

    public void OnChangedBGMVolume()
    {
        SoundManager.Instance.SetVolumeBGM(bgmSlider.value);
    }

    public void OnChangedSFXVolume()
    {
        SoundManager.Instance.SetVolumeSFX(sfxSlider.value);
    }

    public void OnButtonBack()
    {
        PlayerPrefs.SetFloat("BGM", bgmSlider.value);
        PlayerPrefs.SetFloat("SFX", sfxSlider.value);

        SceneManager.UnloadSceneAsync("SettingScene");
    }
}