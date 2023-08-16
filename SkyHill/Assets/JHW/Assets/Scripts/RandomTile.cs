using UnityEngine;

public class RandomTile : MonoBehaviour
{
    public GameObject[] referenceObjectPrefab; // ������ �Ǵ� GameObject ������
    public GameObject[] objectPrefab;
    public GameObject frameObjectPrefab;
    public GameObject darkRoom;
    public GameObject darkRoomEv;
    public float spacingRight = 1.0f;         // ������ ������Ʈ �� ����
    public float spacingLeft = 1.0f;

    

    public float frameRight = 1.0f;
    public float frameDown = 1.0f;  // ������ ������Ʈ �� ����


    public Vector2Int gridSize = new Vector2Int(5, 5);
    public Vector2 cellSize = new Vector2(1.0f, 1.0f);


    private GameObject referenceObject;
    private GameObject darkRoomEvObject;// ������ ���� GameObject



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


                float xPos2 = (x * cellSize.x) - 0.04f;

                float yPos2 = (-y * cellSize.y) - 1.8f;


                Vector3 darkRoomPosition_Ev = new Vector3(xPos2, yPos2, 0);



                //엘리베이터 방 스폰
                Vector3 spawnPosition = new Vector3(xPos, yPos, 0);

                referenceObject = Instantiate(referenceObjectPrefab[evRandom] , spawnPosition, Quaternion.identity);

                darkRoomEvObject = Instantiate(darkRoomEv, darkRoomPosition_Ev, Quaternion.identity);

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

                float xPos1 = (x * cellSize.x) + 0.18f;

                Vector3 darkPosition = new Vector3(xPos1 , yPos , 0);



                Vector3 spawnPosition = new Vector3(xPos, yPos, 0);
                // 오른쪽 방 스폰
                Vector3 rightSpawnPosition = spawnPosition + Vector3.right * spacingRight;
                Instantiate(objectPrefab[rightRoom], rightSpawnPosition, Quaternion.identity);

                // 왼쪽방 스폰
                Vector3 leftSpawnPosition = spawnPosition + Vector3.left * spacingLeft;
                Instantiate(objectPrefab[leftRoom], leftSpawnPosition, Quaternion.identity);

                // 프레임 스폰
                Vector3 farmePosition = spawnPosition + Vector3.right * frameRight + Vector3.down * frameDown;
                Instantiate(frameObjectPrefab, farmePosition, Quaternion.identity);
                
                //미확인 어두움 스폰
                Vector3 darkPosition_R = spawnPosition + Vector3.right * spacingRight;
                Instantiate(darkRoom, darkPosition_R, Quaternion.identity);

                //미확인 어두움 스폰
                Vector3 darkPosition_L = darkPosition + Vector3.left * spacingRight;
                Instantiate(darkRoom, darkPosition_L, Quaternion.identity);
            }
        }
    }




}


