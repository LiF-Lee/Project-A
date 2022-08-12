using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Controller : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    private int _default_rotation = -45;
    private Vector3 forward, right;
    private GameObject UI_Canvas;

    private void Start()
    {
        UI_Canvas = transform.Find("UI_Canvas").gameObject;
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
        UI_Canvas.transform.rotation = Quaternion.Euler(new Vector3(UI_Canvas.transform.rotation.x, _default_rotation - transform.rotation.y, UI_Canvas.transform.rotation.z));
    }
}