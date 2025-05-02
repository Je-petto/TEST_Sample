using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStart : MonoBehaviour
{
    [SerializeField] private AudioClip SFXclip;
    public void TapToStart()
    {
        // Debug.Log("탭 투 스타트");

        SceneManager.LoadScene(2,LoadSceneMode.Single);
        SoundMG.Instance.PlaySFX(null, true);
    }
}
