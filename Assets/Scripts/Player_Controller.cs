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
    public GameObject Kill_Effect;

    private bool _Respawn_Period = true;

    private void Update()
    {
        Check_Player_Crash();
        Invoke("Respawn_Period_End", 2f);
    }

    private void Check_Player_Crash()
    {
        float _crash_area = -10f;
        if (transform.position.y <= _crash_area)
        {
            Kill_Self();
        }
    }

    public bool Get_Respawn_Period()
    {
        return _Respawn_Period;
    }
    
    public void Respawn_Period_End()
    {
        _Respawn_Period = false;
    }

    public void Kill_Self(string reason = "Default")
    {
        if (reason == "Kill" && Kill_Effect != null)
        {
            GameObject effect = Instantiate(Kill_Effect);
            effect.transform.position = transform.position;
        }
        Destroy(gameObject);
    }
}
