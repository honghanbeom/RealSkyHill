using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterSpawn : MonoBehaviour
{
    //public GameObject uiImage; // 활성화할 UI 이미지
    //public GameObject uiImage1; // 활성화할 UI 이미지
    //public GameObject uiImage2; // 활성화할 UI 이미지

    public GameObject rookiePreafab_R;
    public GameObject neighbourPreafab_R;

    public GameObject rookiePreafab_L;
    public GameObject neighbourPreafab_L;


    public float spacingRight = 1.0f;
    public float spacingLeft = 1.0f;





    public Vector2 spawnPoint = new Vector2(1.0f, 1.0f);
    public Vector2 spawnPoint1 = new Vector2(1.0f, 1.0f);

    public Vector2Int monsterCount = new Vector2Int(5, 5);



    // Start is called before the first frame update
    void Start()
    {
        ReferenceMonster();
        SpawnRandomPrefab();
        //uiImage = GameObject.Find("LeftHand");
        //uiImage1 = GameObject.Find("RightHand");
        //uiImage2 = GameObject.Find("AttackType");

        //ImageSc();
        //ImageSc1();
        //ImageSc2();

    }


    void ReferenceMonster()
    {




        for (int x = 0; x < monsterCount.x; x++)
        {

            for (int y = 1; y < monsterCount.y; y++)
            {
                int randomIndex = Random.Range(0, 2); // 랜덤 인덱스 선택
                int randomSpawn = Random.Range(0, 10);

                //Rookie 영점 조절
                float xPos = (spawnPoint.x * x) - 0f;
                float yPos = (spawnPoint.y * -y) - 1.69f;

                //Neighbour 영점 조절 
                float xPos1 = (spawnPoint1.x * x) + 5.5f;
                float yPos1 = (spawnPoint1.y * -y) + 0.5f;

                Vector3 rookieSpwanPoint = new Vector3(xPos, yPos, 0);

                Vector3 neighbourSpwanPoint = new Vector3(xPos1, yPos1, 0);

                if (randomSpawn < 3)
                {

                    if (randomIndex == 0)
                    {
                        Instantiate(rookiePreafab_L, rookieSpwanPoint, Quaternion.identity);
                    }
                    else if (randomIndex == 1)
                    {

                        //NeighbourPrefabFlip();
                        Instantiate(neighbourPreafab_L, neighbourSpwanPoint, Quaternion.identity);
                        //NeighbourPrefabFlip();
                    }
                }
                else if (randomSpawn >= 3)
                {

                }





            }
        }
    }

    public void SpawnRandomPrefab()
    {



        for (int x = 0; x < monsterCount.x; x++)
        {

            for (int y = 1; y < monsterCount.y; y++)
            {
                int randomIndex = Random.Range(0, 2); // 랜덤 인덱스 선택
                int randomRL = Random.Range(0, 2); // 랜덤 인덱스 선택
                int randomSpawn1 = Random.Range(0, 10);

                //Rookie 영점 조절
                float xPos = (spawnPoint.x * x) - 1.12f;
                float yPos = (spawnPoint.y * -y) - 1.69f;

                //LeftRookie 영점 조절
                float xPos4 = (spawnPoint.x * x) + 1.5f;
                float yPos4 = (spawnPoint.y * -y) - 1.69f;

                //Neighbour 영점 조절 
                float xPos1 = (spawnPoint1.x * x) - 5.2f;
                float yPos1 = (spawnPoint1.y * -y) + 0.5f;

                //RightNeighbour 영점 조절 
                float xPos2 = (spawnPoint1.x * x) + 5.2f;
                float yPos2 = (spawnPoint1.y * -y) + 0.5f;

                Vector3 rookieSpwanPoint = new Vector3(xPos, yPos, 0);

                Vector3 neighbourSpwanPoint = new Vector3(xPos1, yPos1, 0);

                Vector3 rightNeighbourSpwanPoint = new Vector3(xPos2, yPos2, 0);

                Vector3 leftRookieSpwanPoint = new Vector3(xPos4, yPos4, 0);


                if (randomSpawn1 < 3)
                {
                    if (randomIndex == 0) // Rookie 소환 
                    {
                        if (randomRL == 0)
                        {



                            Vector3 rightMonsterSpwaner = rookieSpwanPoint + Vector3.right * spacingRight;
                            Instantiate(rookiePreafab_L, rightMonsterSpwaner, Quaternion.identity);

                            Vector3 leftMonsterSpwaner = leftRookieSpwanPoint + Vector3.left * spacingRight;
                            Instantiate(rookiePreafab_R, leftMonsterSpwaner, Quaternion.identity);



                        }
                        else if (randomRL == 1)
                        {

                            Vector3 rightMonsterSpwaner = rookieSpwanPoint + Vector3.right * spacingRight;
                            Instantiate(rookiePreafab_L, rightMonsterSpwaner, Quaternion.identity);


                            Vector3 leftMonsterSpwaner = leftRookieSpwanPoint + Vector3.left * spacingRight;
                            Instantiate(rookiePreafab_R, leftMonsterSpwaner, Quaternion.identity);


                        }
                    }
                    else if (randomIndex == 1) // 이웃 
                    {
                        if (randomRL == 0)
                        {

                            Vector3 rightMonsterSpwaner1 = rightNeighbourSpwanPoint + Vector3.right * spacingRight;
                            Instantiate(neighbourPreafab_L, rightMonsterSpwaner1, Quaternion.identity);

                            Vector3 leftMonsterSpwaner1 = neighbourSpwanPoint + Vector3.left * spacingRight;
                            Instantiate(neighbourPreafab_R, leftMonsterSpwaner1, Quaternion.identity);
                        }
                        else if (randomRL == 1)
                        {


                            Vector3 rightMonsterSpwaner1 = rightNeighbourSpwanPoint + Vector3.right * spacingRight;
                            Instantiate(neighbourPreafab_L, rightMonsterSpwaner1, Quaternion.identity);

                            Vector3 leftMonsterSpwaner1 = neighbourSpwanPoint + Vector3.left * spacingRight;
                            Instantiate(neighbourPreafab_R, leftMonsterSpwaner1, Quaternion.identity);
                        }
                    }
                }
                else if (randomSpawn1 >= 3)
                {

                }

            }
        }

    }




}

