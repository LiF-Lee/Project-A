using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bullet_Controller : MonoBehaviour
{
    [SerializeField] private float Bullet_Speed = 8f;
    [SerializeField] private int Bullet_Damage = 28;
    [SerializeField] private GameObject Explosion_Effect;
    [SerializeField] private GameObject Damage_Effect;

    private List<Collider> colliders = new List<Collider>();

    private void Start()
    {
        SetActive_Delay(1f);
    }

    private void SetActive_Delay(float delay)
    {
        Invoke("Active_False", delay);
    }

    private void Active_False()
    {
        if (gameObject.activeSelf == true)
        {
            colliders = new List<Collider>();
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * Bullet_Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explosion();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!colliders.Contains(other)) { colliders.Add(other); }
    }

    private void OnTriggerExit(Collider other)
    {
        colliders.Remove(other);
    }
    
    private void Explosion()
    {
        GameObject _Explosion_Effect = Instantiate(Explosion_Effect);
        _Explosion_Effect.transform.position = transform.position;
        for (int i = 0; i < colliders.Count; i++)
        {
            if (colliders[i] == null)
                break;
            if (colliders[i].gameObject.tag == "Player" || colliders[i].gameObject.tag == "Enemy")
            {
                if (colliders[i].gameObject.GetComponent<HP_Controller>() == null)
                    return;
                int _Damage = Bullet_Damage + UnityEngine.Random.Range(0, 11);
                colliders[i].gameObject.GetComponent<HP_Controller>().Accumulative_HP(-_Damage);
            }
        }
        Active_False();
    }
}
