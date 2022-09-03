using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningAction : MonoBehaviour
{
    [SerializeField] float x, y, z;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
    }
}
