using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Face_Camera : MonoBehaviour
{
    [SerializeField] private GameObject UI_Canvas;
    
    private void Update()
    {
        Camera camera = Camera.main;
        UI_Canvas.transform.LookAt(UI_Canvas.transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
    }
}
