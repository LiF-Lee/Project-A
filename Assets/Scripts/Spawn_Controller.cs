using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Controller : MonoBehaviour
{
    [SerializeField] private GameObject Player_Prefab;

    private void Start()
    {
        GameObject myInstance = Instantiate(Player_Prefab);
    }

    private void Update()
    {
        //Debug.Log(GameObject.FindGameObjectsWithTag("Player"));
    }
}
