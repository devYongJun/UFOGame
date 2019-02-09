using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioClip[] backgroundMusics;
    public AudioClip[] soundEffects;

    public AudioSource bgmPlayer;
    public AudioSource sfxPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        bgmPlayer.volume = PlayerPrefs.GetFloat("BGM", defaultValue: 1f);
        sfxPlayer.volume = PlayerPrefs.GetFloat("SFX", defaultValue: 1f);
    }

    public void PlayBGM(string clipName)
    {
        if (bgmPlayer.isPlaying && bgmPlayer.clip.name == clipName)
        {
            return;
        }

        foreach (AudioClip clip in backgroundMusics)
        {
            if (clip.name.Equals(clipName))
            {
                bgmPlayer.clip = clip;
                bgmPlayer.Play();
                break;
            }
        }
    }

    public void SetVolumeBGM(float volume)
    {
        bgmPlayer.volume = volume;
    }

    public void PlaySFX(string clipName)
    {
        foreach (AudioClip clip in soundEffects)
        {
            if (clip.name.Equals(clipName))
            {
                sfxPlayer.PlayOneShot(clip);
                break;
            }
        }
    }

    public void SetVolumeSFX(float volume)
    {
        sfxPlayer.volume = volume;
    }


}