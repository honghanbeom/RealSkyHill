using System.Collections;
using UnityEngine;

public class RainEffect : MonoBehaviour
{
    public Transform user;
    public GameObject rainObj;
    private float rainspeed = 1f;


    private Vector3 originalPosition; // 원래 위치 저장

    private float moveDistance = 0.2f; // 위 아래로 움직이는 거리
    private float moveSpeed = 1f; // 움직임 속도

    //------------------------------------------------------------
    private Coroutine coroutine;
    private WaitForSeconds waitForSeconds;

    private Vector3 upPosition;
    private Vector3 downPosition;

    //------------------------------------------------------------

    private void Start()
    {
        originalPosition = rainObj.transform.position; // 시작 시 원래 위치 저장
        waitForSeconds = new WaitForSeconds(0.2f);
        upPosition = new Vector3(0f, 1.2f, 0f);
        downPosition = new Vector3(0f, -1.2f, 0f);

        coroutine = StartCoroutine(SG_MoveRain001());
    }

    private void Update()
    {
        //UserFollow();
        //MoveRain();
    }

    private void UserFollow()
    {
        Vector3 desiredPosition = new Vector3(transform.position.x, user.position.y, transform.position.z);
        transform.position = desiredPosition;
    }

    private void MoveRain()
    {
        // 상하 움직임 계산
        float moveOffset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        Vector3 newPos = originalPosition + new Vector3(0f, moveOffset, 0f);
        rainObj.transform.position = newPos;

        // 비 이동
        rainObj.transform.Translate(Vector3.down * rainspeed * Time.deltaTime);
    }

    private IEnumerator SG_MoveRain001()
    {

        this.gameObject.transform.position = user.gameObject.transform.position;
        //Debug.LogFormat("{0}", this.gameObject.transform.position);
        gameObject.transform.position += upPosition;



        yield return waitForSeconds;

        coroutine = StartCoroutine(SG_MoveRain002());
    }
    private IEnumerator SG_MoveRain002()
    {
        this.gameObject.transform.position = user.gameObject.transform.position;
        gameObject.transform.position += downPosition;
        yield return waitForSeconds;
        coroutine = StartCoroutine(SG_MoveRain001());
    }
}
