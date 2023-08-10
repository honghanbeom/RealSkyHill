using UnityEngine;

<<<<<<< HEAD
public class DropItem : MonoBehaviour
=======
public class RandomTile : MonoBehaviour
>>>>>>> origin/JHW
{
    public GameObject[] referenceObjectPrefab; // 기준이 되는 GameObject 프리팹
    public GameObject[] objectPrefab;
    public GameObject FrameObjectPrefab;
    public float spacingRight = 1.0f;         // 오른쪽 오브젝트 간 간격
    public float spacingLeft = 1.0f;

    

    public float frameRight = 1.0f;
    public float frameDown = 1.0f;  // 오른쪽 오브젝트 간 간격


    public Vector2Int gridSize = new Vector2Int(5, 5);
    public Vector2 cellSize = new Vector2(1.0f, 1.0f);


    private GameObject referenceObject;       // 생성된 기준 GameObject



    private void Start()
    {
        SpawnReferenceObject();
        SpawnObjects();
    }

    void SpawnReferenceObject()
    {

        

        for (int x = 0; x < gridSize.x; x++)
        {

            for (int y = 0; y < gridSize.y; y++)
            {

                int evRandom = Random.Range(0, 12);

                float xPos = (x * cellSize.x) - 0.227f;

                float yPos = (-y * cellSize.y) - 1.76f;



                Vector3 spawnPosition = new Vector3(xPos, yPos, 0);

                referenceObject = Instantiate(referenceObjectPrefab[evRandom] , spawnPosition, Quaternion.identity);
            }
        }
    }

    void SpawnObjects()
    {
        for (int x = 0; x < gridSize.x; x++)
        {

            for (int y = 0; y < gridSize.y; y++)
            {
                int leftRoom = Random.Range(0, 18);
                int rightRoom = Random.Range(0, 18);

                float xPos = (x * cellSize.x) - 0.227f;

                float yPos = (-y * cellSize.y) - 1.76f;



                Vector3 spawnPosition = new Vector3(xPos, yPos, 0);
                // 오른쪽에 GameObject 생성
                Vector3 rightSpawnPosition = spawnPosition + Vector3.right * spacingRight;
                Instantiate(objectPrefab[rightRoom], rightSpawnPosition, Quaternion.identity);

                // 왼쪽에 GameObject 생성
                Vector3 leftSpawnPosition = spawnPosition + Vector3.left * spacingLeft;
                Instantiate(objectPrefab[leftRoom], leftSpawnPosition, Quaternion.identity);

                // 왼쪽에 GameObject 생성
                Vector3 SpawnPosition = spawnPosition + Vector3.right * frameRight + Vector3.down * frameDown;
                Instantiate(FrameObjectPrefab, SpawnPosition, Quaternion.identity);
            }
        }
    }




}


