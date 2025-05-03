using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundMG : MonoBehaviour
{
    public static SoundMG Instance = null;

    // 씬 인덱스에 맞는 BGM 클립 (인덱스 0은 씬 0번의 BGM)
    public List<AudioClip> scenesClip = new List<AudioClip>();

    public AudioSource BGMaudio, SFXaudio;
    [SerializeField] private AudioClip ButtonClip;
    

    public void Awake()
    { 
        if( Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadScene)
    {
        PlayScencBgm();
    }

    public void PlayScencBgm()
    {
        int Scene_i = SceneManager.GetActiveScene().buildIndex;

        if( Scene_i < scenesClip.Count && scenesClip[Scene_i] != null)
        {
            BGMaudio.Stop();
            BGMaudio.clip = scenesClip[Scene_i];
            BGMaudio.loop =true;
            BGMaudio.Play();
        }
        // else
        // {
        //     ($"Scene {Scene_i}에 BGM 클립이 할당되지 않았습니다.");
        // }
    }

    // void Start()
    // {
    //     if( BGMaudio == null || SFXaudio == null)
    //     {
    //         AudioSource[] audioSources = GetComponentsInChildren<AudioSource>();
    //         foreach( var a in audioSources)
    //         {
    //             if( a != BGMaudio && BGMaudio == null) BGMaudio = a;
    //             else if ( a != SFXaudio &&  SFXaudio == null) SFXaudio = a;
    //         }
    //     }
    //     if(BGMaudio == null)
    //         GetComponentInChildren<AudioSource>();
    //     if(SFXaudio == null)
    //         GetComponentInChildren<AudioSource>();   
    // }
    
    // public void PlayBGM(AudioClip clip, bool IsChangeScene)
    // {
    //     if(IsChangeScene)
    //         for( int i = 0; i < scenesClip.Count; i++)
    //             if(SceneManager.GetActiveScene().buildIndex == i)
    //                 BGMaudio.PlayOneShot(scenesClip[i]);
    //     else
    //         BGMaudio.PlayOneShot(clip);
    // }
    
    // public void PlaySFX(AudioClip clip , bool IsButton)
    // {
    //     if(IsButton)
    //         SFXaudio.PlayOneShot(ButtonClip);
    //     else
    //         SFXaudio.PlayOneShot(clip);
    // }


}
