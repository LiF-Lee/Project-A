using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Controller : MonoBehaviour
{
    [SerializeField] private float Move_Speed = 2f;
    [SerializeField] private float Barrel_Speed = 1.8f;
    
    public float Barrel_Center_rotation;
    
    private float _UI_Canvas_default_rotation;
    private Vector3 forward, right;
    private GameObject UI_Canvas, Barrel_Center;
    private Attack_Controller _attack_controller;
    private bool Respawn_Period = true;

    private void Start()
    {
        _attack_controller = gameObject.GetComponent<Attack_Controller>();
        UI_Canvas = transform.Find("UI_Canvas").gameObject;
        Barrel_Center = transform.Find("Barrel_Center").gameObject;
        _UI_Canvas_default_rotation = UI_Canvas.transform.rotation.y;
        Barrel_Center_rotation = Barrel_Center.transform.rotation.y;
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        Invoke("Respawn_Period_End", 2f);
    }

    private void FixedUpdate()
    {
        if (Input.anyKey && Respawn_Period == false)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                Player_Move();
            }
            
            if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L))
            {
                Barrel_Move();
            }

            if (Input.GetKey(KeyCode.Space) && _attack_controller.is_Reloading == false)
            {
                _attack_controller.Player_Fire();
            }
        }
    }

    private void Respawn_Period_End()
    {
        Respawn_Period = false;
    }

    private void Player_Move()
    {
        Vector3 rightMovement = right * Move_Speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * Move_Speed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
        UI_Canvas.transform.rotation = Quaternion.Euler(new Vector3(UI_Canvas.transform.rotation.x, _UI_Canvas_default_rotation - transform.rotation.y, UI_Canvas.transform.rotation.z));
        Barrel_Center.transform.rotation = Quaternion.Euler(new Vector3(Barrel_Center.transform.rotation.x, Barrel_Center_rotation - transform.rotation.y, Barrel_Center.transform.rotation.z));
    }

    private void Barrel_Move()
    {
        if (Input.GetKey(KeyCode.J))
        {
            Barrel_Center_rotation -= Barrel_Speed;
            Barrel_Center.transform.rotation = Quaternion.Euler(new Vector3(Barrel_Center.transform.rotation.x, Barrel_Center_rotation - transform.rotation.y, Barrel_Center.transform.rotation.z));
        }
        
        if (Input.GetKey(KeyCode.L))
        {
            Barrel_Center_rotation += Barrel_Speed;
            Barrel_Center.transform.rotation = Quaternion.Euler(new Vector3(Barrel_Center.transform.rotation.x, Barrel_Center_rotation - transform.rotation.y, Barrel_Center.transform.rotation.z));
        }
    }
}