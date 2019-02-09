using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlayBGM("scifi");
    }

    public void OnButtonStart()
    {
        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
    }

    public void OnButtonSetting()
    {
        SceneManager.LoadScene("SettingScene", LoadSceneMode.Additive);
    }

    public void OnButtonExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

