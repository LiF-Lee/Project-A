using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Controller : MonoBehaviour
{
    [SerializeField] private GameObject _player_prefab;
    private GameObject _player;

    private void Start()
    {
        _player = Spawn_Player();
    }

    private void Update()
    {
        
    }

    private GameObject Spawn_Player()
    {
        GameObject player = Instantiate(_player_prefab);
        player.transform.position = transform.position;
        return player;
    }
}
