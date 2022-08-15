using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HP_Controller : MonoBehaviour
{
    private Player_Controller Player;
    private Object_Manager object_manager;
    private bool HP_Change_Detect = false;
    private int Current_HP, Max_HP, Save_Current_HP, Save_Max_HP;
    [SerializeField] private Slider HP_Slider;
    [SerializeField] private TextMeshProUGUI HP_Text;
    private float _timer = 0f;
    private bool _timer_count = true;
    private bool _player_status_normal = false;

    private void Start()
    {
        object_manager = GameObject.Find("Object_Manager").gameObject.GetComponent<Object_Manager>();
        Player = gameObject.GetComponent<Player_Controller>();
        Get_Lastest_HP();
        Save_Current_HP = Current_HP;
        Save_Max_HP = Max_HP;
        Update_HP_Text();
    }

    private void Update()
    {
        Auto_Heal();
        Get_Lastest_HP();
        Player_HP_Status();
        Update_HP_Text();
        if ((Save_Current_HP != Current_HP || Save_Max_HP != Max_HP) && HP_Change_Detect == false)
        {
            HP_Change_Detect = true;
            Save_Current_HP = Current_HP;
            StartCoroutine(Update_HP_Slider());
        }
    }

    private void Auto_Heal()
    {
        if (_player_status_normal == true)
            return;

        if (_timer_count == true)
        {
            if (_player_status_normal == false)
                _timer += Time.deltaTime;

            if (_timer >= 10f)
                _player_status_normal = true;
        }
        else
        {
            _timer = 0f;
            _timer_count = true;
            _player_status_normal = false;
        }

        if (_player_status_normal == true)
        {
            Heal_Invoke();
        }
    }

    private void Heal_Invoke()
    {
        if (Max_HP <= Current_HP)
            return;
        if (_player_status_normal == true)
        {
            Accumulative_HP((int)Math.Floor(Max_HP * 0.01 * 10));
            Invoke("Heal_Invoke", 2f);
        }
    }

    private void Player_HP_Status()
    {
        if (Current_HP <= 0)
        {
            Player.Kill_Self("Kill");
        } 
    }

    public void Player_Status_Not_Normalk()
    {
        _player_status_normal = false;
        _timer_count = false;
    }

    public void Accumulative_HP(int value)
    {
        if (Player.Get_Respawn_Period() == false)
        {
            string _damage_text = "";
            if (value >= 0)
            {
                if (Max_HP < Current_HP + value)
                {
                    value = Max_HP - Current_HP;
                }
                _damage_text = $"<color=#00DB51>+{value}</color>";
            }
            else
            {
                Player_Status_Not_Normalk();
                _damage_text = $"<color=#FF5733>{value}</color>";
            }

            GameObject _Damage_Effect = object_manager.Make_Obj("Damage_Effect");
            if (_Damage_Effect != null)
            {
                _Damage_Effect.transform.position = gameObject.transform.position;
                _Damage_Effect.transform.Find("Damage").gameObject.GetComponent<TextMeshProUGUI>().text = _damage_text;
                _Damage_Effect.gameObject.GetComponent<Damage_Effect_Controller>().Hit();
            }
            Player._HP.Player_Current_HP += value;
        }
    }

    private void Get_Lastest_HP()
    {
        Current_HP = Player._HP.Player_Current_HP;
        Max_HP = Player._HP.Player_Max_HP;
    }
    
    private void Update_HP_Text()
    {
        if (HP_Text != null)
        {
            HP_Text.text = $"<b>{Current_HP}</b><color=\"yellow\"> / </color><b>{Max_HP}</b>";
        }
    }

    private bool is_HP_Over_Value()
    {
        return (Current_HP / (Max_HP * 0.01f) > 100 && HP_Slider.value == 1) || (Current_HP / (Max_HP * 0.01f) < 0 && HP_Slider.value == 0);
    }

    private IEnumerator Update_HP_Slider()
    {
        yield return null;
        while (HP_Change_Detect)
        {
            yield return null;
            HP_Slider.value = Mathf.MoveTowards(HP_Slider.value, Current_HP / (Max_HP * 0.01f) * 0.01f, Time.deltaTime * 0.6f);

            if ((int)(HP_Slider.value * 100) == (int)(Current_HP / (Max_HP * 0.01f)) || is_HP_Over_Value())
            {
                HP_Change_Detect = false;
            }
        }
    }
}