using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using Singleton;

public class EffectsManager : Singleton<EffectsManager>
{
    public PostProcessVolume processVolume;

    [SerializeField] private Vignette vignette;

    public float duration = 1f;

    [NaughtyAttributes.Button]
    public void ChangeVignette()
    {
        StartCoroutine(FlashColorVignette());
    }

    IEnumerator FlashColorVignette()
    {
        Vignette temp;

        if (processVolume.profile.TryGetSettings<Vignette>(out temp))
        {
            vignette = temp;
        }
        ColorParameter c = new ColorParameter();

        float time = 0;

        while (time < duration)
        {
            c.value = Color.Lerp(Color.black, Color.red, time / duration);
            time += Time.deltaTime;
            vignette.color.Override(c);
            yield return new WaitForEndOfFrame();
        }

        time = 0;
        
        while (time < duration)
        {
            c.value = Color.Lerp(Color.red, Color.black, time / duration);
            time += Time.deltaTime;
            vignette.color.Override(c);
            yield return new WaitForEndOfFrame();
        }

    }
}
