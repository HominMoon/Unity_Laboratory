using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    [SerializeField] float movePower = 10f;
    [SerializeField] float jumpPower = 10f;

    Rigidbody playerRigidBody;

    float xVal, yVal;
    bool isJump = false;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Plane")
        {
            isJump = false;
        }
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
        {
            playerRigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
        }
    }

    private void PlayerMove()
    {
        xVal = Input.GetAxis("Horizontal");
        yVal = Input.GetAxis("Vertical");

        playerRigidBody.AddForce(new Vector3(xVal, 0, yVal) * movePower, ForceMode.Impulse);
    }


}
