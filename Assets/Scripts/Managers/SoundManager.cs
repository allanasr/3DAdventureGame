using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    public List<MusicSetup> musicSetups;
    public List<SfxSetup> sfxSetups;

    public AudioSource audioSource;
    public AudioMixerGroup audioMixer;

    private bool muted = false;
    public void PlayMusicByType(MusicType musicType)
    {
        var music = musicSetups.Find(i => i.musicType == musicType);
        audioSource.clip = music.audioClip;
        audioSource.Play();
    }

    public MusicSetup GetMusicByType(MusicType musicType)
    {
        return musicSetups.Find(i => i.musicType == musicType);
    }
    public SfxSetup GetSFXByType(SFXType sfxType)
    {
        return sfxSetups.Find(i => i.sfxSetup == sfxType);
    }

    [NaughtyAttributes.Button]
    public void ToggleSound()
    {
        if (!muted)
        {
            audioMixer.audioMixer.SetFloat("MasterVolume", -80f);
            muted = true;
        }
        else
        {
            audioMixer.audioMixer.SetFloat("MasterVolume", 0f);
            muted = false;
        }
    }
}

public enum MusicType
{
    TYPE1,
    TYPE2,
    TYPE3
}

[System.Serializable]
public class MusicSetup
{
    public MusicType musicType;
    public AudioClip audioClip;
}

public enum SFXType
{
    NONE,
    TYPE1,
    TYPE2,
    TYPE3
}
[System.Serializable]
public class SfxSetup
{
    public SFXType sfxSetup;
    public AudioClip audioClip;
}