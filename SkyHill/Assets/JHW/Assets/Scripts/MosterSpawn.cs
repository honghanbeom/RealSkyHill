using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterSpawn : MonoBehaviour
{
    public GameObject rookiePreafab;
    public GameObject neighbourPreafab;
    public float spacingRight = 1.0f;         
    public float spacingLeft = 1.0f;

    public Vector3 spawnPoint = new Vector3(0,0,0);
    public Vector3 spawnPoint1 = new Vector3(0, 0, 0);

    public Vector2Int monsterCount = new Vector2Int(5, 5);



    // Start is called before the first frame update
    void Start()
    {
        ReferenceMonster();
        SpawnRandomPrefab();
        
    }


    void ReferenceMonster()
    {
        //Rookie ¿µÁ¡ Á¶Àý
        float xPos = spawnPoint.x -= 1.5f;
        float yPos = spawnPoint.y -= 2.32f;

        //Neighbour ¿µÁ¡ Á¶Àý 
        float xPos1 = spawnPoint1.x -= 5.5f;
        float yPos1 = spawnPoint1.y += 0.5f;

        Vector3 rookieSpwanPoint = new Vector3(xPos, yPos, 0);

        Vector3 neighbourSpwanPoint = new Vector3(xPos1, yPos1, 0);

        int randomIndex = Random.Range(0, 2); // ·£´ý ÀÎµ¦½º ¼±ÅÃ


        for (int x = 0; x < monsterCount.x; x++)
        {

            for (int y = 0; y < monsterCount.y; y++)
            {


                if (randomIndex == 0)
                {
                    Instantiate(rookiePreafab, rookieSpwanPoint, Quaternion.identity);
                }
                else if (randomIndex == 1)
                {
                    Instantiate(neighbourPreafab, neighbourSpwanPoint, Quaternion.identity);
                }





            }
        }
    }

    public void SpawnRandomPrefab()
    {
        //Rookie ¿µÁ¡ Á¶Àý
        float xPos =  spawnPoint.x -= 1.5f;
        float yPos =  spawnPoint.y -= 2.32f;

        //Neighbour ¿µÁ¡ Á¶Àý 
        float xPos1 = spawnPoint1.x -= 5.5f;
        float yPos1 = spawnPoint1.y += 0.5f;

        Vector3 rookieSpwanPoint = new Vector3 (xPos, yPos,0);

        Vector3 neighbourSpwanPoint = new Vector3(xPos1 , yPos1 ,0);

        int randomIndex = Random.Range(0, 2); // ·£´ý ÀÎµ¦½º ¼±ÅÃ
        int randomRL = Random.Range(0, 2); // ·£´ý ÀÎµ¦½º ¼±ÅÃ



        for (int x = 0; x < monsterCount.x; x++)
        {

            for (int y = 0; y < monsterCount.y; y++)
            {

                if (randomIndex == 0)
                {
                    if(randomRL == 0)
                    {
                    Vector3 rightMonsterSpwaner = rookieSpwanPoint + Vector3.right * spacingRight;
                    Instantiate(rookiePreafab, rightMonsterSpwaner, Quaternion.identity);
                    }
                    else if (randomRL == 1)
                    {
                    Vector3 leftMonsterSpwaner = rookieSpwanPoint + Vector3.left * spacingRight;
                    Instantiate(rookiePreafab, leftMonsterSpwaner, Quaternion.identity);                       
                    }
                }
                else if (randomIndex == 1)
                {
                    if(randomRL == 0)
                    {
                    Vector3 rightMonsterSpwaner1 = neighbourSpwanPoint + Vector3.right * spacingRight;
                    Instantiate(neighbourPreafab, rightMonsterSpwaner1, Quaternion.identity);
                    }
                    else if (randomRL == 1)
                    {
                    Vector3 leftMonsterSpwaner1 = neighbourSpwanPoint + Vector3.left * spacingRight;
                    Instantiate(neighbourPreafab, leftMonsterSpwaner1, Quaternion.identity);
                    }
                }
            }
        }

    }
}
