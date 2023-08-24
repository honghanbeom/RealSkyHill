using System.Collections;
using UnityEngine;

public class RainEffect : MonoBehaviour
{
    public Transform user;
    public GameObject rainObj;
    private float rainspeed = 1f;


    private Vector3 originalPosition; // ���� ��ġ ����

    private float moveDistance = 0.2f; // �� �Ʒ��� �����̴� �Ÿ�
    private float moveSpeed = 1f; // ������ �ӵ�

    //------------------------------------------------------------
    private Coroutine coroutine;
    private WaitForSeconds waitForSeconds;

    private Vector3 upPosition;
    private Vector3 downPosition;

    //------------------------------------------------------------

    private void Start()
    {
        originalPosition = rainObj.transform.position; // ���� �� ���� ��ġ ����
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
        // ���� ������ ���
        float moveOffset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        Vector3 newPos = originalPosition + new Vector3(0f, moveOffset, 0f);
        rainObj.transform.position = newPos;

        // �� �̵�
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
