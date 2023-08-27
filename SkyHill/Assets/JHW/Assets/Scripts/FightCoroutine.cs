using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FightCoroutine : MonoBehaviour
{
    
    public Animator animator; // Animator


    public GameObject weaponUI; // 전투시작할 때 아래 무기 ui 불러오는거 

    public GameObject AttackArea_R; // Rookie 클릭했을 때 불러올 버튼 세개 
    public GameObject AttackArea_N; // Neighbour 클릭했을 때 불러올 버튼 세개 
    public GameObject RookieUI; // Rookie 전투시작 할 때 오른쪽 위에 ui
    public GameObject NeighbourUI; // NeighbourUI 전투시작 할 때 오른쪽 위에 ui

    public bool attackButton_L = false; //Rookie 전투때 영역선택 버튼 왼쪽꺼 켜져있는지 꺼져있는지 확인하는 거 
    public bool attackButton_M = false; // 중간버튼 
    public bool attackButton_R = false; // 오른쪽 버튼 


    public bool attackButton_L2 = false; //Neighbour 전투때 영역선택 버튼 왼쪽꺼 켜져있는지 꺼져있는지 확인하는 거 
    public bool attackButton_M2 = false; // 중간버튼
    public bool attackButton_R2 = false; // 오른쪽 버튼 

    bool buttonClicked = false; // 공격영역 버튼 클릭 확인 


    //public static FightCoroutine fight;


    public IEnumerator MonsterFight(string name, float hP, float maxDmg,
        float minDmg, float midDmg, float EXP , Animator monsterAnimation)
    {
        Debug.LogFormat("{0}와 전투시작", name);

        //user 정보 불러와서 변수 설정 
        float userHP = UserInformation.player.hp;
        float userEXP = UserInformation.player.exp;
        float userMaxDmg = UserInformation.player.maxAttackDamage;
        float userMinDmg = UserInformation.player.minAttackDamage;
        int userHit = UserInformation.player.hit;

        // User 랜덤 데미지 
        float randomDmg = default;
        // Monster 랜덤 데미지 
        float monsterRandomDmg = Random.Range(maxDmg, minDmg);


        while (userHP > 0 && hP > 0)
        {

            //버튼 클릭 여부 체크 
            while (!buttonClicked)
            {
                // 루키 버튼 하나라도 클릭되면 조건문 활성화 되면서 buttonClicked true활성화되고 while문 탈출 
                if (attackButton_L == true || attackButton_M == true|| attackButton_R == true )
                {

                    buttonClicked = true;
                }
                // 이웃 버튼 하나라도 클릭되면 조건문 활성화 되면서 buttonClicked true활성화되고 while문 탈출 
                if (attackButton_L2 == true || attackButton_M2 == true || attackButton_R2 == true)
                {
                    buttonClicked = true;
                }

                //조건문 만족 못할시 계속 while문 리턴 
                yield return null;

            }

            //Debug.Log("버튼이 눌렸습니다.");

            Debug.Log("-------------------------------------------------");

            Debug.Log("플레이어턴");
            // 이미지 띄우기
            // 이미지 클릭하면 그에 맞는 데미지 연산


            //attackButton은 전부 루키 공격영역 버튼 
            //attackButton2는 전부 이웃 공격영역 버튼 
            if (attackButton_L == true)
            {

                //Debug.Log("버튼 잘 눌린다.");
                Rookie_ButtonLeft(out randomDmg, userMinDmg, userMaxDmg, userHit);  //데미지 연산 
                ImageSc6(); //루키 공격영역 스케일 0.001 변경 
                animator.SetBool("SpearAttack" , true); // User공격 애니메이션 시작 
                yield return new WaitForSeconds(0.7f); // 0.7초 대기 
                animator.SetBool("SpearAttack", false); // User공격 애니메이션 종료 

            }

            else if (attackButton_M == true)
            {

                Debug.Log("버튼 잘 눌린다.");
                Rookie_ButtonMid(out randomDmg, userMinDmg, userMaxDmg, userHit);
                ImageSc6();
                animator.SetBool("SpearAttack", true);
                yield return new WaitForSeconds(0.7f);
                animator.SetBool("SpearAttack", false);
            }

            else if (attackButton_R == true)
            {

                //Debug.Log("버튼 잘 눌린다.");
                Rookie_ButtonRight(out randomDmg, userMinDmg, userMaxDmg, userHit);

                ImageSc6();
                animator.SetBool("SpearAttack", true);
                yield return new WaitForSeconds(0.7f);
                animator.SetBool("SpearAttack", false);
            }

            //-------------------------------------------------------------------------------------------//
            //이웃 

            if (attackButton_L2 == true)
            {

                //Debug.Log("이웃 버튼 잘 눌린다.");
                Neighbour_ButtonLeft(out randomDmg, userMinDmg, userMaxDmg, userHit); // 데미지 연산 
                ImageSc8(); // 이웃 공격영역 스케일 0.001 변경 
                animator.SetBool("SpearAttack", true);
                yield return new WaitForSeconds(0.7f);
                animator.SetBool("SpearAttack", false);

            }

            else if (attackButton_M2 == true)
            {

                //Debug.Log("이웃 버튼 잘 눌린다.");
                Neighbour_ButtonMid(out randomDmg, userMinDmg, userMaxDmg, userHit);
                ImageSc8();
                animator.SetBool("SpearAttack", true);
                yield return new WaitForSeconds(0.7f);
                animator.SetBool("SpearAttack", false);
            }

            else if (attackButton_R2 == true)
            {

                //Debug.Log("이웃 버튼 잘 눌린다.");
                Neighbour_ButtonRight(out randomDmg, userMinDmg, userMaxDmg, userHit);

                ImageSc8();
                
                animator.SetBool("SpearAttack", true);
                yield return new WaitForSeconds(0.7f);
                animator.SetBool("SpearAttack", false);
                
            }



            // 루키 공격영역 버튼 클릭했을 때 True 로 변경되면서 조건문 충족 (Rookie 공격영역 버튼을 True로 변경되는 과정은 buttonArea 스크립트에서 하는중)
            if ((attackButton_L == true || attackButton_M == true || attackButton_R == true))
            {


                hP -= randomDmg;
                MonsterHpUI ui = FindObjectOfType<MonsterHpUI>(); //Rookie 전투 오른쪽 위 hpUI 체력 연동 위해서 가져온거                  
                Debug.LogFormat("유저가 준 데미지 : {0}", randomDmg);
                Debug.LogFormat("몬스터 체력 : {0}/{1}", hP, 20);
                ui.MonsterUIUpdate(hP); // 연산된 Riikie hp 전달 (MonsterHpUI스크립트 에서 출력하고있음)

                Debug.Log("-------------------------------------------------");
                Debug.Log("몬스터 턴");

                // 몬스터 애니메이션 실행
                if (hP > 0)
                {
                    monsterAnimation.SetBool("Attack", true);
                    userHP -= monsterRandomDmg;
                    yield return new WaitForSeconds(0.35f);
                    monsterAnimation.SetBool("Attack", false);


                    Debug.LogFormat("몬스터가 준 데미지 : {0}", monsterRandomDmg);
                    Debug.LogFormat("플레이어 체력 : {0}/{1}", userHP, 100);
                    Debug.Log("-------------------------------------------------");
                }
                //혹시모르니 루키말고도 이웃 버튼도 다시한번 false로 꺼주기 그리고 다음턴을 위해 buttonClicked 도 다시 false로 변경 
                attackButton_L = false;
                attackButton_M = false;
                attackButton_R = false; 
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
                    Debug.Log("-------------------------------------------------");
                    // 여기 레벨업 때 돌아야할 거 추가
                    monsterAnimation.GetComponent<MonsterClick>().isFight = false; //몬스터 클릭했을 때 다른몬스터와 겹쳐서 스타트루틴 돌지않게 설정 (MonstserClick 스크립트 참고)
                    Destroy(monsterAnimation.GetComponent<MonsterClick>().collider); // 몬스터 죽었을 때 클릭 불가능하게 콜라이더 삭제 
                    Destroy(monsterAnimation.GetComponent<MonsterClick>().gameObject); // 몬스터 죽었을 때 애니메이션 버그로인해 몬스터 오브젝트 자체를 Destroy
                    ImageSc13(); // 루키 몬스터가 죽었으니까 오른쪽위에 출력했던 루키ui 0.001 스케일 변경 
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


            //이웃 공격영역 선택후 true 됐을때 턴 실행시키는 조건문 내용은 위 rookie와 동일 
            if ( (attackButton_L2 == true || attackButton_M2 == true || attackButton_R2 == true))
            {


                hP -= randomDmg;

                MonsterHpUI2 ui2 = FindObjectOfType<MonsterHpUI2>();
                Debug.LogFormat("유저가 준 데미지 : {0}", randomDmg);
                Debug.LogFormat("몬스터 체력 : {0}/{1}", hP, 30);
                ui2.MonsterUIUpdate2(hP);

                Debug.Log("-------------------------------------------------");
                Debug.Log("몬스터 턴");
                // 몬스터 애니메이션 실행
                if (hP > 0)
                {
                    monsterAnimation.SetBool("Attack2", true);
                    userHP -= monsterRandomDmg;
                    yield return new WaitForSeconds(1f);
                    monsterAnimation.SetBool("Attack2", false);

                    Debug.LogFormat("몬스터가 준 데미지 : {0}", monsterRandomDmg);
                    Debug.LogFormat("플레이어 체력 : {0}/{1}", userHP, 100);
                    Debug.Log("-------------------------------------------------");
                }
                attackButton_L = false;
                attackButton_M = false;
                attackButton_R = false;
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
                    Debug.Log("-------------------------------------------------");
                    // 여기 레벨업 때 돌아야할 거 추가
                    //monsterAnimation.SetBool("Dead", true);
                    monsterAnimation.GetComponent<MonsterClick>().isFight = false;
                    Destroy(monsterAnimation.GetComponent<MonsterClick>().collider);
                    Destroy(monsterAnimation.GetComponent<MonsterClick>().gameObject);
                    
                    break;

                }
                if (userHP <= 0)
                {
                    Debug.Log("죽음");
                    // 게임 엔딩
                    break;
                }


            }
                UserInformation.player.hp = userHP;


        }
    }










    private void Start()
    {

        AttackArea_R = GameObject.Find("AttackArea"); //루키 강제로 공격영역 찾아서 넣기 
        AttackArea_N = GameObject.Find("AttackArea2"); // 이웃 공격영역 강제로 찾아서 넣기
        RookieUI = GameObject.Find("RookieHUD"); // 루키 전투때 오른쪽위 ui 강제로 찾아서 넣기 
        NeighbourUI = GameObject.Find("NeighbourHUD"); // 이웃 전투때 오른쪽위 ui 강제로 찾아서 넣기 
        weaponUI = GameObject.Find("UserWeaponUI"); // 전투 시작시 중앙 아래에 뜨는 User무기창 ui 강제로 찾아서 넣기 

        animator = transform.GetComponent<Animator>(); // User 애니메이션 찾아서 넣기




        ImageSc6(); // 루키 공격영역 게임 시작할 때 0.001스케일로 바꿔주기 
        ImageSc8();// 이웃 공격영역 게임 시작할 때 0.001스케일로 바꿔주기 
        ImageSc13(); // 루키 오른쪽위 ui 게임 시작할 때 0.001스케일로 바꿔주기 
        ImageSc15(); // 이웃 오른쪽위 ui 게임 시작할 때 0.001스케일로 바꿔주기 

    }

    public void Update()
    { 
        //마우스로 클릭했을 때 조건문 
        if (Input.GetMouseButtonDown(0))
        {
            //클릭한게 ui일 때 클릭 못하게 막는거 
            if (EventSystem.current.IsPointerOverGameObject())
            {

            }
            else
            {
                //유저 이동방식과 똑같은 마우스로 클릭한 부분 월드좌표 받아와서 클릭한 부분에 태그가달린 오브젝트가 있다면 상호작용 하게 설정 
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                Collider2D collider = Physics2D.OverlapPoint(mousePosition);

                //클릭한 오브젝트가 루키태그를 가지고있다면 
                if (collider != null && collider.CompareTag("Rookie"))
                {
                    //루키 공격영역 ui 스케일 1f로 변경 
                    ImageSc7();

                }
                //클릭한 오브젝트가 이웃태그를 가지고있다면 
                if (collider != null && collider.CompareTag("Neighbour"))
                {
                    //이웃 공격영역 ui 스케일 1f로 변경 
                    ImageSc9();
                }
            }
        }

    }




    //User가 태그가 달린 오브젝트 콜라이더에 닿았을때 
    public void OnTriggerEnter2D(Collider2D collision)
    {
            //루키랑 만났을때 
            if (collision.tag.Equals("Rookie"))
            {
                animator.SetBool("WaitingSpearAttack", true);
                //루키 오른쪽위 hpUI 켜고
                //가운데 아래 웨폰 ui 켜고 
                ImageSc12();
                ImageSc11();

        }
            //이웃이랑 만났을 때 
        else if (collision.tag.Equals("Neighbour"))
            {
                animator.SetBool("WaitingSpearAttack", true);

            //이웃 오른쪽위 hpUI 켜고
            //가운데 아래 웨폰 ui 켜고 

            ImageSc14();

                ImageSc11();

            }

        
    }

    //User가 태그가 달린 오브젝트 콜라이더에 멀어졌을 때 
    public void OnTriggerExit2D(Collider2D collision)
    {


        //위 내용과 반대 
            if (collision.tag.Equals("Rookie"))
            {
                animator.SetBool("WaitingSpearAttack", false);
                ImageSc10();

                ImageSc13();
            }
            else if (collision.tag.Equals("Neighbour"))
            {
                animator.SetBool("WaitingSpearAttack", false);
                ImageSc10();
                ImageSc15();

        }



    }


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

    public void ImageSc12()
    {
        Vector3 uiImageScale = RookieUI.transform.localScale;

        Vector3 newScale = new Vector3(1f, 1f, 1f);

        RookieUI.transform.localScale = newScale;
        
    }
    public void ImageSc13()
    {
        Vector3 uiImageScale = RookieUI.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0.001f);

        RookieUI.transform.localScale = newScale;
        
    }

    public void ImageSc14()
    {
        Vector3 uiImageScale = NeighbourUI.transform.localScale;

        Vector3 newScale = new Vector3(1f, 1f, 1f);

        NeighbourUI.transform.localScale = newScale;

    }
    public void ImageSc15()
    {
        Vector3 uiImageScale = NeighbourUI.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0.001f);

        NeighbourUI.transform.localScale = newScale;
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
