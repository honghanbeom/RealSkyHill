using System.Collections;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;

public class RainEffect : MonoBehaviour
{
    public Transform user;
    public GameObject rainObj;
    public bool isRain = false;
    private RectTransform rectTransform;
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
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rainObj.transform.position; // ���� �� ���� ��ġ ����
        waitForSeconds = new WaitForSeconds(0.2f);
        upPosition = new Vector3(0f, 1.2f, 0f);
        downPosition = new Vector3(0f, -1.2f, 0f);

        if (isRain == true)
        {
            coroutine = StartCoroutine(JS_MoveRain001());
        }
        else
        {
            coroutine = StartCoroutine(SG_MoveRain001());
        }
    }

    //private void UserFollow()
    //{
    //    Vector3 desiredPosition = new Vector3(transform.position.x, user.position.y, user.position.z);
    //    transform.position = desiredPosition;
    //}

    //private void MoveRain()
    //{
    //    // ���� ������ ���
    //    float moveOffset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
    //    Vector3 newPos = originalPosition + new Vector3(0f, moveOffset, 0f);
    //    rainObj.transform.position = newPos;

    //    // �� �̵�
    //    rainObj.transform.Translate(Vector3.down * rainspeed * Time.deltaTime);
    //}

    private IEnumerator SG_MoveRain001()
    {
        this.gameObject.transform.position = user.gameObject.transform.position;
        //Debug.Log(this.gameObject.transform.position);
        //Debug.LogFormat("{0}", this.gameObject.transform.position);
        gameObject.transform.position += upPosition;



        yield return waitForSeconds;

        coroutine = StartCoroutine(SG_MoveRain002());
    }
    private IEnumerator SG_MoveRain002()
    {
        this.gameObject.transform.position = user.gameObject.transform.position;
        gameObject.transform.position += downPosition;
        //Debug.Log(this.gameObject.transform.position);
        yield return waitForSeconds;
        coroutine = StartCoroutine(SG_MoveRain001());
    }

    private IEnumerator JS_MoveRain001()
    {
        rectTransform.anchoredPosition = user.gameObject.transform.position;
        //Debug.Log(this.gameObject.transform.position);
        //Debug.LogFormat("{0}", this.gameObject.transform.position);
        gameObject.transform.position += upPosition;

        yield return waitForSeconds;

        coroutine = StartCoroutine(JS_MoveRain002());
    }
    private IEnumerator JS_MoveRain002()
    {
        rectTransform.anchoredPosition = user.gameObject.transform.position;
        gameObject.transform.position += downPosition;
        //Debug.Log(this.gameObject.transform.position);
        yield return waitForSeconds;
        coroutine = StartCoroutine(JS_MoveRain001());
    }
}
