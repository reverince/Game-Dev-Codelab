# Game Dev Codelab

안녕하세요? 게임 개발 코드랩에 오신 것을 환영합니다.

이 코드랩은 게임 개발에 관심은 있었지만 해본 적 없는 사람을 대상으로 만들어졌습니다. 프로그래밍에 대해서는 몰라도 따라할 수 있지만 알고 있으면 더 좋습니다.

![이미지 27](Captures\GDC-27.png)

유니티 엔진을 활용해 몇 시간 안에 간단한 2D 게임을 만들어 봅시다. 진행하면서 궁금한 점이나 잘못된 내용이 있으면, 이 페이지의 ❕ Issues 탭에서 새 이슈를 작성해 알려주세요.


## 준비물

1. Unity Hub
    * [유니티 스토어](https://store.unity.com/download?ref=personal)에서 약관 동의 체크하고 다운로드합시다.
1. Visual Studio 2017
    * Visual Studio Code도 설정을 바꾸면 사용할 수 있으나 본 코드랩은 Visual Studio 2017을 기준으로 합니다.


## 세팅

![이미지 1](Captures\GDC-01.png)

Unity Hub의 좌측 설치 탭에서 파란색 **추가** 버튼을 누른 뒤 **Unity 2020 정식 릴리스**를 선택하세요. 아래 1.15f1로 적힌 버전은 무엇이든 상관 없습니다.

**다음** 버튼을 눌러 나오는 모듈 목록은 기본 상태로 두고 **완료** 버튼을 누르면 됩니다.

![이미지 2](Captures\GDC-02.png)

설치가 완료되면 프로젝트 탭에서 **새로 생성**을 누르세요. 템플릿은 **2D**, 프로젝트 이름과 저장 위치는 편한 대로 설정하고 프로젝트를 생성합시다.

다음에 프로젝트를 열려면 이 Unity Hub에서 해당 프로젝트를 클릭하면 됩니다.

![이미지 3](Captures\GDC-03.png)

유니티 에디터가 켜졌다면 위의 **Window - Layouts - 2 by 3**을 선택해 레이아웃을 바꿉시다. 다크 모드는 **Edit - Preferences - General - Editor Theme**에서 설정할 수 있습니다.

아래는 레이아웃 각 요소에 대한 간단한 설명입니다.

* 왼쪽 위 Scene 창은 우리가 직접 편집할 수 있는 게임 장면이고 그 아래 Game 창이 실제로 보이는 모습입니다.
    * 하나의 스테이지를 하나의 Scene(씬)이라고 생각하면 편합니다.
* 가운데 Hierarchy 창에서는 이 씬에 배치한 *게임오브젝트*(GameObject)들을 관리할 수 있습니다.
    * 씬에 배치할 수 있는 모든 것을 *게임오브젝트*라고 부릅니다. 캐릭터, 몬스터, 카메라, 조명은 물론 C# 스크립트 하나만 들어 있는 게임오브젝트도 있습니다.
* 그 옆 Project 창은 파일 탐색기 같은 역할을 합니다. 우리 프로젝트의 이미지, 사운드 같은 리소스(재료)나 스크립트를 정리하고 찾는 데 씁니다.
* 오른쪽 Inspector 창은 지금 선택한 게임오브젝트 또는 리소스에 대한 설정을 보거나 수정할 수 있습니다.


## 첫 게임오브젝트 만들기

![이미지 4](Captures\GDC-04.png)

Hierarchy 창의 빈 공간에 우클릭해서 **Create Empty**로 빈 게임오브젝트를 생성합시다. 만들어진 **GameObject**를 클릭하면 Inspector 창에 정보가 나타납니다.

![이미지 5](Captures\GDC-05.png)

게임오브젝트는 여러 *컴포넌트*의 조합으로 만들어지는데요. 모든 게임오브젝트는 기본적으로 Transform 컴포넌트를 가지고 있습니다. 이 Transform 컴포넌트는 해당 게임오브젝트의 위치(Position), 회전(Rotation), 크기(Scale)을 지정합니다. 직접 입력할 수도 있지만 스크립트로 바꿀 수도 있습니다.

우선 이름을 GameObject에서 **Character**로 바꾸고, Transform의 제목 부분에 우클릭해서 **Reset**으로 위치를 초기화합시다.

이 게임오브젝트는 오직 위치 정보인 Transform만 가지고 있기 때문에, 씬에는 존재하지만 왼쪽 아래 Game 창에서는 볼 수 없습니다. 이제 이미지를 추가해 봅시다.


### 스프라이트 추가하기

[Spaceship Shooter Environment by ansimuz](https://ansimuz.itch.io/spaceship-shooter-environment)

위 링크로 들어가 **Download Now** 버튼을 누르세요.

![이미지 6](Captures\GDC-06.png)

리소스 제작자에게 기부할지 묻는 창이 나타납니다. 내킨다면 기부해도 좋지만 아니면 **No thanks,**라고 써 있는 부분을 클릭하세요. 이동한 페이지에서 다시 빨간 **Download** 버튼을 누르면 리소스를 받을 수 있습니다.

![이미지 7](Captures\GDC-07.png)

다시 유니티 에디터로 돌아와서 Project 창에서 새 폴더 **Sprites**를 만든 다음, 압축을 푼 리소스 폴더를 파일 탐색기에서 그대로 드래그 앤 드롭하면 자동으로 폴더가 만들어집니다.

![이미지 8](Captures\GDC-08.png)

sprites 폴더 안에서 **enemy-medium**을 찾았나요? 우주선이 두 개 붙어 있는데 애니메이션을 표현하기 위해서입니다. 하나의 이미지 파일이기 때문에 둘로 쪼개 주는 작업이 필요합니다. **enemy-medium**을 클릭하고 Inspector 창에서 **Sprite Mode**를 **Multiple**로 설정하고 오른쪽 아래 구석의 **Apply**를 누르세요. 그리고 중간에 있는 **Sprite Editor**를 누르면 아래와 같은 창이 열립니다.

![이미지 9](Captures\GDC-09.png)

왼쪽 위 **Slice**를 눌러 나오는 창에서 **Type**은 **Grid by Cell Count**를 선택하세요. 바로 밑에 **Column & Row**가 이 그림을 몇 열 몇 행으로 자를지를 의미합니다. 한 줄에 가로로 두 개의 우주선이 있으니 2열 1행으로 자르면 됩니다. **C**에는 **2**, **R**에는 **1**을 입력하고 **Slice**를 누르세요. 두 우주선 테두리에 흰 선이 생기면 성공입니다.

오른쪽 위 **Apply**를 누르고 Sprite Editor 창을 닫아주세요.

![이미지 10](Captures\GDC-10.png)

**enemy-medium** 이미지 오른쪽에 붙어 있는 확장 버튼(▶)을 누르면 방금 자른 두 우주선이 나옵니다. 왼쪽 것을 Hierarchy 창의 **Character** 게임오브젝트(방금 만든 게임오브젝트)에 드래그 앤 드롭합시다. **Character** 아래에 **enemy-medium_0**라는 새 게임오브젝트가 만들어지고, Game 창에서 그 모습을 확인할 수 있습니다. 이 게임오브젝트 이름은 **Sprite**로 바꿔줍시다.


#### 애니메이션 추가하기

지금 한 것은 하나의 이미지만 붙여 주는 작업입니다. 이번에는 애니메이션을 추가해 봅시다.

다시 Project 창에서 **enemy-medium_0**과 **enemy-medium_1**을 둘 다 선택(Shift나 Ctrl 키를 쓰세요)해서 Hierarchy 창의 방금 만든 **Sprite** 게임오브젝트에 드래그 앤 드롭하세요. 애니메이션 파일(`.anim`)을 생성할 경로와 파일 이름을 정하는 창이 나오는데, 편한 대로 지정합니다.

이제 에디터 상단의 **Play**(▶) 버튼을 누르면 우주선 엔진이 빛나는 것을 확인할 수 있습니다.


#### 배경 추가하기

우주 배경을 추가하려고 합니다. 적당히 검색해서 맘에 드는 것을 써도 좋고, 아래 링크의 리소스를 써도 좋습니다.

[Space Background by ansimuz](https://ansimuz.itch.io/space-background)

Hierarchy 창의 빈 공간에 우클릭해서 이번에는 **UI - Image**를 선택합니다. **Image** 게임오브젝트 위에 **Canvas**라는 게임오브젝트도 자동으로 만들어지는데, 우주선에 붙인 이미지(Sprite Renderer)와 달리 화면 자체에 붙인 이미지라고 생각하면 됩니다.

![이미지 11](Captures\GDC-11.png)

**Image** 게임오브젝트를 선택하고 Inspector 창의 **Source Image**에 원하는 이미지를 지정하면 Game 창에 이미지가 나타납니다. 이미지를 드래그 앤 드롭하거나 오른쪽 ⊙ 버튼을 눌러서 이미지를 정할 수 있습니다.

그런데 이미지가 화면을 채우지 않네요.

![이미지 12](Captures\GDC-12.png)

Rect Transform 컴포넌트에서 **stretch**라고 써 있는 사각형 부분을 누르면 **Anchor Presets** 창이 나타납니다. 여기서 `Alt + Shift`를 누른 채 맨 오른쪽 아래 사각형을 클릭하세요. 이미지가 화면을 가득 채우게 됩니다.

이미지가 찌그러지는 게 마음에 들지 않는다면 다시 `Alt + Shift` + 가운데 사각형을 누르고 직접 사이즈를 지정해 주어도 됩니다.

위 링크에서 받은 리소스에 행성 이미지도 있어서 함께 추가해 보겠습니다. Hierarchy 창에서 Image를 선택한 채로 `Ctrl + D` 단축키를 사용해 이미지 게임오브젝트를 복제하고 또 다른 이미지를 지정해 줍시다. 이 친구들 중 몇몇은 화면을 가득 채우길 원하지 않으니 우선 Inspector에서 **Set Native Size** 버튼을 눌러 원본 사이즈를 사용하도록 설정합니다.

![이미지 13](Captures\GDC-13.png)

Scene 창을 볼 때가 왔습니다. 단축키 `W`를 누르면 게임오브젝트를 이동할 수 있고, `E`를 누르면 회전, `R`을 누르면 크기를 조절할 수 있습니다. 리소스를 써서 맵을 적당히 꾸며봅시다.

※ Image들은 Hierarchy 창에서 위에서 아래 순으로 화면에 그려집니다. 즉, Hierarchy 창에서 아래에 있을수록 씬에서는 앞에 보입니다.

그런데 뭔가 잊은 것 없나요? (주인공 우주선이 안 보여요.)

![이미지 14](Captures\GDC-14.png)

**Canvas** 게임오브젝트를 눌러서 Inspector를 보면 **Render Mode**가 **Screen Space - Overlay**로 되어 있습니다. 이 칸을 **Screen Space - Camera**로 바꾸고 아래 **Render Camera**에 **Main Camera** 게임오브젝트를 드래그 앤 드롭해줍시다. 이제 우주선이 보이나요?

(이래도 보이지 않으면 **Canvas** 게임오브젝트에서 **Order in Layer**를 0보다 큰 값으로 설정해주세요.)

### 캐릭터 움직이기

WASD 키로 우주선을 움직여 봅시다. 우주 공간에서 무거운 물체가 움직이는만큼 관성도 작용하게 만들 것입니다.

![이미지 15](Captures\GDC-15.png)

**Character** 게임오브젝트에서 **Add Component - New Script**로 새로운 스크립트를 만듭니다. 스크립트 이름은 **PlayerController**로 합니다.

또 같은 방법으로 **Rigidbody 2D** 컴포넌트도 추가합니다. Rigidbody는 게임오브젝트가 유니티 엔진의 물리에 따라 움직여, 질량과 관성을 갖거나 다른 물체와 충돌할 수 있도록 하는 컴포넌트입니다. **Play**(▶) 버튼을 누르면 우주선이 아래로 뚝 떨어지는데, 이 세상에는 아직 중력이 있어서 그렇습니다.

![이미지 19](Captures\GDC-19.png)

**Edit - Project Settings - Physics 2D - Gravity**에서 세계의 중력을 설정할 수 있습니다. 이곳은 우주이니 **X**, **Y** 모두 **0**으로 설정합시다.

**Edit - Preferences - Exteral Tools - External Script Editor**에서 어떤 IDE(스크립트 에디터)를 사용할지 정할 수 있습니다. 저는 Visual Studio 2017을 선택하겠습니다.

![이미지 16](Captures\GDC-16.png)

**Character** 게임오브젝트의 **Script**에 새로 만든 PlayerController가 연결되어 있습니다. 더블 클릭해서 스크립트 에디터를 켭니다.

![이미지 17](Captures\GDC-17.png)

유니티 C# 스크립트의 기본 형태입니다. 주석으로 써있는 대로 Start() 함수는 첫 프레임에 Update()가 불리기 전에 호출되고, Update() 함수는 매 프레임마다 호출됩니다. 우선 아래와 같이 코드를 작성합시다.

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 에디터 Inspector 창에서 지정할 수 있는 속력
    [SerializeField]
    private float velocity;

    private Rigidbody2D rigidbody;

    // Start()는 첫 Update()가 호출되기 전 딱 한 번만 호출됩니다.
    void Start()
    {
        // 이 스크립트가 부착된 게임오브젝트에서 RigidBody2D 컴포넌트를 찾아 변수에 대입합니다.
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update()는 매 프레임 호출됩니다.
    // 즉, 성능이 좋아서 프레임이 높게 나오는 PC에서는 같은 시간동안 더 많이 호출됩니다.
    // 그러므로 게임 밸런스에 영향이 없는, 비주얼과 관련된 코드를 주로 이곳에 배치합니다.
    void Update()
    {
        FaceFront();
    }

    // FixedUpdate는 컴퓨터 성능에 따라 호출 주기를 변경해 거의 일정한 주기로 호출됩니다.
    // Rigidbody 같은 물리를 다루는 코드는 이곳에 배치해야 합니다.
    void FixedUpdate()
    {
        Move();
    }

    // 게임오브젝트가 움직이는 방향을 바라보도록 하는 함수
    void FaceFront()
    {
        // 지금 이 게임오브젝트의 속도 벡터
        Vector2 velocity = rigidbody.velocity;
        // 이 게임오브젝트가 움직이고 있다면,
        if (velocity != Vector2.zero)
        {
            // 속도 벡터가 향하는 방향으로 게임오브젝트 Transform의 Z축을 회전시킵니다.
            // 자세한 내용은 삼각함수를 공부하세요!
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
        // 속력과 deltaTime을 곱합니다.
        speed *= velocity;
        // Rigidbody에 speed만큼의 힘을 가합니다.
        rigidbody.AddForce(speed);
    }
}
```

다시 에디터로 돌아오면 **Player Controller** 컴포넌트에 **Velocity**라는 필드가 추가된 것을 확인할 수 있습니다.

값을 조절하기 전에 **Sprite** 게임오브젝트에서 **Rotation Z**를 **90**도로 설정해 주세요. 우주선 이미지가 아래를 향하고 있는데, 코드는 오른쪽을 향할 때를 기본 상태로 간주하고 있기 때문에 둘을 맞춰 주는 작업입니다.

![이미지 20](Captures\GDC-20.png)

우선 위 사진대로 값들을 설정하고, **Play**를 눌러 테스트하면서 값을 조절해 봅시다.

* Velocity: 우주선의 속력입니다. 높이면 빨라지고 낮추면 느려집니다.
* Mass: 우주선의 질량입니다. 높이면 둔해지고 낮추면 날렵해집니다.
* Linear Drag: 이동할 때의 마찰력입니다. 높일수록 앞으로 나아가는 힘이 빨리 약해집니다. 0으로 설정하면 마찰력이 없어 우주에서처럼 영원히 앞으로 나아가게 됩니다.

## 레이저 탄 만들기

우주선이 레이저 볼트를 쏠 수 있게 만들어 봅시다. 우주선 이미지가 있는 폴더에서 **laser-bolts**를 찾아 아까와 같은 방법으로 **Sprite Editor** 창까지 엽니다.

![이미지 21](Captures\GDC-21.png)

아까와는 달리, **Slice Type**을 **Automatic**으로 설정하고 자릅니다.

Projects 창에서 **laser-bolts_2**와 **laser-bolts_3**을 함께 선택해 Hierarchy 창으로 드래그 앤 드롭합니다. 역시나 애니메이션 파일 이름과 경로를 정하는 창이 나오면 적당히 정합니다. 우주선에 가려서 보이지는 않지만 **laser-bolts_2**라는 게임오브젝트가 만들어졌습니다. 이 게임오브젝트의 이름은 **Laser Bolt Blue**로 바꿉시다.

**Transform**을 우클릭해서 **Reset**으로 위치를 초기화합니다. 그리고 **Add Component**로 **Rigidbody 2D**와 **Capsule Collider 2D**를 추가합니다. Rigidbody의 **Body Type**은 **Kinematic**으로 설정합니다.

*Capsule Collider*는 이름대로 캡슐 모양으로 생긴 콜라이더(충돌체)입니다. Collider는 이 게임오브젝트가 세상에서 차지하는 크기를 정합니다. 일단 처음 만들어진 크기 그대로 사용하겠습니다.

Inspector 창 위에 Tag를 정하는 칸이 있습니다. **Untagged**를 클릭하고 목록에서 **Add Tag**를 선택하면 새로운 태그를 만드는 창이 열립니다.

![이미지 23](Captures\GDC-23.png)

\+ 버튼을 눌러 **PlayerBullet**, **Enemy** 두 태그를 추가하고 다시 **Laser Bolt Blue** 게임오브젝트의 Inspector로 돌아가서, **Tag**로 **PlayerBullet**을 지정합니다.

![이미지 22](Captures\GDC-22.png)

Project 창에서 **Assets** 폴더로 이동한 다음, 빈 공간에 (Hierarchy로부터) **Laser Bolt Blue** 게임오브젝트를 드래그 앤 드롭합니다. 그러면 게임오브젝트 이름이 파랗게 변하면서 **Assets** 폴더 안에 같은 이름의 파일이 생성됩니다. 이를 *Prefab*(프리팹)이라고 합니다. 프리팹을 만드는 것은 공장에서 만들 부품을 정하는 것과 같습니다. 총알은 공장에서 잔뜩 찍어내야 하니까요.

이제 Hierarchy에서 **Laser Bolt Blue** 게임오브젝트는 삭제하면 됩니다.

### 탄 발사

레이저 볼트는 마우스가 있는 방향으로 발사하도록 만드려고 합니다. 그러므로 우주선도 이제 이동 방향이 아니라 마우스가 있는 방향을 바라보도록 스크립트를 수정합시다.

```csharp
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
```

![이미지 24](Captures\GDC-24.png)

스크립트를 저장하고 다시 에디터로 돌아가 자동 컴파일을 마치면 **Character** 게임오브젝트의 **Player Controller** 컴포넌트에 새 필드가 추가됩니다. **Bullet**에는 게임오브젝트가 들어가는데, 왼쪽 Project 창에서 만들어 둔 **Laser Bolt Blue** 프리팹을 드래그 앤 드롭하면 됩니다. **Bullet Velocity**(속도)와 **Fire Delay**(발사 간격)은 직접 테스트해 보면서 적당한 값을 찾읍시다.

## 적 만들기

**Character**를 향해 날아오는 적 프리팹도 지금까지 써 온 방법으로 만들 수 있습니다.

![이미지 25](Captures\GDC-25.png)

그 전에 **Character**의 **Tag**는 **Player**로 설정하고, **Capsule Collider 2D** 컴포넌트를 추가합니다. 콜라이더 크기는 **Edit Collider** 버튼을 누른 다음 Scene 창에서 수정할 수도 있고, **Offset**과 **Size** 칸에 직접 입력할 수도 있습니다. 넘어가기 전에 **Is Trigger**를 체크해 주세요. 안 그러면 본인이 방금 막 쏜 총알과 부딪히게 됩니다.

Character를 만들 때 했던 것처럼 리소스에서 **enemy-small** 이미지를 둘로 쪼개고 Hierarchy로 드래그해 애니메이션과 게임오브젝트, 프리팹을 만듭니다. **explosion**도 프리팹으로 만들어 주세요. 기억나지 않으면 다시 위쪽 내용을 참고하세요.

적 우주선의 게임오브젝트 설정과 스크립트는 아래와 같습니다.

![이미지 26](Captures\GDC-26.png)

```csharp
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
```

Project 창에서 적 우주선 프리팹을 끌어다 Scene 창에 배치하고 테스트해볼 수 있습니다. Hit Point로 지정한 만큼 공격을 맞추면 적이 폭발하는지 확인해 보세요. Character도 적 우주선에 부딪히면 사라집니다.

![이미지 27](Captures\GDC-27.png)

잘 안 되는 부분이 있으면 **Tag** 등을 한 번 더 확인해 보세요. 그래도 모르겠다면 이 페이지 맨 위의 ❕ **Issues** 탭에서 새 이슈를 작성해 알려주세요.

![이미지 28](Captures\GDC-28.png)

이 페이지 위로 가서 초록색 ↓ **Code** 버튼을 누르고 **Download ZIP**으로 제가 코드랩을 작성하면서 만든 프로젝트 자체를 다운로드하실 수 있습니다. 압축을 풀고 Unity Hub에서 프로젝트 탭의 **추가** 버튼으로 폴더를 열면 됩니다. 편하게 뜯어보세요.

수고하셨습니다!
