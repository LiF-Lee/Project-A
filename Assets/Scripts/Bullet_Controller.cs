using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    [SerializeField] private float Bullet_Speed = 8f;
    [SerializeField] private int Bullet_Damage = 28;
    [SerializeField] private GameObject Explosion_Effect;

    private List<Collider> colliders = new List<Collider>();

    private void Start()
    {
        Destroy(gameObject, 1f);
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
            if (colliders[i].gameObject.tag == "Player" || colliders[i].gameObject.tag == "Enemy")
            {
                if (colliders[i].gameObject.GetComponent<HP_Controller>() == null)
                    return;
                colliders[i].gameObject.GetComponent<HP_Controller>().Accumulative_HP(-Bullet_Damage);
            }
        }
        Destroy(gameObject);
    }
}
