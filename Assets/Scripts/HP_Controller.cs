using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HP_Controller : MonoBehaviour
{
    private Player_Controller Player;
    private bool HP_Change_Detect = false;
    private int Current_HP, Max_HP, Save_Current_HP, Save_Max_HP;
    [SerializeField] private Slider HP_Slider;
    [SerializeField] private TextMeshProUGUI HP_Text;

    private void Start()
    {
        Player = gameObject.GetComponent<Player_Controller>();
        Get_Lastest_HP();
        Save_Current_HP = Current_HP;
        Save_Max_HP = Max_HP;
        Update_HP_Text();
    }

    private void Update()
    {
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

    private void Player_HP_Status()
    {
        if (Current_HP <= 0)
        {
            Player.Kill_Self("Kill");
        } 
    }

    public void Accumulative_HP(int value)
    {
        Player._HP.Player_Current_HP += value;
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