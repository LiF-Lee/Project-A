using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour
{
    public GameObject Bullet;
    private float _reload_time = 0.5f;
    public bool is_Reloading = false;
    private Movement_Controller _movement_controller;

    private void Start()
    {
        _movement_controller = gameObject.GetComponent<Movement_Controller>();
    }
    
    public void Player_Fire()
    {
        is_Reloading = true;
        GameObject bullet = Instantiate(Bullet);
        bullet.transform.position = transform.Find("Barrel_Center/Barrel/Bullet_Spawn_Point").gameObject.transform.position;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, _movement_controller.Barrel_Center_rotation, 0));
        Invoke("Reload_Done", _reload_time);
    }

    private void Reload_Done()
    {
        is_Reloading = false;
    }
}
