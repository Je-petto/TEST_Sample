using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundMG : MonoBehaviour
{
    public static SoundMG Instance = null;

    public List<AudioClip> scenesClip = new List<AudioClip>();
    public AudioSource BGMaudio, SFXaudio;
    [SerializeField] private AudioClip ButtonClip;
    

    public void Awake()
    { 
        if( Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if(BGMaudio == null)
            GetComponentInChildren<AudioSource>();
        if(SFXaudio == null)
            GetComponentInChildren<AudioSource>();   
    }
    
    public void PlayBGM(AudioClip clip, bool IsChangeScene)
    {
        if(IsChangeScene)
            for( int i = 0; i < scenesClip.Count; i++)
                if(SceneManager.GetActiveScene().buildIndex == i)
                    BGMaudio.PlayOneShot(scenesClip[i]);
        else
            BGMaudio.PlayOneShot(clip);
    }
    
    public void PlaySFX(AudioClip clip , bool IsButton)
    {
        if(IsButton)
            SFXaudio.PlayOneShot(ButtonClip);
        else
            SFXaudio.PlayOneShot(clip);
    }


}
