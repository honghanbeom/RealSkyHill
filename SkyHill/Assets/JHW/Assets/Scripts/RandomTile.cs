using UnityEngine;

public class RandomTile : MonoBehaviour
{
    public GameObject[] referenceObjectPrefab; // ������ �Ǵ� GameObject ������
    public GameObject[] objectPrefab;
    public GameObject FrameObjectPrefab;
    public float spacingRight = 1.0f;         // ������ ������Ʈ �� ����
    public float spacingLeft = 1.0f;

    

    public float frameRight = 1.0f;
    public float frameDown = 1.0f;  // ������ ������Ʈ �� ����


    public Vector2Int gridSize = new Vector2Int(5, 5);
    public Vector2 cellSize = new Vector2(1.0f, 1.0f);


    private GameObject referenceObject;       // ������ ���� GameObject



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
                // �����ʿ� GameObject ����
                Vector3 rightSpawnPosition = spawnPosition + Vector3.right * spacingRight;
                Instantiate(objectPrefab[rightRoom], rightSpawnPosition, Quaternion.identity);

                // ���ʿ� GameObject ����
                Vector3 leftSpawnPosition = spawnPosition + Vector3.left * spacingLeft;
                Instantiate(objectPrefab[leftRoom], leftSpawnPosition, Quaternion.identity);

                // ���ʿ� GameObject ����
                Vector3 SpawnPosition = spawnPosition + Vector3.right * frameRight + Vector3.down * frameDown;
                Instantiate(FrameObjectPrefab, SpawnPosition, Quaternion.identity);
            }
        }
    }




}


