using UnityEngine;

public partial class Move_Scene_Controller : MonoBehaviour
{
    [Tooltip("Target Scene Name to move")]
    [SerializeField] private string _scene_name;

    [Tooltip("Select Loading Scene UI Mod")]
    [SerializeField] private Loading_Scene_UI _loading_scene_UI;

    public void Move_Scene()
    {
        string loading_scene_UI;
        switch (_loading_scene_UI)
        {
            case Loading_Scene_UI.WHITE:
                loading_scene_UI = "Loading_Scene_White";
                break;
            case Loading_Scene_UI.DARK:
                loading_scene_UI = "Loading_Scene_Dark";
                break;
            default:
                loading_scene_UI = "Loading_Scene_White";
                break;
        }
        Loading_Scene_Controller.LoadScene(_scene_name, loading_scene_UI);
    }
}