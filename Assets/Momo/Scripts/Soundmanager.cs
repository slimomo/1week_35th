using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Soundmanager : MonoBehaviour
{
     [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;

    [SerializeField] List<BGMSoundData> bgmSoundDatas;
    [SerializeField] List<SESoundData> seSoundDatas;

    public float masterVolume = 1;
    public float bgmMasterVolume = 1;
    public float seMasterVolume = 1;


    public static Soundmanager Instance { get; private set; }

    Tween tw;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        masterVolume = 1;
        bgmMasterVolume = 1;
        seMasterVolume = 1;
        tw.Kill();
    }

    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
        bgmAudioSource.Play();
    }


    public void QuietBGM()
    {
        bgmAudioSource = GetComponent<AudioSource>();
        bgmAudioSource.volume = 0.2f;
        //音量を半分にしている
        //bgmMasterVolume = 0.5f;
    }


    public void StopBGM()
    {
        tw = bgmAudioSource.DOFade(endValue: 0f, duration: 0.5f)
            .SetLink(gameObject);
        //bgmAudioSource.Stop();
    }
    

    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
    }

}

[System.Serializable]
public class BGMSoundData
{
    public enum BGM
    {
        Title,
        Main,
        Clear,
        GameOver,
        // これがラベルになる
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class SESoundData
{
    public enum SE
    {
        Button,
        Cacnel,
        Transition,
        ItemGet,
        Death,
        Damage,
        Use,
        // これがラベルになる
    }


    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}
