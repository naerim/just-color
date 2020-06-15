using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomoController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float walkForce = 30.0f;
    float maxWalkSpeed = 3.0f;
    Animator animator;
    public float power = 1000f;

    public GameObject FlowerPrefab; // 던질 꽃을 저장
    public Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);

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
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 플레이어 속도에 맞춰 애니메이션 속도를 바꾼다.
        this.animator.speed = speedx / 2.0f;

        // 스페이스바 누르면 꽃을 던짐
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // 꽃 던지는 것을 관리하는 함수
    void Shoot()
    {
        GameObject newBullet = Instantiate(FlowerPrefab, SpawnPoint.position, Quaternion.identity) as GameObject;
        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.up * power);
    }
  
}
