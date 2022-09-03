using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject[] playerSets;

    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject player3;

    CinemachineVirtualCamera cMV;
    Transform player1Transform;
    Transform player2Transform;
    Transform player3Transform;

    void Start()
    {
        cMV = mainCamera.GetComponent<CinemachineVirtualCamera>();

        player1Transform = player1.transform;
        player2Transform = player2.transform;
        player3Transform = player3.transform;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchPlayer();
    }

    private void SwitchPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Player1Start();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Player2Start();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Player3Start();
        }

    }

    private void Player3Start()
    {
        player3.GetComponent<Transform>().position = player3Transform.position;

        for (int i = 0; i < playerSets.Length; i++)
        {
            playerSets[i].SetActive(false);
        }

        player3.SetActive(true);
        cMV.Follow = player3.transform;
        cMV.LookAt = player3Transform.transform;

        DampingSettings0();
    }

    private void Player2Start()
    {
        player2.GetComponent<Transform>().position = player2Transform.position;

        for (int i = 0; i < playerSets.Length; i++)
        {
            playerSets[i].SetActive(false);
        }

        player2.SetActive(true);
        cMV.Follow = player2.transform;

        DampingSettings1();
    }

    private void Player1Start()
    {
        player1.GetComponent<Transform>().position = player1Transform.position;

        for (int i = 0; i < playerSets.Length; i++)
        {
            playerSets[i].SetActive(false);
        }

        player1.SetActive(true);
        cMV.Follow = player1.transform;

        DampingSettings1();
    }

    private void DampingSettings0()
    {
        //for rockets
        cMV.GetCinemachineComponent<CinemachineTransposer>().m_XDamping = 0f;
        cMV.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = 0f;
        cMV.GetCinemachineComponent<CinemachineTransposer>().m_ZDamping = 0f;
    }

    private void DampingSettings1()
    {
        // for balls
        cMV.GetCinemachineComponent<CinemachineTransposer>().m_XDamping = 1f;
        cMV.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = 1f;
        cMV.GetCinemachineComponent<CinemachineTransposer>().m_ZDamping = 1f;
    }
}
