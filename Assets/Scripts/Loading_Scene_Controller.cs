using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading_Scene_Controller : MonoBehaviour
{
    private AsyncOperation operation;
    private static string nextScene = "Title_Scene";

    private void Start()
    {
        Time.timeScale = 1f;
        Invoke("StartLoading", 0.3f);
    }

    public static void LoadScene(string sceneName, string loadingSceneUI)
    {
        nextScene = sceneName;
        SceneManager.LoadScene(loadingSceneUI);
    }

    private void StartLoading()
    {
        StartCoroutine(LoadSceneProcess());
    }

    private IEnumerator LoadSceneProcess()
    {
        yield return null;
        operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;
            if (operation.progress >= 0.9f)
            {
                Invoke("RequestOK", 0.5f);
            }
        }
    }

    private void RequestOK()
    {
        operation.allowSceneActivation = true;
    }
}