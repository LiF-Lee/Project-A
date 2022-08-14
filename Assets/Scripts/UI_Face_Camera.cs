using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_Face_Camera : MonoBehaviour
{
    [SerializeField] private GameObject UI_Canvas;
    [SerializeField] private bool Front = false;

    private void Start()
    {
        UI_Canvas.transform.position = new Vector3(UI_Canvas.transform.position.x, UI_Canvas.transform.position.y, UI_Canvas.transform.position.z);
    }

    public void UI_Move_Front()
    {
        if (Front == true)
            UI_Canvas.transform.position += new Vector3(2, 1.6f, -2f);
    }

    private void Update()
    {
        Camera camera = Camera.main;
        UI_Canvas.transform.LookAt(UI_Canvas.transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
        Vector3 FORWARD = UI_Canvas.transform.TransformDirection(Vector3.forward);
    }
}
