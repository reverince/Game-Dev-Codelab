using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float velocity = 20.0f;

    [SerializeField]
    private int hitpoint = 20;

    [SerializeField]
    private GameObject explosionGO;

    private Rigidbody2D rigidbody;

    private Transform target;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // 플레이어를 바라봅니다.
        Vector2 direction = rigidbody.velocity.normalized;
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void FixedUpdate()
    {
        // 플레이어를 향해 이동합니다.
        if (target != null)
        {
            Vector2 direction = ((Vector2)(target.position - transform.position)).normalized;
            rigidbody.AddForce(direction * velocity);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어 총알과 부딪힌 경우
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            // 총알 파괴
            Destroy(collision.gameObject);
            // 체력을 1 줄입니다.
            hitpoint -= 1;
            // 체력이 0 이하가 된 경우
            if (hitpoint <= 0)
            {
                // 폭발 이펙트 인스턴스화
                GameObject explosionInstance = Instantiate(explosionGO, transform.position, Quaternion.identity, null);
                Animator explosionAnimator = explosionInstance.GetComponent<Animator>();
                // 폭발 이펙트 애니메이션만큼의 시간이 지나면 폭발 이펙트를 파괴합니다.
                float explosionLength = explosionAnimator.runtimeAnimatorController.animationClips[0].length;
                Destroy(explosionInstance, explosionLength);

                // 적 스스로를 파괴합니다.
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어와 부딪힌 경우
        if (collision.gameObject.CompareTag("Player"))
        {
            // 플레이어 파괴
            Destroy(collision.gameObject);
        }
    }
}
