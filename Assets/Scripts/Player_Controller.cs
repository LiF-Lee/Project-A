using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private float _crash_area = -10f;
    
    private void Update()
    {
        Check_Player_Crash();
    }

    private void Check_Player_Crash()
    {
        if (transform.position.y <= _crash_area)
        {
            Kill_Player();
        }
    }

    private void Kill_Player()
    {
        Destroy(gameObject);
    }
}
