using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerController : MonoBehaviour
{

    private bool hasAttacked = false; // 공격한 상태인지 여부를 나타내는 변수
    private float lastAttackTime = -1f; // 마지막 공격 시간을 저장하는 변수
    private float doubleAttackTimeWindow = 0.4f; // 더블 공격을 인식하기 위한 시간 간격


    public Vector2 boxSize; // OverlapBox의 크기를 지정하는 변수
    public Transform pos; // OverlapBox의 위치를 지정하는 변수
    bool isPunched = false; // 플레이어가 튕겨내기중인가 여부를 나타내는 변수
                            // bool isDouble = false;  // 플레이거가 더블어택중인가 여부를 나타내는 변수
    public bool isDelay = false; //attack delay
    Animator playerAnimator; // 플레이어의 애니메이터 컴포넌트를 참조하는 변수
    AudioDirector audioDirector; // 플레이어의 오디오디렉터 컴포넌트를 참조하는 변수

    [SerializeField] GameObject LButton, RButton;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>(); // 애니메이터 컴포넌트를 가져옴
        audioDirector = GetComponent<AudioDirector>(); // 오디오디렉터 컴포넌트를 가져옴
    }

    private void Update()
    {
        if (GameDirector.hp > 0) // 캐릭터가 살아있는 상황이면
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isPunched)
            // 스페이스바를 누르고 튕겨내기 중이 아닐 때
            {
                Attack(); // Attack 메서드(공격) 호출
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl) && !hasAttacked)
            // 왼쪽 컨트롤 키를 누르고 공격 중이 아닐 때
            {
                PunchBack(); // PunchBack 메서드(튕겨내기) 호출
            }
        }

        if (GameDirector.hp <= 0) // 캐릭터의 체력이 0 이하일 때
        {

            playerAnimator.SetTrigger("game_over"); // 게임오버 애니메이션 재생
        }

    }

    public void PunchBack() //effect of punching back ingredients
    {

        if (isDelay == false)
        {
            isPunched = true; // 플레이어가 튕겨내기 중인 상태로 설정
            playerAnimator.SetTrigger("punch"); // 튕겨내기 애니메이션 재생


            var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
            // OverlapBox 안에 있는 모든 충돌체들을 가져옴
            // OverlapBoxAll 메서드는 주어진 위치(pos.position)와 크기(boxSize)로 지정된 충돌 박스 내에 있는 모든 충돌체 반환
            // 세 번째 매개변수인 0은 충돌 마스크를 나타내며, 기본값으로 설정되어 모든 충돌체를 검출
            // .ToList()는 OverlapBoxAll 메서드가 반환하는 배열을 List형태로 변환

            if (colliders.Count == 0)
            {
                LButton.GetComponent<Button>().interactable = false;
                RButton.GetComponent<Button>().interactable = false;
                Invoke("NewButtonDelay", 0.18f);
            }

                foreach (Collider2D collider in colliders)
                // colliders List에 있는 각 요소를 반복적으로 처리하기 위해 루프 시작
                // colliders 리스트에 있는 각 요소를 collider 변수에 할당하여 루프 내에서 사용
                {

                    if (collider.tag == "Target")
                    // collider 변수가 참조하는 충돌체의 태그가 Target이라면
                    {
                        audioDirector.SoundPlay("Sound/effect_sound/snare"); // 튕겨내기 사운드 재생
                        KatanaEffect.Punch(); // 튕겨내기 이펙트 발동(후라이펜 튕기는 효과)
                        Effect.Apply(collider.gameObject); // 튕겨내기 이펙트 적용(재료에 적용되는 효과)
                        break;
                    }
                    else
                    {
                        audioDirector.SoundPlay("Sound/effect_sound/swing1"); // 헛스윙 소리 재생
                    }
                }
            isDelay = true; // 딜레이를 주기 위해 isDelay라는 bool변수에 true 할당
            StartCoroutine(CountAttackDelay(0.1f)); // 딜레이 적용을 주기위해 코루틴 실행
        }

    }

    // 공격 함수
    public void Attack()
    {
        hasAttacked = true; // 플레이어가 공격중인 상태로 변경
        float currentTime = Time.time; // 현재 시간 저장

        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();

        if (!isDelay && (currentTime - lastAttackTime) >= doubleAttackTimeWindow) //if attack delay is false, attack. attack delay is true when player attacks
                                                                                  // 공격 딜레이가 OFF라면
        {

            playerAnimator.SetTrigger("attack"); // 공격 애니메이션 재생

            if (colliders.Count == 0)
            {
                LButton.GetComponent<Button>().interactable = false;
                RButton.GetComponent<Button>().interactable = false;
                Invoke("NewButtonDelay", 0.18f);
            }
            else
                foreach (Collider2D collider in colliders)
                {
                    if (collider.tag == "Target") //if there is collider in the box, play the sound of slicing ingredient
                    {
                        KatanaEffect.Attack(); // 공격 이펙트 발동(카타나에 적용되는 효과)
                        collider.gameObject.GetComponent<ItemController>().itemHp--; // 감지된 충돌체의 아이템 체력 감소 
                        audioDirector.SoundPlay("Sound/effect_sound/HiHat"); // 자르는 효과음 재생
                        if (collider.name == "chicken") //if the ingredient is chicken, play the sound of slicing chicken
                        {
                            audioDirector.SoundPlay("Sound/effect_sound/chicken"); // 치킨 자르는 소리
                        }
                        break;
                    }
                    else
                    {
                        audioDirector.SoundPlay("Sound/effect_sound/swing1"); // 헛스윙 소리 재생
                    }
                }

            isDelay = true; // 딜레이 ON
            lastAttackTime = Time.time; //reset the last attack time
            // 마지막 공격 시간을 현재 시간으로 업데이트
            StartCoroutine(CountAttackDelay(0.1f)); // 0.4초 뒤 공격 딜레이, 공격중인 상태 OFF
        }
        else if ((currentTime - lastAttackTime) <= doubleAttackTimeWindow) //if player attacks again within 0.2 seconds
        {
            // isDouble = true; // 플레이어가 더블어택 중인 상태로 변경
            playerAnimator.SetTrigger("double_attack"); // 더블 어택 애니메이션 재생

            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target") //if there is collider in the box, play the sound of slicing ingredient
                {
                    audioDirector.SoundPlay("Sound/effect_sound/HiHat2"); // 더블 어택 소리 재생
                    if (collider.name == "chicken") //if the ingredient is chicken, play the sound of slicing chicken
                    {
                        audioDirector.SoundPlay("Sound/effect_sound/chicken"); // 치킨 자르는 소리
                    }
                    KatanaEffect.DoubleAttack(); // 공격 이펙트 발동(카타나에 적용되는 효과)
                    collider.gameObject.GetComponent<ItemController>().itemHp--; // 감지된 충돌체의 아이템 체력 감소 
                }
                else
                {
                    audioDirector.SoundPlay("Sound/effect_sound/swing2"); // 헛스윙 소리 재생
                }
            }
            isDelay = true; // 딜레이 ON
            StartCoroutine(CountAttackDelay(0.1f)); // 0.4초 뒤 공격 딜레이, 공격중인 상태 OFF
            lastAttackTime = 0; //reset the last attack time
        }
    }

    void ResetDelay() // 딜레이, 공격, 튕겨내기 상태를 전부 초기화 시켜주는 함수
    {
        isDelay = false;
        isPunched = false;
        hasAttacked = false;
    }

    IEnumerator CountAttackDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);


        ResetDelay(); // delayTime초 만큼 후 초기화


    }

    // 플레이어와 오브젝트(재료)가 충돌할 경우 체력감소
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Target") //아이템과 충돌시 
        {
            Destroy(collider.gameObject);
            GameDirector.hp--; //hp감소
            audioDirector.SoundPlay("Sound/effect_sound/hit");
            playerAnimator.SetTrigger("damaged");
        }
    }

    public void NewButtonDelay()
    {
        LButton.GetComponent<Button>().interactable = true;
        RButton.GetComponent<Button>().interactable = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

}