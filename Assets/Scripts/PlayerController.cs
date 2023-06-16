using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    private bool hasAttacked = false; // 공격한 상태인지 여부를 나타내는 변수
    private float lastAttackTime = -1f; // 마지막 공격 시간을 저장하는 변수
    private float doubleAttackTimeWindow = 0.2f; // 더블 공격을 인식하기 위한 시간 간격

    public Vector2 boxSize; // OverlapBox의 크기를 지정하는 변수
    public Transform pos; // OverlapBox의 위치를 지정하는 변수
    bool isPunched = false; // 플레이어가 펀치를 당했는지 여부를 나타내는 변수
    public bool isDelay = false; // 공격 딜레이 여부를 나타내는 변수
    Animator playerAnimator; // 플레이어의 애니메이터 컴포넌트를 참조하는 변수

    private void Start()
    {
        playerAnimator = GetComponent<Animator>(); // 애니메이터 컴포넌트를 가져옴
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPunched) // 스페이스바를 누르고 튕겨내기 중이 아닐 때
        {
            Attack(); // Attack 메서드 호출
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && !hasAttacked) // 왼쪽 컨트롤 키를 누르고 공격 중이 아닐 때
        {
            PunchBack(); // PunchBack 메서드 호출
        }

        if (GameDirector.hp <= 0) // 게임의 체력이 0 이하일 때
        {
            playerAnimator.SetTrigger("game_over");
            // 게임 오버 트리거를 설정하여 애니메이션 재생
            // 게임 오버 씬으로 전환
        }
    }

    // PunchBack 함수는 튕겨내기 함수
    public void PunchBack()
    {
        isPunched = true; // 플레이어가 펀치를 당한 상태로 설정
        playerAnimator.SetTrigger("punch"); // 펀치 애니메이션 재생

        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList(); // OverlapBox 안에 있는 모든 충돌체들을 가져옴
        // OverlapBoxAll 메서드는 주어진 위치(pos.position)와 크기(boxSize)로 지정된 충돌 박스 내에 있는 모든 충돌체 반환
        // 세 번째 매개변수인 0은 충돌 마스크를 나타내며, 기본값으로 설정되어 모든 충돌체를 검출
        // .ToList()는 OverlapBoxAll 메서드가 반환하는 배열을 List형태로 변환

        foreach (Collider2D collider in colliders)
        {
           // colliders List에 있는 각 요소를 반복적으로 처리하기 위해 루프 시작
           // colliders 리스트에 있는 각 요소를 collider 변수에 할당하여 루프 내에서 사용

            if (collider.tag == "Target") // collider 변수가 참조하는 충돌체의 태그가 Target이라면
            {
                KatanaEffect.Punch(); // 튕겨내기 이펙트 발동
                Effect.Apply(collider.gameObject); // 튕겨내기 효과 적용
            }
        }
        StartCoroutine(CountAttackDelay(0.4f)); // 공격과 튕겨내기 사이에 딜레이를 적용하기 위해 CountAttackDelay 코루틴 실행
    }

    public void Attack()
    {
        hasAttacked = true; // 공격한 상태로 설정
        float currentTime = Time.time; // 현재 시간 저장
        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList(); // OverlapBox 안에 있는 모든 충돌체들을 가져옴
        if (!isDelay) // 공격 딜레이 상태가 아닌 경우
        {
            playerAnimator.SetTrigger("attack"); // 공격 애니메이션 재생
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target") // 충돌체의 태그가 "Target"인 경우
                {
                    KatanaEffect.Attack(); // 공격 이펙트 발동
                    collider.gameObject.GetComponent<ItemController>().itemHp--; // 충돌체의 아이템 체력 감소
                    Recipe.DecreaseIngredient(collider.name); // Recipe.decreaseIngredient 함수를 사용하여 재료 감소
                }
            }
            isDelay = true; // 공격 딜레이 상태로 설정
            lastAttackTime = currentTime; // 마지막 공격 시간을 현재 시간으로 업데이트
            
        }
        else if ((currentTime - lastAttackTime) <= doubleAttackTimeWindow) // 현재 시간과 마지막 공격 시간의 차이가 더블 공격 시간 간격보다 작거나 같은 경우
                                                                           // (0.2초 안에 공격을 두번 따닥 누른 경우)
        {
            playerAnimator.SetTrigger("double_attack"); // 더블 공격 애니메이션 재생
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target") // 충돌체의 태그가 "Target"인 경우
                {
                    KatanaEffect.DoubleAttack(); // 더블 공격 이펙트 발동
                    collider.gameObject.GetComponent<ItemController>().itemHp--; // 충돌체의 아이템 체력 감소
                    Recipe.DecreaseIngredient(collider.name); // Recipe.decreaseIngredient 함수를 사용하여 재료 감소
                }
            }
            isDelay = true; // 공격 딜레이 상태로 설정
            
        }
        StartCoroutine(CountAttackDelay(0.4f)); // 공격과 튕겨내기 사이에 딜레이를 적용하기 위해 CountAttackDelay 코루틴 실행
    }

    // 딜레이 관련 코루틴
    IEnumerator CountAttackDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // 주어진 시간만큼 대기
        isDelay = false; // 공격 딜레이 상태 해제
        isPunched = false; // 플레이어가 펀치를 당한 상태 해제
        hasAttacked = false; // 공격한 상태 해제
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Target") // 충돌체의 태그가 "Target"인 경우
        {
            Destroy(collider.gameObject); // 충돌체를 제거
            GameDirector.hp--; // 게임 체력 감소
            playerAnimator.SetTrigger("damaged"); // 피격 애니메이션 재생
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize); // OverlapBox를 그리는 Gizmos
    }
}
