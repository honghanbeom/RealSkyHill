using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FightCoroutine : MonoBehaviour
{
    private bool isPlayerTurn = true;
    private bool playerClicked = false; // 플레이어가 공격 영역을 클릭했는지 여부
    private bool animaitionAction = false;


    public MonsterData monsterData;

    public Animator animator; // Animator


    //public GameObject leftHandImg;
    //public GameObject rightHandImg;
    //public GameObject attackTypeImg;
    public GameObject weaponUI;

    public GameObject AttackArea_R;
    public GameObject AttackArea_N;

    public bool attackButton_L = false;
    public bool attackButton_M = false;
    public bool attackButton_R = false;


    public bool attackButton_L2 = false;
    public bool attackButton_M2 = false;
    public bool attackButton_R2 = false;

    bool buttonClicked = false;



    public static FightCoroutine fight;

    private void Awake()
    {
        fight = this;
    }

    public IEnumerator MonsterFight(string name, float hP, float maxDmg,
        float minDmg, float midDmg, float EXP , Animator monsterAnimation)
    {
        Debug.LogFormat("{0}와 전투시작", name);

        float userHP = UserInformation.player.hp;
        float userEXP = UserInformation.player.exp;
        float userMaxDmg = UserInformation.player.maxAttackDamage;
        float userMinDmg = UserInformation.player.minAttackDamage;
        int userHit = UserInformation.player.hit;

        float randomDmg = default;
        float monsterRandomDmg = Random.Range(maxDmg, minDmg);

        // 필요시 다른 인수사용
        // 최소값, 중간값, 최대값 넣었으니 필요에 따라 사용

        while (userHP > 0 && hP > 0)
        {

            while (!buttonClicked)
            {
                Debug.Log(fight.attackButton_L);
                if (attackButton_L == true || attackButton_M == true|| attackButton_R == true )
                {

                    buttonClicked = true;
                }
                if (attackButton_L2 == true || attackButton_M2 == true || attackButton_R2 == true)
                {
                    buttonClicked = true;
                }
                yield return null;

            }

            Debug.Log("버튼이 눌렸습니다.");

            Debug.Log("-------------------------------------------------");

            Debug.Log("플레이어턴");
            // 이미지 띄우기
            // 이미지 클릭하면 그에 맞는 데미지 연산

            if (attackButton_L == true)
            {

                Debug.Log("버튼 잘 눌린다.");
                Rookie_ButtonLeft(out randomDmg, userMinDmg, userMaxDmg, userHit);
                ImageSc6();
                ImageSc8();
                animator.SetBool("SpearAttack" , true);
                yield return new WaitForSeconds(0.7f);
                animator.SetBool("SpearAttack", false);

            }

            else if (attackButton_M == true)
            {

                Debug.Log("버튼 잘 눌린다.");
                Rookie_ButtonMid(out randomDmg, userMinDmg, userMaxDmg, userHit);
                ImageSc6();
                ImageSc8();
                animator.SetBool("SpearAttack", true);
                yield return new WaitForSeconds(0.7f);
                animator.SetBool("SpearAttack", false);
            }

            else if (attackButton_R == true)
            {

                Debug.Log("버튼 잘 눌린다.");
                Rookie_ButtonRight(out randomDmg, userMinDmg, userMaxDmg, userHit);

                ImageSc6();
                ImageSc8();
                animator.SetBool("SpearAttack", true);
                yield return new WaitForSeconds(0.7f);
                animator.SetBool("SpearAttack", false);
            }

            //-------------------------------------------------------------------------------------------//
            //이웃 

            if (attackButton_L2 == true)
            {

                Debug.Log("버튼 잘 눌린다.");
                Neighbour_ButtonLeft(out randomDmg, userMinDmg, userMaxDmg, userHit);
                ImageSc6();
                ImageSc8();
                animator.SetBool("SpearAttack", true);
                yield return new WaitForSeconds(0.7f);
                animator.SetBool("SpearAttack", false);

            }

            else if (attackButton_M2 == true)
            {

                Debug.Log("버튼 잘 눌린다.");
                Neighbour_ButtonMid(out randomDmg, userMinDmg, userMaxDmg, userHit);
                ImageSc6();
                ImageSc8();
                animator.SetBool("SpearAttack", true);
                yield return new WaitForSeconds(0.7f);
                animator.SetBool("SpearAttack", false);
            }

            else if (attackButton_R2 == true)
            {

                Debug.Log("버튼 잘 눌린다.");
                Neighbour_ButtonRight(out randomDmg, userMinDmg, userMaxDmg, userHit);

                ImageSc6();
                ImageSc8();
                animator.SetBool("SpearAttack", true);
                yield return new WaitForSeconds(0.7f);
                animator.SetBool("SpearAttack", false);
            }




            if (attackButton_L == true || attackButton_M == true || attackButton_M == true)
            {


                // 클릭할 때 까지 wait 
                // 플레이어 애니메이션 실행 -> 애니메이션에 이벤트 넣는 방법으로 가능할듯

                hP -= randomDmg;

                Debug.LogFormat("유저가 준 데미지 : {0}", randomDmg);
                Debug.LogFormat("몬스터 체력 : {0}/{1}", hP, 20);

                Debug.Log("-------------------------------------------------");
                Debug.Log("몬스터 턴");
                // 몬스터 애니메이션 실행
                monsterAnimation.SetBool("Attack", true);
                userHP -= monsterRandomDmg;
                yield return new WaitForSeconds(0.35f);
                monsterAnimation.SetBool("Attack", false);

                Debug.LogFormat("몬스터가 준 데미지 : {0}", monsterRandomDmg);
                Debug.LogFormat("플레이어 체력 : {0}/{1}", userHP, 100);
                Debug.Log("-------------------------------------------------");
                attackButton_L = false;
                attackButton_M = false;
                attackButton_R = false;
                buttonClicked = false;

                if (userHP >= 0 && hP <= 0)
                {
                    Debug.Log("-------------------------------------------------");
                    Debug.LogFormat("플레이어 승리");
                    userEXP += EXP;
                    Debug.LogFormat("유저 획득 경험치 : {0}", userEXP);
                    // 변경된 체력값 적용
                    UserInformation.player.hp = userHP;
                    Debug.Log("-------------------------------------------------");
                    // 여기 레벨업 때 돌아야할 거 추가
                    break;

                }
                if (userHP <= 0)
                {
                    Debug.Log("죽음");
                    // 게임 엔딩
                    break;
                }
            }

            //----------------------------------------------------------------------------------------------//

            if ( attackButton_L2 == true || attackButton_M2 == true || attackButton_R2 == true)
            {


                // 클릭할 때 까지 wait 
                // 플레이어 애니메이션 실행 -> 애니메이션에 이벤트 넣는 방법으로 가능할듯

                hP -= randomDmg;

                Debug.LogFormat("유저가 준 데미지 : {0}", randomDmg);
                Debug.LogFormat("몬스터 체력 : {0}/{1}", hP, 20);

                Debug.Log("-------------------------------------------------");
                Debug.Log("몬스터 턴");
                // 몬스터 애니메이션 실행
                monsterAnimation.SetBool("Attack2", true);
                userHP -= monsterRandomDmg;
                yield return new WaitForSeconds(1f);
                monsterAnimation.SetBool("Attack2", false);

                Debug.LogFormat("몬스터가 준 데미지 : {0}", monsterRandomDmg);
                Debug.LogFormat("플레이어 체력 : {0}/{1}", userHP, 100);
                Debug.Log("-------------------------------------------------");
                attackButton_L2 = false;
                attackButton_M2 = false;
                attackButton_R2 = false;
                buttonClicked = false;

                if (userHP >= 0 && hP <= 0)
                {
                    Debug.Log("-------------------------------------------------");
                    Debug.LogFormat("플레이어 승리");
                    userEXP += EXP;
                    Debug.LogFormat("유저 획득 경험치 : {0}", userEXP);
                    // 변경된 체력값 적용
                    UserInformation.player.hp = userHP;
                    Debug.Log("-------------------------------------------------");
                    // 여기 레벨업 때 돌아야할 거 추가
                    break;

                }
                if (userHP <= 0)
                {
                    Debug.Log("죽음");
                    // 게임 엔딩
                    break;
                }
            }


        }
    }










    private void Start()
    {

        //leftHandImg = GameObject.Find("LeftHand");
        //rightHandImg = GameObject.Find("RightHand");

        AttackArea_R = GameObject.Find("AttackArea");
        AttackArea_N = GameObject.Find("AttackArea2");

        weaponUI = GameObject.Find("UserWeaponUI");

        animator = transform.GetComponent<Animator>(); // Animator 




        ImageSc6();
        ImageSc8();

        //StartCoroutine(BattleLoop());
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {

            }
            else
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                Collider2D collider = Physics2D.OverlapPoint(mousePosition);

                if (collider != null && collider.CompareTag("Rookie"))
                {
                    ImageSc7();
                }
                if (collider != null && collider.CompareTag("Neighbour"))
                {
                    ImageSc9();
                }
            }
        }

    }



    //private IEnumerator BattleLoop()
    //{
    //    while (true)
    //    {
    //        if (isPlayerTurn)
    //        {
    //            Debug.Log("유저턴");
    //        }
    //        else
    //        {
    //            Debug.Log("몬스터 턴");
    //            yield return StartCoroutine(MonsterTurn());
    //        }

    //        isPlayerTurn = !isPlayerTurn;
    //    }
    //}

    //private void HandleAttackButtonClick()
    //{
    //    if (isPlayerTurn)
    //    {
    //        Debug.Log("Attack 버튼을 클릭했습니다.");

    //        ImageSc6();
    //        ImageSc8();

    //        animator.SetBool("SpearAttack", true);
    //        // 플레이어가 공격 영역을 클릭할 때까지 대기합니다.
    //        StartCoroutine(BattleLoop());
    //    }
    //}

    //private IEnumerator WaitForAttackClick()
    //{
    //    while (!playerClicked)
    //    {
    //        yield return null; // 기다립니다.
    //    }

    //    Debug.Log("플레이어가 공격 영역을 클릭했습니다.");
    //    animator.SetBool("SpearAttack", false);
    //    //yield return StartCoroutine(PlayerTurn());
    //}



    //private IEnumerator PlayerTurn()
    //{
    //    Debug.Log("유저가 몬스터를 공격합니다.");
    //    yield return new WaitForSeconds(1f);
    //}

    //private IEnumerator MonsterTurn()
    //{
    //    Debug.Log("몬스터가 유저를 공격합니다.");
    //    yield return new WaitForSeconds(1f);
    //}



    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Rookie") || collision.tag.Equals("Neighbour"))
        {
            animator.SetBool("WaitingSpearAttack", true);
            ImageSc11();

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Rookie") || collision.tag.Equals("Neighbour"))
        {


            ImageSc10();
            animator.SetBool("WaitingSpearAttack", false);


        }
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{

    //    if (gameObject.CompareTag("Finish"))
    //    {
    //        ImageSc6();
    //        ImageSc8();
    //    }
        
    //    if (gameObject.name == ("RookieAttackArea1"))
    //    {
    //        attackButton_L = true;
    //    }
    //    else if (gameObject.name == ("RookieAttackArea2"))
    //    {
    //        attackButton_M = true;
    //    }
    //    else if (gameObject.name == ("RookieAttackArea3"))
    //    {
    //        attackButton_R = true;
    //    }
    //}



    //private void ActivateUIImages()
    //{

    //    ImageSc3();
    //    ImageSc4();
    //    ImageSc5();

    //}

    //private void ActivateUIImages2()
    //{
    //    ImageSc();
    //    ImageSc1();
    //    ImageSc2();
    //}


    //public void ImageSc()
    //{
    //    Vector3 uiImageScale = leftHandImg.transform.localScale;

    //    Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

    //    leftHandImg.transform.localScale = newScale;
    //}

    //public void ImageSc1()
    //{
    //    Vector3 uiImageScale = rightHandImg.transform.localScale;

    //    Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

    //    rightHandImg.transform.localScale = newScale;
    //}

    //public void ImageSc2()
    //{
    //    Vector3 uiImageScale = attackTypeImg.transform.localScale;

    //    Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

    //    attackTypeImg.transform.localScale = newScale;
    //}

    //public void ImageSc3()
    //{
    //    Vector3 uiImageScale = leftHandImg.transform.localScale;

    //    Vector3 newScale = new Vector3(1, 1, 0);

    //    leftHandImg.transform.localScale = newScale;
    //}

    //public void ImageSc4()
    //{
    //    Vector3 uiImageScale = rightHandImg.transform.localScale;

    //    Vector3 newScale = new Vector3(1, 1, 0);

    //    rightHandImg.transform.localScale = newScale;
    //}

    //public void ImageSc5()
    //{
    //    Vector3 uiImageScale = attackTypeImg.transform.localScale;

    //    Vector3 newScale = new Vector3(0.7f, 0.7f, 0);

    //    attackTypeImg.transform.localScale = newScale;
    //}

    public void ImageSc6()
    {
        Vector3 uiImageScale = AttackArea_R.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

        AttackArea_R.transform.localScale = newScale;
    }


    public void ImageSc7()
    {
        Vector3 uiImageScale = AttackArea_R.transform.localScale;

        Vector3 newScale = new Vector3(1f, 1f, 1f);

        AttackArea_R.transform.localScale = newScale;
    }

    public void ImageSc8()
    {
        Vector3 uiImageScale = AttackArea_N.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

        AttackArea_N.transform.localScale = newScale;
    }


    public void ImageSc9()
    {
        Vector3 uiImageScale = AttackArea_N.transform.localScale;

        Vector3 newScale = new Vector3(1f, 1f, 1f);

        AttackArea_N.transform.localScale = newScale;
    }


    public void ImageSc10()
    {
        Vector3 uiImageScale = weaponUI.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0.001f);

        weaponUI.transform.localScale = newScale;
    }

    public void ImageSc11()
    {
        Vector3 uiImageScale = weaponUI.transform.localScale;

        Vector3 newScale = new Vector3(1f, 1f, 1f);

        weaponUI.transform.localScale = newScale;
    }


    // Neighbour 45%, 85%, 70%
    // Rookie 50%, 90%, 80%
    // hit 스텟당 2% 씩 상승

    // ------------------------ Neighbour ---------------------------------------

    // 45%
    public float Neighbour_ButtonLeft(out float randomDmg, float userMinDmg, float userMaxDmg, int userHit)
    {
         randomDmg = 0f;

        int userAttackProb = 45 + (userHit - 5) * 2;
        int prob = Random.Range(0, 100);

        if (userAttackProb > prob)
        {
            randomDmg = Random.Range(userMinDmg * 1.5f, userMaxDmg * 1.5f);
        }

        return randomDmg;
    }
    // 85%
    public float Neighbour_ButtonMid(out float randomDmg, float userMinDmg, float userMaxDmg, int userHit)
    {
         randomDmg = 0f;

        int userAttackProb = 85 + (userHit - 5) * 2;
        int prob = Random.Range(0, 100);

        if (userAttackProb > prob)
        {
            randomDmg = Random.Range(userMinDmg * 0.4f, userMaxDmg * 0.4f);
        }

        return randomDmg;
    }
    // 70%
    public float Neighbour_ButtonRight(out float randomDmg ,  float userMinDmg, float userMaxDmg, int userHit)
    {
         randomDmg = 0f;

        int userAttackProb = 70 + (userHit - 5) * 2;
        int prob = Random.Range(0, 100);

        if (userAttackProb > prob)
        {
            randomDmg = Random.Range(userMinDmg, userMaxDmg);
        }

        return randomDmg;
    }

    // ------------------------ Rookie ---------------------------------------

    // 50%
    public float Rookie_ButtonLeft(out float randomDmg, float userMinDmg, float userMaxDmg, int userHit)
    {
         randomDmg = 0f;

        int userAttackProb = 50 + (userHit - 5) * 2;
        int prob = Random.Range(0, 100);

        if (userAttackProb > prob)
        {
            randomDmg = Random.Range(userMinDmg * 2f, userMaxDmg * 2f);
        }

        return randomDmg;
    }
    // 90%
    public float Rookie_ButtonMid(out float randomDmg,  float userMinDmg, float userMaxDmg, int userHit)
    {
         randomDmg = 0f;

        int userAttackProb = 90 + (userHit - 5) * 2;
        int prob = Random.Range(0, 100);

        if (userAttackProb > prob)
        {
            randomDmg = Random.Range(userMinDmg * 0.4f, userMaxDmg * 0.4f);
        }

        return randomDmg;
    }
    // 80%
    public float Rookie_ButtonRight(out float randomDmg ,  float userMinDmg, float userMaxDmg, int userHit)
    {
        randomDmg = 0f;

        int userAttackProb = 80 + (userHit - 5) * 2;
        int prob = Random.Range(0, 100);

        if (userAttackProb > prob)
        {
            randomDmg = Random.Range(userMinDmg, userMaxDmg);
        }

        return randomDmg;
    }



}
