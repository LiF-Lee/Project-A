using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Follow_Player : MonoBehaviour
{
    public GameObject tPlayer;
    private Transform tFollowTarget;
    private CinemachineVirtualCamera vcam;

    private void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (tPlayer == null)
        {
            tPlayer = GameObject.FindWithTag("Player");
            if (tPlayer == null)
                return;
        }
        tFollowTarget = tPlayer.transform;
        vcam.LookAt = tFollowTarget;
        vcam.Follow = tFollowTarget;
    }
}