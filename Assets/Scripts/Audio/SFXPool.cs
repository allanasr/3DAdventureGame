using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.Audio;

public class SFXPool : Singleton<SFXPool>
{
    private List<AudioSource> audioSources;

    public int poolSize = 10;

    public AudioMixerGroup mixerGroup;
    private int index = 0;

    private void Start()
    {
        CreatePool();
    }
    private void CreatePool()
    {
        audioSources = new List<AudioSource>();

        for(int i = 0; i < poolSize; i++)
        {
            CreateAudioSourceItem();
        }
    }

    private void CreateAudioSourceItem()
    {
        GameObject o = new GameObject("SFXPool");
        o.transform.SetParent(gameObject.transform);
        audioSources.Add(o.AddComponent<AudioSource>());
        o.GetComponent<AudioSource>().outputAudioMixerGroup = mixerGroup;

    }
    
    public void Play(SFXType sFXType)
    {
        var sfx = SoundManager.Instance.GetSFXByType(sFXType);

        audioSources[index].clip = sfx.audioClip;
        audioSources[index].Play();

        index++;
        if (index >= audioSources.Count) index = 0;
    }
}
