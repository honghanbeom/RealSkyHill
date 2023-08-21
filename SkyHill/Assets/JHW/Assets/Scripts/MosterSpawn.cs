using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterSpawn : MonoBehaviour
{
    //public GameObject uiImage; // Ȱ��ȭ�� UI �̹���
    //public GameObject uiImage1; // Ȱ��ȭ�� UI �̹���
    //public GameObject uiImage2; // Ȱ��ȭ�� UI �̹���

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
                int randomIndex = Random.Range(0, 2); // ���� �ε��� ����
                int randomSpawn = Random.Range(0, 10);

                //Rookie ���� ����
                float xPos = (spawnPoint.x * x) - 1.12f;
                float yPos = (spawnPoint.y * -y) - 2.1f;

                //Neighbour ���� ���� 
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
                int randomIndex = Random.Range(0, 2); // ���� �ε��� ����
                int randomRL = Random.Range(0, 2); // ���� �ε��� ����
                int randomSpawn1 = Random.Range(0, 10);

                //Rookie ���� ����
                float xPos = (spawnPoint.x * x) - 1.12f;
                float yPos = (spawnPoint.y * -y) - 2.1f;

                //LeftRookie ���� ����
                float xPos4 = (spawnPoint.x * x) + 1.5f;
                float yPos4 = (spawnPoint.y * -y) - 2.1f;

                //Neighbour ���� ���� 
                float xPos1 = (spawnPoint1.x * x) - 5.2f;
                float yPos1 = (spawnPoint1.y * -y) + 0.5f;

                //RightNeighbour ���� ���� 
                float xPos2 = (spawnPoint1.x * x) + 5.2f;
                float yPos2 = (spawnPoint1.y * -y) + 0.5f;

                Vector3 rookieSpwanPoint = new Vector3(xPos, yPos, 0);

                Vector3 neighbourSpwanPoint = new Vector3(xPos1, yPos1, 0);

                Vector3 rightNeighbourSpwanPoint = new Vector3(xPos2, yPos2, 0);

                Vector3 leftRookieSpwanPoint = new Vector3(xPos4, yPos4, 0);


                if (randomSpawn1 < 3)
                {
                    if (randomIndex == 0) // Rookie ��ȯ 
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
                            Instantiate(rookiePreafab_L, rightMonsterSpwaner, Quaternion.identity);

                            Vector3 leftMonsterSpwaner = leftRookieSpwanPoint + Vector3.left * spacingRight;
                            Instantiate(rookiePreafab_R, leftMonsterSpwaner, Quaternion.identity);
                            //RookieLeftPrefabFlip();
                            //RookieLeftPrefabFlip();


                        }
                        else if (randomRL == 1)
                        {

                            Vector3 rightMonsterSpwaner = rookieSpwanPoint + Vector3.right * spacingRight;
                            Instantiate(rookiePreafab_L, rightMonsterSpwaner, Quaternion.identity);


                            Vector3 leftMonsterSpwaner = leftRookieSpwanPoint + Vector3.left * spacingRight;
                            Instantiate(rookiePreafab_R, leftMonsterSpwaner, Quaternion.identity);
                            //RookieLeftPrefabFlip();
                            //RookieLeftPrefabFlip();

                        }
                    }
                    else if (randomIndex == 1) // �̿� 
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

    //public void NeighbourPrefabFlip()
    //{
    //    // ���� �������� ������
    //    Vector3 currentScale = neighbourPreafab.transform.localScale;

    //    // x�� �������� ����
    //    Vector3 newScale = new Vector3(-currentScale.x, currentScale.y, currentScale.z);

    //    // �������� �������� �����Ͽ� ���� ����
    //    neighbourPreafab.transform.localScale = newScale;
    //}

    //public void RookieLeftPrefabFlip()
    //{
    //    // ���� �������� ������
    //    Vector3 currentScale = rookiePreafab_L.transform.localScale;

    //    // x�� �������� ����
    //    Vector3 newScale = new Vector3(-currentScale.x, currentScale.y, currentScale.z);

    //    // �������� �������� �����Ͽ� ���� ����
    //    rookiePreafab_L.transform.localScale = newScale;


    //}
    //public void ImageSc()
    //{
    //    Vector3 uiImageScale = uiImage.transform.localScale;

    //    Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

    //    uiImage.transform.localScale = newScale;
    //}

    //public void ImageSc1()
    //{
    //    Vector3 uiImageScale = uiImage1.transform.localScale;

    //    Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

    //    uiImage1.transform.localScale = newScale;
    //}

    //public void ImageSc2()
    //{
    //    Vector3 uiImageScale = uiImage2.transform.localScale;

    //    Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

    //    uiImage2.transform.localScale = newScale;
    //}

}

