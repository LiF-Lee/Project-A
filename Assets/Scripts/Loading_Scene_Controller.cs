using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading_Scene_Controller : MonoBehaviour
{
    private AsyncOperation _operation;
    private static string _next_scene = "Title_Scene";

    private void Start()
    {
        Time.timeScale = 1f;
        Invoke("Start_Loading", 0.3f);
    }

    public static void LoadScene(string scene_name, string loading_scene_UI)
    {
        _next_scene = scene_name;
        SceneManager.LoadScene(loading_scene_UI);
    }

    private void Start_Loading()
    {
        StartCoroutine(Load_Scene_Process());
    }

    private IEnumerator Load_Scene_Process()
    {
        yield return null;
        _operation = SceneManager.LoadSceneAsync(_next_scene);
        _operation.allowSceneActivation = false;

        while (!_operation.isDone)
        {
            yield return null;
            if (_operation.progress >= 0.9f)
            {
                Invoke("Request_OK", 0.5f);
            }
        }
    }

    private void Request_OK()
    {
        _operation.allowSceneActivation = true;
    }
}