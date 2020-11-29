using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 에디터 Inspector 창에서 지정할 수 있는 속력
    [SerializeField]
    private float velocity;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletVelocity;

    // 다음 탄을 쏘기까지의 지연 시간
    [SerializeField]
    private float fireDelay;

    private Rigidbody2D rigidbody;

    private float lastFiredTime;

    // Start()는 첫 Update()가 호출되기 전 딱 한 번만 호출됩니다.
    void Start()
    {
        // 이 스크립트가 부착된 게임오브젝트에서 RigidBody2D 컴포넌트를 찾아 변수에 대입합니다.
        rigidbody = GetComponent<Rigidbody2D>();
        lastFiredTime = 0.0f;
    }

    // Update()는 매 프레임 호출됩니다.
    // 즉, 성능이 좋아서 프레임이 높게 나오는 PC에서는 같은 시간동안 더 많이 호출됩니다.
    // 그러므로 게임 밸런스에 영향이 없는, 비주얼과 관련된 코드를 주로 이곳에 배치합니다.
    void Update()
    {
        FaceMouse();
        Fire();
    }

    // FixedUpdate는 컴퓨터 성능에 따라 호출 주기를 변경해 거의 일정한 주기로 호출됩니다.
    // Rigidbody 같은 물리를 다루는 코드는 이곳에 배치해야 합니다.
    void FixedUpdate()
    {
        Move();
    }

    // 게임오브젝트가 마우스 위치를 바라보도록 하는 함수
    void FaceMouse()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 마우스 위치를 향하는 방향 벡터
        Vector2 direction = (mouseWorldPoint - transform.position).normalized;
        if (direction != Vector2.zero)
        {
            // direction 벡터가 향하는 방향으로 게임오브젝트 Transform의 Z축을 회전시킵니다.
            // 자세한 내용은 삼각함수를 공부하세요!
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void Fire()
    {
        // 발사 준비가 되지 않았으면 return
        if (lastFiredTime + fireDelay > Time.time)
        {
            return;
        }

        // 발사(Fire1) 키는 마우스 왼쪽 클릭 또는 Ctrl입니다.
        float fire = Input.GetAxis("Fire1");
        if (fire > 0.0f)
        {
            Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 마우스 위치를 향하는 방향 벡터
            Vector2 direction = ((Vector2)(mouseWorldPoint - transform.position)).normalized;
            // 총알을 인스턴스화(씬에 생성)합니다.
            GameObject bulletInstance = Instantiate(bullet, transform.position, transform.rotation, null);
            // 정한 속력에 따라 총알 속도를 결정합니다.
            Rigidbody2D bulletRB = bulletInstance.GetComponent<Rigidbody2D>();
            bulletRB.velocity = rigidbody.velocity + direction * bulletVelocity;
            // 방향에 따라 총알을 회전시킵니다.
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
            bulletInstance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            // 총알이 무한히 쌓이는 것을 방지하기 위해, 생성한 총알을 10초 후 파괴합니다.
            Destroy(bulletInstance, 10.0f);

            // 마지막 발사 시간을 갱신합니다.
            lastFiredTime = Time.time;
        }
    }

    // 입력에 따라 게임오브젝트에게 움직일 힘을 가하는 함수
    void Move()
    {
        // 가로, 세로 입력으로 들어온 값입니다. (-1.0f ~ 1.0f)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // 입력 값을 벡터에 곱해 방향을 맞춥니다.
        Vector2 speed = Vector2.right * horizontal + Vector2.up * vertical;
        // 방향에 속력을 곱합니다.
        speed *= velocity;
        // Rigidbody에 speed만큼의 힘을 가합니다.
        rigidbody.AddForce(speed);
    }
}
