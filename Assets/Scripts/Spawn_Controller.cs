using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Controller : MonoBehaviour
{
    [SerializeField] private GameObject _player_prefab;
    private GameObject _player;
    private bool _spawn_delay_done = true;

    private void Start()
    {
        _player = Spawn_Player();
    }

    private void Update()
    {
        if (Check_Player_Alive() == false && _spawn_delay_done == true)
        {
            _spawn_delay_done = false;
            Invoke("Spawn_Delay_Done", 5.0f);
        }
    }

    private void Spawn_Delay_Done()
    {
        _spawn_delay_done = true;
        _player = Spawn_Player();
    }

    private bool Check_Player_Alive()
    {
        return _player != null;
    }

    private GameObject Spawn_Player()
    {
        GameObject player = Instantiate(_player_prefab);
        player.transform.position = transform.position;
        return player;
    }
}
