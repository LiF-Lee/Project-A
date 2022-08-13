using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Manager : MonoBehaviour
{
    [SerializeField] private GameObject Bullet_Red;
    [SerializeField] private GameObject Bullet_Black;
    private GameObject[] bullet_red;
    private GameObject[] bullet_black;

    private GameObject[] target_pool;

    private void Awake()
    {
        bullet_red = new GameObject[100];
        bullet_black = new GameObject[100];

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
