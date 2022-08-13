using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack_Controller : MonoBehaviour
{
    public GameObject Bullet;
    private Object_Manager object_manager;
    [SerializeField] private float _reload_time = 0.5f;
    private bool is_Reloading = false;
    private Movement_Controller _movement_controller;

    private void Start()
    {
        object_manager = GameObject.Find("Object_Manager").gameObject.GetComponent<Object_Manager>();
        _movement_controller = gameObject.GetComponent<Movement_Controller>();
    }
    
    public void Player_Fire()
    {
        if (is_Reloading == false)
        {
            is_Reloading = true;
            GameObject bullet = object_manager.Make_Obj("Bullet_Red");
            bullet.transform.position = transform.Find("Barrel_Center/Barrel/Bullet_Spawn_Point").gameObject.transform.position;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, _movement_controller.Barrel_Center_rotation, 0));
            Invoke("Reload_Done", _reload_time);
        }
    }

    private void Reload_Done()
    {
        is_Reloading = false;
    }
}
