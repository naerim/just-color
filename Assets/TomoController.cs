using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomoController : MonoBehaviour
{
    Animator animator;
    public float power = 1000f;

    public float speed = 8f;

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        // 좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // 움직이는 방향에 따라 반전
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y);


        // 플레이어 속도에 맞춰 애니메이션 속도를 바꾼다.
        this.animator.speed = 2.0f;
        
    }
}
