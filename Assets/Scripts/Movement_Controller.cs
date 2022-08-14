using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Controller : MonoBehaviour
{
    [SerializeField] private float Move_Speed = 2f;
    [SerializeField] private float Barrel_Speed = 1.8f;
    
    public float Barrel_Center_rotation;
    private Vector3 forward, right;
    private GameObject Barrel_Center;
    private Player_Controller Player;
    private Attack_Controller _attack_controller;

    private void Start()
    {
        Player = gameObject.GetComponent<Player_Controller>();
        _attack_controller = gameObject.GetComponent<Attack_Controller>();
        Barrel_Center = transform.Find("Barrel_Center").gameObject;
        Barrel_Center_rotation = Barrel_Center.transform.rotation.y;
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    private void FixedUpdate()
    {
        if (Input.anyKey && Player.Get_Respawn_Period() == false)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                Player_Move();
            }
            
            if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L))
            {
                Barrel_Move();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                _attack_controller.Player_Fire();
            }
        }
    }

    private void Player_Move()
    {
        Vector3 rightMovement = right * Move_Speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * Move_Speed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
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