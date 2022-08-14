using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Manager : MonoBehaviour
{
    [SerializeField] private GameObject Bullet_Red;
    [SerializeField] private GameObject Bullet_Black;
    [SerializeField] private GameObject Damage_Effect;
    private GameObject[] bullet_red;
    private GameObject[] bullet_black;
    private GameObject[] damage_effect;

    private GameObject[] target_pool;

    private void Awake()
    {
        bullet_red = new GameObject[50];
        bullet_black = new GameObject[50];
        damage_effect = new GameObject[50];

        Generate();
    }

    private void Generate()
    {
        for (int i = 0; i < bullet_red.Length; i++)
        {
            bullet_red[i] = Instantiate(Bullet_Red);
            bullet_red[i].SetActive(false);
        }

        for (int i = 0; i < bullet_black.Length; i++)
        {
            bullet_black[i] = Instantiate(Bullet_Black);
            bullet_black[i].SetActive(false);
        }
        
        for (int i = 0; i < damage_effect.Length; i++)
        {
            damage_effect[i] = Instantiate(Damage_Effect);
            damage_effect[i].SetActive(false);
        }
    } 

    public GameObject Make_Obj(string type)
    {
        switch (type)
        {
            case "Bullet_Red":
                target_pool = bullet_red;
                break;
            case "Bullet_Black":
                target_pool = bullet_black;
                break;
            case "Damage_Effect":
                target_pool = damage_effect;
                break;
        }

        for (int i = 0; i < target_pool.Length; i++)
        {
            if (target_pool[i].activeSelf == false)
            {
                target_pool[i].SetActive(true);
                return target_pool[i];
            }
        }

        return null;
    }
}
