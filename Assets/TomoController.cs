using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomoController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float walkForce = 10.0f;
    float maxWalkSpeed = 5.0f;
    Animator animator;
 //   public float power = 1000f;

 //   public float speed = 8f;
 //   public float moveableRange = 7.5f;


    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
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

        // 플레이어 속도 
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 스피드 제한
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }



        // 플레이어 속도에 맞춰 애니메이션 속도를 바꾼다.
        this.animator.speed = speedx / 2.0f;
        /*
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -8, 8), transform.position.y);


        // 플레이어 속도에 맞춰 애니메이션 속도를 바꾼다.
        this.animator.speed = 2.0f;
        */
    }
}
