using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMG : MonoBehaviour
{
    public void TapToStart()
    {
        // Debug.Log("탭 투 스타트");

        SceneManager.LoadScene(2,LoadSceneMode.Single);
    }

    public void BackToMainScene()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void LoadingScene()
    {
        SceneManager.LoadScene(3,LoadSceneMode.Single);
    }
    
    public void IngameScene()
    {
        SceneManager.LoadScene(4,LoadSceneMode.Single);
    }
}