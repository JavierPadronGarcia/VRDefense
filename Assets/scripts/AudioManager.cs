using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource sfxSource;
    public AudioSource musicSource;

    private Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();
    private List<AudioClip> musicClips = new List<AudioClip>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        LoadAudioFiles();
    }

    private void LoadAudioFiles()
    {
        AudioClip[] loadedSFX = Resources.LoadAll<AudioClip>("SFX");
        foreach (AudioClip clip in loadedSFX)
        {
            sfxClips[clip.name] = clip;
        }

        musicClips = Resources.LoadAll<AudioClip>("Music").ToList();
    }

    public void PlaySFX(string clipName)
    {
        if (sfxClips.TryGetValue(clipName, out AudioClip clip))
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("SFX '" + clipName + "' not found in the dictionary.");
        }
    }

    public void PlayMusic(int index)
    {
        if (index >= 0 && index < musicClips.Count)
        {
            musicSource.clip = musicClips[index];
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Invalid music index: " + index);
        }
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
        sfxSource.volume = volume;
    }

}
