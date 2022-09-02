using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    Camera mainCamera;
    

    void Start()
    {
        transform.Translate(0, 0, 0);
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float xVal = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yVal = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(xVal,0,yVal);
    }
}
