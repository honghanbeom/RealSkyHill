using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterSpawn : MonoBehaviour
{
    public GameObject rookiePreafab;
    public GameObject neighbourPreafab;

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

        //rookiePreafab_L = rookiePreafab;
        //rookiePreafab_L.transform.localScale = new Vector3(-rookiePreafab_L.transform.localScale.x, rookiePreafab_L.transform.localScale.y, rookiePreafab_L.transform.localScale.z);

        //rookiePreafab_R = rookiePreafab;

    }


    void ReferenceMonster()
    {



        int randomIndex = Random.Range(0, 2); // 랜덤 인덱스 선택

        for (int x = 0; x < monsterCount.x; x++)
        {

            for (int y = 0; y < monsterCount.y; y++)
            {

                //Rookie 영점 조절
                float xPos = (spawnPoint.x * x) - 1.12f;
                float yPos = (spawnPoint.y * -y) - 2.1f;

                //Neighbour 영점 조절 
                float xPos1 = (spawnPoint1.x * x) + 5.5f;
                float yPos1 = (spawnPoint1.y * -y) + 0.5f;

                Vector3 rookieSpwanPoint = new Vector3(xPos, yPos, 0);

                Vector3 neighbourSpwanPoint = new Vector3(xPos1, yPos1, 0);


                if (randomIndex == 0)
                {
                    Instantiate(rookiePreafab, rookieSpwanPoint, Quaternion.identity);
                }
                else if (randomIndex == 1)
                {
                    NeighbourPrefabFlip();
                    Instantiate(neighbourPreafab, neighbourSpwanPoint, Quaternion.identity);
                    NeighbourPrefabFlip();


                }





            }
        }
    }

    public void SpawnRandomPrefab()
    {


        int randomIndex = Random.Range(0, 2); // 랜덤 인덱스 선택
        int randomRL = Random.Range(0, 2); // 랜덤 인덱스 선택

        for (int x = 0; x < monsterCount.x; x++)
        {

            for (int y = 0; y < monsterCount.y; y++)
            {

                //Rookie 영점 조절
                float xPos = (spawnPoint.x * x) - 1.12f;
                float yPos = (spawnPoint.y * -y) - 2.1f;

                //Neighbour 영점 조절 
                float xPos1 = (spawnPoint1.x * x) - 5.2f;
                float yPos1 = (spawnPoint1.y * -y) + 0.5f;

                Vector3 rookieSpwanPoint = new Vector3(xPos, yPos, 0);

                Vector3 neighbourSpwanPoint = new Vector3(xPos1, yPos1, 0);

                if (randomIndex == 0) // Rookie 소환 
                {
                    if (randomRL == 0)
                    {
                        //Vector3 rightMonsterSpwaner = rookieSpwanPoint + Vector3.right * spacingRight;
                        //Instantiate(rookiePreafab_R, rightMonsterSpwaner, Quaternion.identity);
                        //Vector3 leftMonsterSpwaner = rookieSpwanPoint + Vector3.right * spacingRight;
                        //Instantiate(rookiePreafab_L, rightMonsterSpwaner, Quaternion.identity);

                        //Vector3 leftMonsterSpwaner = rookieSpwanPoint + Vector3.left * spacingRight;
                        //Instantiate(rookiePreafab_R, leftMonsterSpwaner, Quaternion.identity);


                        Vector3 rightMonsterSpwaner = rookieSpwanPoint + Vector3.right * spacingRight;
                        Instantiate(rookiePreafab_R, rightMonsterSpwaner, Quaternion.identity);

                        Vector3 leftMonsterSpwaner = rookieSpwanPoint + Vector3.left * spacingRight;
                        Instantiate(rookiePreafab_L, leftMonsterSpwaner, Quaternion.identity);
                        //RookieLeftPrefabFlip();

                    }
                    else if (randomRL == 1)
                    {
                        Vector3 rightMonsterSpwaner = rookieSpwanPoint + Vector3.right * spacingRight;
                        Instantiate(rookiePreafab_R, rightMonsterSpwaner, Quaternion.identity);


                        Vector3 leftMonsterSpwaner = rookieSpwanPoint + Vector3.left * spacingRight;
                        Instantiate(rookiePreafab_L, leftMonsterSpwaner, Quaternion.identity);
                        //RookieLeftPrefabFlip();


                    }
                }
                else if (randomIndex == 1) // 이웃 
                {
                    if (randomRL == 0)
                    {
                        Vector3 rightMonsterSpwaner1 = neighbourSpwanPoint + Vector3.right * spacingRight;
                        Instantiate(neighbourPreafab_R, rightMonsterSpwaner1, Quaternion.identity);

                        Vector3 leftMonsterSpwaner1 = neighbourSpwanPoint + Vector3.left * spacingRight;
                        Instantiate(neighbourPreafab_L, leftMonsterSpwaner1, Quaternion.identity);
                    }
                    else if (randomRL == 1)
                    {

                        Vector3 rightMonsterSpwaner1 = neighbourSpwanPoint + Vector3.right * spacingRight;
                        Instantiate(neighbourPreafab_R, rightMonsterSpwaner1, Quaternion.identity);

                        Vector3 leftMonsterSpwaner1 = neighbourSpwanPoint + Vector3.left * spacingRight;
                        Instantiate(neighbourPreafab_L, leftMonsterSpwaner1, Quaternion.identity);
                    }
                }
                
            }

        }
    }

    public void NeighbourPrefabFlip()
    {
        // 현재 스케일을 가져옴
        Vector3 currentScale = neighbourPreafab.transform.localScale;

        // x축 스케일을 반전
        Vector3 newScale = new Vector3(-currentScale.x, currentScale.y, currentScale.z);

        // 프리팹의 스케일을 수정하여 반전 적용
        neighbourPreafab.transform.localScale = newScale;
    }

    public void RookieLeftPrefabFlip()
    {
        // 현재 스케일을 가져옴
        Vector3 currentScale = rookiePreafab_L.transform.localScale;

        // x축 스케일을 반전
        Vector3 newScale = new Vector3(-currentScale.x, currentScale.y, currentScale.z);

        // 프리팹의 스케일을 수정하여 반전 적용
        rookiePreafab_L.transform.localScale = newScale;
    }


}

