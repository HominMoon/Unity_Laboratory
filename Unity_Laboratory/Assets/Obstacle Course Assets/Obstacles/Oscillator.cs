using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//두 지점 사이를 움직이는 물제 만들기
//사인파 이용

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;

    Vector3 startingPosition;
    float movementFactor;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float cycles;

        cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float sinWave = Mathf.Sin(tau * cycles);
        movementFactor = (sinWave + 1f) / 2f; 
        // 왜 offset을 만들때 sinwave를 사용하지 않았는가?
        // sinWave는 -1 ~ 1의 값을 가지기 때문에 시작지점이 중간값이 된다.
        // 사실 큰 상관은 없다 이러면 시작지점을 명확히 할 수 있다.

        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPosition + offset;
    }
}


        //사인파를 어떻게 만들 것인가?
        //1. 시간에 따른 주기 -> 사이클
        //2. tau : 파이가 지름에 대한 원주의 비라면 tau는 반지름에 대한 원주의 비
        //3. 사인파의 값이 -1 ~ 1사이에 정의된다. 이것은 0~1로 변환
        // 시간에 따른 오브젝트의 왕복이동을 위해
        // 시작 위치에서 사인파에 따른 offset을 더해줌.