using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollowsPlayer : MonoBehaviour
{
    GameObject player;
    GameObject Tako;
    GameObject Dodger;
    GameObject Lastrada;
    GameObject MordFustang;
    GameObject Tirex;
    GameObject Thunderbolt;

    Transform followTarget;

    CinemachineVirtualCamera vcam;

    private void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        var transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();
        var composer = vcam.GetCinemachineComponent<CinemachineComposer>();

        player = GameObject.FindWithTag("Player");

        Tako = GameObject.Find("Tako");
        Dodger = GameObject.Find("Dodger");
        Lastrada = GameObject.Find("Lastrada");
        MordFustang = GameObject.Find("Mord Fustang");
        Tirex = GameObject.Find("Tirex");
        Thunderbolt = GameObject.Find("I-11 Thunderbolt");

        if (player.activeInHierarchy)
        {
            followTarget = player.transform;
            vcam.LookAt = followTarget;
            vcam.Follow = followTarget;
        }

        if(Tako.activeInHierarchy)
        {
            transposer.m_FollowOffset.x = 0f;
            transposer.m_FollowOffset.y = 2.64f;
            transposer.m_FollowOffset.z = -4.91f;

            composer.m_TrackedObjectOffset.x = 0f;
            composer.m_TrackedObjectOffset.y = 1.31f;
            composer.m_TrackedObjectOffset.z = -0.04f;
        }

        if (Dodger.activeInHierarchy)
        {
            transposer.m_FollowOffset.x = 0f;
            transposer.m_FollowOffset.y = 2.34f;
            transposer.m_FollowOffset.z = -4.91f;

            composer.m_TrackedObjectOffset.x = 0f;
            composer.m_TrackedObjectOffset.y = 1.31f;
            composer.m_TrackedObjectOffset.z = -0.04f;
        }

        if (Lastrada.activeInHierarchy)
        {
            transposer.m_FollowOffset.x = 0f;
            transposer.m_FollowOffset.y = 2.77f;
            transposer.m_FollowOffset.z = -6.95f;

            composer.m_TrackedObjectOffset.x = 0f;
            composer.m_TrackedObjectOffset.y = 1.31f;
            composer.m_TrackedObjectOffset.z = -0.04f;
        }

        if (MordFustang.activeInHierarchy)
        {
            transposer.m_FollowOffset.x = 0f;
            transposer.m_FollowOffset.y = 2.48f;
            transposer.m_FollowOffset.z = -4.96f;

            composer.m_TrackedObjectOffset.x = 0f;
            composer.m_TrackedObjectOffset.y = 1.5f;
            composer.m_TrackedObjectOffset.z = -0.04f;
        }

        if (Tirex.activeInHierarchy)
        {
            transposer.m_FollowOffset.x = 0f;
            transposer.m_FollowOffset.y = 3.25f;
            transposer.m_FollowOffset.z = -7f;

            composer.m_TrackedObjectOffset.x = 0f;
            composer.m_TrackedObjectOffset.y = 1.78f;
            composer.m_TrackedObjectOffset.z = -0.04f;
        }

        if (Thunderbolt.activeInHierarchy)
        {
            transposer.m_FollowOffset.x = 0f;
            transposer.m_FollowOffset.y = 4f;
            transposer.m_FollowOffset.z = -2f;

            composer.m_TrackedObjectOffset.x = 0f;
            composer.m_TrackedObjectOffset.y = 1.24f;
            composer.m_TrackedObjectOffset.z = -0.04f;
        }
    }
}
