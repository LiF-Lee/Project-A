using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HP
{
    public int Player_Current_HP;
    public int Player_Max_HP;
}

public class Player_Controller : MonoBehaviour
{
    [Header("Player Setting")]
    public HP _HP;
    
    private void Update()
    {
        Check_Player_Crash();
    }

    private void Check_Player_Crash()
    {
        float _crash_area = -10f;
        if (transform.position.y <= _crash_area)
        {
            Kill_Self();
        }
    }

    public void Kill_Self()
    {
        Destroy(gameObject);
    }
}
