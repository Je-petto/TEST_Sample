using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundMG : MonoBehaviour
{
    public static SoundMG Instance = null;

    public List<AudioClip> scenesClip = new List<AudioClip>(); // 씬 인덱스에 맞는 BGM 클립

    public AudioSource BGMaudio; // BGM 재생용 AudioSource
    public AudioSource SFXaudio; // SFX 재생용 AudioSource
    [SerializeField] private AudioClip ButtonClip; // 버튼 클릭 SFX 클립

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 이 게임 오브젝트만 DontDestroyOnLoad 처리

            // BGMaudio와 SFXaudio가 이 게임 오브젝트 또는 자식에 있다면
            // 위의 DontDestroyOnLoad(gameObject) 호출 하나로 충분합니다.
            // 따라서 아래 줄들은 제거합니다.
            // DontDestroyOnLoad(BGMaudio); // 제거
            // DontDestroyOnLoad(SFXaudio); // 제거
            // DontDestroyOnLoad(ButtonClip); // 제거 (AudioClip은 에셋이므로 해당 없음)

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            // 이미 인스턴스가 존재하면 새로 생긴 것은 파괴
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        // 씬 로드 이벤트 리스너 해제 (메모리 누수 방지)
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode loadScene)
    {
        // BGM 재생 전 AudioSource 유효성 검사 (선택적이지만 안전함)
        if (BGMaudio == null)
        {
            Debug.LogError("BGMaudio가 할당되지 않았습니다!");
            return;
        }
        PlayScencBgm();
    }

    public void PlayScencBgm()
    {
        int Scene_i = SceneManager.GetActiveScene().buildIndex;

        if (Scene_i < scenesClip.Count && scenesClip[Scene_i] != null)
        {
            // 현재 재생 중인 클립과 같지 않을 때만 새로 재생 (선택적 최적화)
            if (BGMaudio.clip != scenesClip[Scene_i])
            {
                BGMaudio.Stop();
                BGMaudio.clip = scenesClip[Scene_i];
                BGMaudio.loop = true;
                BGMaudio.Play();
            }
        }
        else
        {
            // 해당 씬 인덱스에 클립이 없거나 null이면 BGM 정지
            BGMaudio.Stop();
            BGMaudio.clip = null;
             Debug.LogWarning($"씬 {Scene_i}에 대한 BGM 클립이 scenesClip 리스트에 없거나 null입니다.");
        }
    }

    public void OnButtonSound()
    {
        // SFX 재생 전 AudioSource 및 AudioClip 유효성 검사
        if (SFXaudio == null)
        {
            Debug.LogError("SFXaudio가 할당되지 않았습니다!");
            return;
        }
        if (ButtonClip == null)
        {
            Debug.LogError("ButtonClip이 할당되지 않았습니다!");
            return;
        }

        // SFXaudio가 활성화되어 있는지 확인 (보통은 필요 없을 수 있음)
        if (!SFXaudio.gameObject.activeInHierarchy)
        {
             Debug.LogWarning("SFXaudio 게임 오브젝트가 비활성화되어 있습니다.");
             // 필요하다면 여기서 활성화: SFXaudio.gameObject.SetActive(true);
             // 하지만 근본적으로 왜 비활성화되었는지 확인하는 것이 좋습니다.
             return; // 비활성화 상태면 재생 불가
        }
        if (!SFXaudio.enabled)
        {
            Debug.LogWarning("SFXaudio 컴포넌트가 비활성화(enabled=false)되어 있습니다.");
            // 필요하다면 여기서 활성화: SFXaudio.enabled = true;
            return; // 비활성화 상태면 재생 불가
        }


        // PlayOneShot은 AudioSource가 비활성화 상태여도 오류 없이 소리가 안 나므로
        // 위의 활성화 확인이 도움이 될 수 있습니다.
        SFXaudio.PlayOneShot(ButtonClip);
    }
}