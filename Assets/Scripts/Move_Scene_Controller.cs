using UnityEngine;

public partial class Move_Scene_Controller : MonoBehaviour
{
    [Tooltip("Target Scene Name to move")]
    [SerializeField] private string sceneName;

    [Tooltip("Select Loading Scene UI Mod")]
    [SerializeField] private Loading_Scene_UI loadingSceneUI;

    public void Move_Scene()
    {
        string _loadingSceneUI;
        switch (loadingSceneUI)
        {
            case Loading_Scene_UI.WHITE:
                _loadingSceneUI = "Loading_Scene_White";
                break;
            case Loading_Scene_UI.DARK:
                _loadingSceneUI = "Loading_Scene_Dark";
                break;
            default:
                _loadingSceneUI = "Loading_Scene_White";
                break;
        }
        Loading_Scene_Controller.LoadScene(sceneName, _loadingSceneUI);
    }
}