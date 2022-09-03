using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Movement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float drivingForce = 10f;
    [SerializeField] float rotationForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * drivingForce * Time.deltaTime, ForceMode.Impulse);
        }

        float xRotate = Input.GetAxis("Horizontal") * rotationForce * Time.deltaTime;
        float zRotate = Input.GetAxis("Vertical") * rotationForce * Time.deltaTime;

        // 회전을 위해서는 축을 기준으로 돌아야한다.
        //즉 x입력을 받으면 z축을 중심으로 돌 것이다.
        transform.Rotate(new Vector3(zRotate, 0, -xRotate));

    }
}
